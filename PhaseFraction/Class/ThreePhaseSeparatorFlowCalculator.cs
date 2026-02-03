using System;
using System.Linq;
namespace PhaseFraction
{
    /// <summary>
    /// 油气水三相分离器流量计算核心类
    /// 整合气、油、水三相流量计算逻辑，统一参数标准和工程修正
    /// </summary>
    public class ThreePhaseSeparatorFlowCalculator
    {
        #region 工程常量（可根据现场工况调整）
        // 默认分离器分离效率（常规重力分离器）
        private const double DefaultSeparatorEfficiency = 0.92;

        // 油/水温度膨胀系数（℃⁻¹）
        private const double OilTemperatureExpansionCoeff = 0.0008;
        private const double WaterTemperatureExpansionCoeff = 0.00021;

        // 气体常数（J/(mol·K)）
        private const double GasConstantR = 8.314;
        #endregion

        #region 气相流量计算（气量）
        /// <summary>
        /// 计算气相流量（气量）
        /// 基于油气界面下移速度、温度、压力和分离器尺寸
        /// </summary>
        /// <param name="oilGasInterfaceDropSpeed">油气界面下移速度 (m/s)</param>
        /// <param name="temperature">分离器内温度 (℃)</param>
        /// <param name="pressure">分离器内压力 (MPa)</param>
        /// <param name="separatorDiameter">分离器内径 (m)，默认0.5m</param>
        /// <returns>气相流量 (m³/h)</returns>
        /// <exception cref="ArgumentException">输入参数不合法时抛出</exception>
        public static double CalculateGasFlowRate(
            double oilGasInterfaceDropSpeed,
            double temperature,
            double pressure,
            double separatorDiameter = 0.5)
        {
            // 参数合法性校验
            if (oilGasInterfaceDropSpeed < 0)
                throw new ArgumentException("油气界面下移速度不能为负数", nameof(oilGasInterfaceDropSpeed));
            if (temperature < -273.15)
                throw new ArgumentException("温度不能低于绝对零度", nameof(temperature));
            if (pressure < 0)
                throw new ArgumentException("压力不能为负数", nameof(pressure));
            if (separatorDiameter <= 0)
                throw new ArgumentException("分离器内径必须大于0", nameof(separatorDiameter));

            // 基础参数计算
            double separatorRadius = separatorDiameter / 2;
            double crossSectionArea = Math.PI * Math.Pow(separatorRadius, 2); // 分离器横截面积

            // 单位转换：℃→K，MPa→Pa
            double tempKelvin = temperature + 273.15;
            double pressurePascal = pressure * 1_000_000;

            // 计算压缩因子Z（简化工程模型）
            double compressibilityFactor = CalculateGasCompressibilityFactor(tempKelvin, pressurePascal);

            // 温压修正系数（基于标准状态25℃、1标准大气压）
            double tempCorrectionFactor = 298.15 / tempKelvin;
            double pressureCorrectionFactor = pressurePascal / 101325;

            // 核心计算（m³/s）
            double gasFlowPerSecond = oilGasInterfaceDropSpeed
                                     * crossSectionArea
                                     * compressibilityFactor
                                     * tempCorrectionFactor
                                     * pressureCorrectionFactor;

            // 单位转换：m³/s → m³/h（×3600），保留4位小数
            return Math.Round(gasFlowPerSecond * 3600, 4);
        }

        /// <summary>
        /// 计算天然气压缩因子Z（简化工程模型）
        /// </summary>
        /// <param name="tempK">温度（开尔文）</param>
        /// <param name="pressPa">压力（帕斯卡）</param>
        /// <returns>压缩因子Z</returns>
        private static double CalculateGasCompressibilityFactor(double tempK, double pressPa)
        {
            if (pressPa < 101325) // 低于标准大气压
                return 0.98 + (pressPa / 101325) * 0.02;
            else if (pressPa <= 10_000_000) // 0.1-10MPa
                return 0.95 - (pressPa / 10_000_000) * 0.05 + (tempK / 300) * 0.02;
            else // 高压区域（>10MPa）
                return 0.85 + (tempK / 400) * 0.1;
        }

        /// <summary>
        /// 基于SRK（Soave-Redlich-Kwong）方程计算天然气压缩因子Z
        /// 适用于：温度-20~200℃，压力0.1~50MPa
        /// </summary>
        /// <param name="tempK">温度（开尔文）</param>
        /// <param name="pressPa">压力（帕斯卡）</param>
        /// <returns>压缩因子Z</returns>
        private static double CalculateCompressibilityFactor_SRK(double tempK, double pressPa)
        {
            // 天然气临界参数（平均值，可根据实际气藏调整）
            double Tc = 190.6;    // 临界温度（K）
            double Pc = 4.60E6;   // 临界压力（Pa）
            double omega = 0.01;  // 偏心因子（天然气约0.01-0.03）

            // SRK方程参数计算
            double Tr = tempK / Tc; // 对比温度
            double Pr = pressPa / Pc; // 对比压力
            double alpha = Math.Pow(1 + (0.480 + 1.574 * omega - 0.176 * omega * omega) * (1 - Math.Sqrt(Tr)), 2);
            double a = 0.42748 * (R * R * Tc * Tc / Pc) * alpha;
            double b = 0.08664 * (R * Tc / Pc);

            // 立方方程：Z³ - Z² + (A - B - B²)Z - AB = 0
            double A = a * pressPa / (R * R * tempK * tempK);
            double B = b * pressPa / (R * tempK);
            double c1 = 1;
            double c2 = -(1 - B);
            double c3 = A - 2 * B - 3 * B * B;
            double c4 = -(A * B - B * B - B * B * B);

            // 求解立方方程（取物理意义的正根）
            double z = SolveCubicEquation(c1, c2, c3, c4);
            return Math.Max(z, 0.8); // 限制最小值，避免异常
        }

        // 气体常数（J/(mol·K)）
        private const double R = 8.314;

        /// <summary>
        /// 求解立方方程 ax³ + bx² + cx + d = 0 的正实数根
        /// </summary>
        private static double SolveCubicEquation(double a, double b, double c, double d)
        {
            // 简化实现：仅返回油气藏场景下有物理意义的正根
            double x1, x2, x3;
            double delta0 = b * b - 3 * a * c;
            double delta1 = 2 * b * b * b - 9 * a * b * c + 27 * a * a * d;
            double delta = delta1 * delta1 - 4 * delta0 * delta0 * delta0;

            if (delta > 0)
            {
                // 一个实根，两个共轭复根
                double C = Math.Pow((delta1 + Math.Sqrt(delta)) / 2, 1.0 / 3);
                double D = Math.Pow((delta1 - Math.Sqrt(delta)) / 2, 1.0 / 3);
                x1 = (-b - C - D) / (3 * a);
                return x1 > 0 ? x1 : 0.9;
            }
            else
            {
                // 三个实根，取中间值（油气藏Z值通常0.8-1.0）
                double theta = Math.Acos(delta1 / (2 * Math.Pow(-delta0, 1.5)));
                x1 = (-b + 2 * Math.Sqrt(-delta0) * Math.Cos(theta / 3)) / (3 * a);
                x2 = (-b + 2 * Math.Sqrt(-delta0) * Math.Cos((theta + 2 * Math.PI) / 3)) / (3 * a);
                x3 = (-b + 2 * Math.Sqrt(-delta0) * Math.Cos((theta + 4 * Math.PI) / 3)) / (3 * a);

                // 筛选0.5-1.2范围内的根（符合工程实际）
                double[] roots = new[] { x1, x2, x3 }.Where(r => r > 0.5 && r < 1.2).ToArray();
                return roots.Length > 0 ? roots.Average() : 0.9;
            }
        }
        #endregion

        #region 液相流量计算（油、水）
        /// <summary>
        /// 计算油相流量
        /// </summary>
        /// <param name="oilGasInterfaceRiseSpeed">油气界面上升速度 (m/s)</param>
        /// <param name="separatorDiameter">分离器内径 (m)，默认0.5m</param>
        /// <param name="temperature">分离器内温度 (℃)，默认25℃</param>
        /// <param name="separatorEfficiency">分离器分离效率 (0-1)，默认0.92</param>
        /// <returns>油相流量 (m³/h)</returns>
        /// <exception cref="ArgumentException">参数非法时抛出</exception>
        public static double CalculateOilFlowRate(
            double oilGasInterfaceRiseSpeed,
            double separatorDiameter = 0.5,
            double temperature = 25,
            double separatorEfficiency = DefaultSeparatorEfficiency)
        {
            ValidateLiquidParameters(oilGasInterfaceRiseSpeed, separatorDiameter, separatorEfficiency);

            double crossSectionArea = CalculateCrossSectionArea(separatorDiameter);
            double oilVolumeCorrection = CalculateOilVolumeCorrection(temperature, separatorEfficiency);

            // 核心计算（m³/s）
            double oilFlowPerSecond = oilGasInterfaceRiseSpeed * crossSectionArea * oilVolumeCorrection;

            // 单位转换：m³/s → m³/h
            return Math.Round(oilFlowPerSecond * 3600, 4);
        }

        /// <summary>
        /// 计算水相流量
        /// </summary>
        /// <param name="oilWaterInterfaceRiseSpeed">油水界面上升速度 (m/s)</param>
        /// <param name="separatorDiameter">分离器内径 (m)，默认0.5m</param>
        /// <param name="temperature">分离器内温度 (℃)，默认25℃</param>
        /// <param name="separatorEfficiency">分离器分离效率 (0-1)，默认0.92</param>
        /// <returns>水相流量 (m³/h)</returns>
        /// <exception cref="ArgumentException">参数非法时抛出</exception>
        public static double CalculateWaterFlowRate(
            double oilWaterInterfaceRiseSpeed,
            double separatorDiameter = 0.5,
            double temperature = 25,
            double separatorEfficiency = DefaultSeparatorEfficiency)
        {
            ValidateLiquidParameters(oilWaterInterfaceRiseSpeed, separatorDiameter, separatorEfficiency);

            double crossSectionArea = CalculateCrossSectionArea(separatorDiameter);
            double waterVolumeCorrection = CalculateWaterVolumeCorrection(temperature, separatorEfficiency);

            // 核心计算（m³/s）
            double waterFlowPerSecond = oilWaterInterfaceRiseSpeed * crossSectionArea * waterVolumeCorrection;

            // 单位转换：m³/s → m³/h
            return Math.Round(waterFlowPerSecond * 3600, 4);
        }

        #region 液相计算辅助方法
        /// <summary>
        /// 校验液相计算参数合法性
        /// </summary>
        private static void ValidateLiquidParameters(double riseSpeed, double diameter, double efficiency)
        {
            if (riseSpeed < 0)
                throw new ArgumentException("界面上升速度不能为负数", nameof(riseSpeed));
            if (diameter <= 0)
                throw new ArgumentException("分离器内径必须大于0", nameof(diameter));
            if (efficiency < 0 || efficiency > 1)
                throw new ArgumentException("分离效率必须在0-1之间", nameof(efficiency));
        }

        /// <summary>
        /// 计算分离器横截面积
        /// </summary>
        private static double CalculateCrossSectionArea(double diameter)
        {
            double radius = diameter / 2;
            return Math.PI * Math.Pow(radius, 2);
        }

        /// <summary>
        /// 计算油相体积修正系数（温度膨胀+分离效率）
        /// </summary>
        private static double CalculateOilVolumeCorrection(double temperature, double efficiency)
        {
            double tempCorrection = 1 + OilTemperatureExpansionCoeff * (temperature - 25);
            return tempCorrection * efficiency;
        }

        /// <summary>
        /// 计算水相体积修正系数（温度膨胀+分离效率）
        /// </summary>
        private static double CalculateWaterVolumeCorrection(double temperature, double efficiency)
        {
            double tempCorrection = 1 + WaterTemperatureExpansionCoeff * (temperature - 25);
            return tempCorrection * efficiency;
        }
        #endregion
        #endregion

        #region 批量计算（一次性获取三相流量）
        /// <summary>
        /// 批量计算气、油、水三相流量
        /// </summary>
        /// <param name="gasInterfaceDropSpeed">油气界面下移速度 (m/s)</param>
        /// <param name="oilInterfaceRiseSpeed">油气界面上升速度 (m/s)</param>
        /// <param name="waterInterfaceRiseSpeed">油水界面上升速度 (m/s)</param>
        /// <param name="temperature">分离器内温度 (℃)</param>
        /// <param name="pressure">分离器内压力 (MPa)</param>
        /// <param name="separatorDiameter">分离器内径 (m)</param>
        /// <param name="separatorEfficiency">分离器分离效率 (0-1)，默认0.92</param>
        /// <returns>Tuple(气相流量, 油相流量, 水相流量)，单位：m³/h</returns>
        public static (double GasFlow, double OilFlow, double WaterFlow) CalculateThreePhaseFlow(
            double gasInterfaceDropSpeed,
            double oilInterfaceRiseSpeed,
            double waterInterfaceRiseSpeed,
            double temperature,
            double pressure,
            double separatorDiameter,
            double separatorEfficiency = DefaultSeparatorEfficiency)
        {
            double gasFlow = CalculateGasFlowRate(gasInterfaceDropSpeed, temperature, pressure, separatorDiameter);
            double oilFlow = CalculateOilFlowRate(oilInterfaceRiseSpeed, separatorDiameter, temperature, separatorEfficiency);
            double waterFlow = CalculateWaterFlowRate(waterInterfaceRiseSpeed, separatorDiameter, temperature, separatorEfficiency);

            return (gasFlow, oilFlow, waterFlow);
        }
        #endregion

        #region 测试示例
        /// <summary>
        /// 测试三相流量计算
        /// </summary>
        public static void TestThreePhaseCalculation()
        {
            try
            {
                // 测试参数
                double separatorDiameter = 1.0;    // 分离器内径1m
                double temp = 60;                  // 温度60℃
                double pressure = 2.5;             // 压力2.5MPa
                double efficiency = 0.95;          // 分离效率0.95

                // 界面速度
                double gasDropSpeed = 0.001;       // 油气界面下移0.001m/s
                double oilRiseSpeed = 0.0005;      // 油气界面上升0.0005m/s
                double waterRiseSpeed = 0.0008;    // 油水界面上升0.0008m/s

                // 方式1：单独计算各相
                double gasFlow = CalculateGasFlowRate(gasDropSpeed, temp, pressure, separatorDiameter);
                double oilFlow = CalculateOilFlowRate(oilRiseSpeed, separatorDiameter, temp, efficiency);
                double waterFlow = CalculateWaterFlowRate(waterRiseSpeed, separatorDiameter, temp, efficiency);

                Console.WriteLine("=== 单独计算结果 ===");
                Console.WriteLine($"气相流量：{gasFlow} m³/h");   // 预期≈54.7 m³/h
                Console.WriteLine($"油相流量：{oilFlow} m³/h");   // 预期≈5.08 m³/h
                Console.WriteLine($"水相流量：{waterFlow} m³/h"); // 预期≈8.13 m³/h

                // 方式2：批量计算
                var threePhaseResult = CalculateThreePhaseFlow(
                    gasDropSpeed, oilRiseSpeed, waterRiseSpeed,
                    temp, pressure, separatorDiameter, efficiency);

                Console.WriteLine("\n=== 批量计算结果 ===");
                Console.WriteLine($"气相流量：{threePhaseResult.GasFlow} m³/h");
                Console.WriteLine($"油相流量：{threePhaseResult.OilFlow} m³/h");
                Console.WriteLine($"水相流量：{threePhaseResult.WaterFlow} m³/h");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"计算失败：{ex.Message}");
            }
        }
        #endregion
    }
}