using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
//using System.Windows.Forms;

namespace PhaseFraction
{
    public partial class DAM3000M
    {
        // 串口号(以此类推) 供DAM3000M_CreateDevice使用，可根据自身需要扩充
        public const Int32 DAM3000M_COM1 = 0x01;// COM1
        public const Int32 DAM3000M_COM2 = 0x02;// COM2
        public const Int32 DAM3000M_COM3 = 0x03;// COM3
        public const Int32 DAM3000M_COM4 = 0x04;// COM4
        public const Int32 DAM3000M_COM5 = 0x05;// COM5

        // 波特率选择 供DAM3000M_SetDeviceInfo和DAM3000M_GetDeviceInfo中的PDAM3000M_DEVICE_INFO使用
        public const Int32 DAM3000M_BAUD_1200 = 0x00;   // 波特率1200
        public const Int32 DAM3000M_BAUD_2400 = 0x01;   // 波特率2400
        public const Int32 DAM3000M_BAUD_4800 = 0x02;   // 波特率4800
        public const Int32 DAM3000M_BAUD_9600 = 0x03;   // 波特率9600
        public const Int32 DAM3000M_BAUD_19200 = 0x04;  // 波特率19200
        public const Int32 DAM3000M_BAUD_38400 = 0x05;  // 波特率38400
        public const Int32 DAM3000M_BAUD_57600 = 0x06;  // 波特率57600
        public const Int32 DAM3000M_BAUD_115200 = 0x07; // 波特率115200

        // 波特率选择 供DAM3000M_SetDeviceInfo和DAM3000M_GetDeviceInfo中的PDAM3000M_DEVICE_INFO(bParity)使用
        public const Int32 DAM3000M_PARITY_NONE = 0x00;// 无校验
        public const Int32 DAM3000M_PARITY_EVEN = 0x01;// 偶校验
        public const Int32 DAM3000M_PARITY_ODD = 0x02; // 奇校验

        // 流控制选择 供DAM3000M_InitDeviceEx使用
        public const Int32 DAM3000M_FLOWCONTROL_NONE = 0x00;            // 默认不开启
        public const Int32 DAM3000M_FLOWCONTROL_SOFTWARE = 0x01;        // 软件
        public const Int32 DAM3000M_FLOWCONTROL_HARDWARERTSCTS = 0x02;  // 硬件RTS/CTS
        public const Int32 DAM3000M_FLOWCONTROL_HARDWAREDSRDTR = 0x03;  // 硬件DSR/DTR

        // 超时时间 供DAM3000M_InitDeviceEx使用
        public const Int32 DAM3000M_DEFAULT_TIMEOUT = -1;// 默认超时时间

        //重新启动电路板 供DAM3000M_Restart函数中的lpBuffer参数使用
        public const Int32 DAM3000M_DEV_NORMAL = 0x00; // 重新启动电路板,0:正常工作模式
        public const Int32 DAM3000M_DEV_RESTART = 0x01;// 重新启动电路板,1:重启电路板

        //看门狗超时工作模式 供DAM3000M_WdgSetMode和DAM3000M_WdgSetMode函数中的lpBuffer参数使用
        public const Int32 DAM3000M_WDG_MODE_RESET = 0x00;// 看门狗超时工作模式,0:系统复位
        public const Int32 DAM3000M_WDG_MODE_SAFE = 0x01; // 看门狗超时工作模式,1:进入安全模式

        //########################## AI ###################################
        //AI传输方式 供DAM3000M_AISetTransformMode和DAM3000M_AIGetTransformMode函数中的lpBuffer参数使用 
        public const Int32 DAM3000M_AI_TRANSMISSION_LINE = 0x00;    // AI传输方式,0:线性传输
        public const Int32 DAM3000M_AI_TRANSMISSION_DIRECT = 0x01;  // AI传输方式,1:数据直传

        // 模拟量输入类型(电压类型) 供DAM3000M_SetModeAD函数中的lMode参数使用
        public const Int32 DAM3000M_VOLT_N15_P15 = 0x01;    // -15～+15mV
        public const Int32 DAM3000M_VOLT_N50_P50 = 0x02;    // -50～+50mV
        public const Int32 DAM3000M_VOLT_N100_P100 = 0x03;  // -100～+100mV
        public const Int32 DAM3000M_VOLT_N150_P150 = 0x04;  // -150～+150mV
        public const Int32 DAM3000M_VOLT_N500_P500 = 0x05;  // -500～+500mV
        public const Int32 DAM3000M_VOLT_N0_P50 = 0x68;     // 0～+50mV
        public const Int32 DAM3000M_VOLT_N0_P100 = 0x69;    // 0～+100mV
        public const Int32 DAM3000M_VOLT_N0_P150 = 0x6A;    // 0～+150mV
        public const Int32 DAM3000M_VOLT_N0_P500 = 0x6B;    // 0～+500mV
        public const Int32 DAM3000M_VOLT_N1_P1 = 0x06;      // -1～+1V
        public const Int32 DAM3000M_VOLT_N0_P1 = 0x89;      // 0～+1V
        public const Int32 DAM3000M_VOLT_N25_P25 = 0x07;    // -2.5～+2.5V
        public const Int32 DAM3000M_VOLT_N5_P5 = 0x08;      // -5～+5V
        public const Int32 DAM3000M_VOLT_N10_P10 = 0x09;    // -10～+10V
        public const Int32 DAM3000M_VOLT_N0_P5 = 0x0D;      // 0～+5V
        public const Int32 DAM3000M_VOLT_N0_P10 = 0x0E;     // 0～+10V
        public const Int32 DAM3000M_VOLT_N0_P25 = 0x0F;     // 0～+2.5V
        public const Int32 DAM3000M_VOLT_N20_P20 = 0x81;    // -20～+20mV
        public const Int32 DAM3000M_VOLT_N1_P5 = 0x82;      // 1～+5V
        public const Int32 DAM3000M_VOLT_N30_P30V = 0x83;   // -30～+30V
        public const Int32 DAM3000M_VOLT_N0_P30V = 0x84;    // 0～+30V
        public const Int32 DAM3000M_VOLT_N500_P500V = 0x8A; // -500～+500V
        public const Int32 DAM3000M_VOLT_N30_P30 = 0x8B;    // -30mV～+30mV
        public const Int32 DAM3000M_VOLT_N0_P12 = 0x8C;     // 0～12V
        public const Int32 DAM3000M_VOLT_N0_P20 = 0x8D;     // 0～20V
        public const Int32 DAM3000M_VOLT_N0_P15 = 0x55;     // 0～+15V（同研华协议下0～+15V）
        public const Int32 DAM3000M_VOLT_N0_P35 = 0x72;     // 0～35V
        public const Int32 DAM3000M_VOLT_N35_P0 = 0x7E;     // -35～0V
        public const Int32 DAM3000M_VOLT_N35_P35 = 0x7F;    // -35～35V
        public const Int32 DAM3000M_VOLT_N0_P400MV = 0x76;  // 0～+400mV
        public const Int32 DAM3000M_VOLT_N20_P0V = 0x8E;    // -20～0V
        public const Int32 DAM3000M_VOLT_N20_P20V = 0x8F;   // -20～20V

        public const Int32 DAM3000M_VOLT_YH_N10_P10 = 0x08;     // 研华协议下-10～+10V
        public const Int32 DAM3000M_VOLT_YH_N5_P5 = 0x09;       // 研华协议下-5～+5V
        public const Int32 DAM3000M_VOLT_YH_N1_P1 = 0x0A;       // 研华协议下-1～+1V
        public const Int32 DAM3000M_VOLT_YH_N500_P500V = 0x0B;  // 研华协议下-500～+500mV
        public const Int32 DAM3000M_VOLT_YH_N150_P150V = 0x0C;  // 研华协议下-150～+150mV
        public const Int32 DAM3000M_VOLT_YH_N0_P10 = 0x48;      // 研华协议下0～+10V
        public const Int32 DAM3000M_VOLT_YH_N0_P5 = 0x49;       // 研华协议下0～+5V
        public const Int32 DAM3000M_VOLT_YH_N0_P1 = 0x4A;       // 研华协议下0～+1V
        public const Int32 DAM3000M_VOLT_YH_N15_P15 = 0x15;     // 研华协议下-15～+15V
        public const Int32 DAM3000M_VOLT_YH_N0_P15 = 0x55;      // 研华协议下0～+15V
        public const Int32 DAM3000M_VOLT_YH_N0_P25 = 0x45;      // 研华协议下0～+2.5V
        public const Int32 DAM3000M_VOLT_YH_N25_P25 = 0x05;     // 研华协议下-2.5～+2.5V

        // 模拟量输入类型(电流类型) 供DAM3000M_SetModeAD函数中的lMode参数使用
        public const Int32 DAM3000M_CUR_N0_P10 = 0x00;          // 0～10mA
        public const Int32 DAM3000M_CUR_N20_P20 = 0x0A;         // -20～+20mA
        public const Int32 DAM3000M_CUR_N0_P20 = 0x0B;          // 0～20mA
        public const Int32 DAM3000M_CUR_N4_P20 = 0x0C;          // 4～20mA
        public const Int32 DAM3000M_CUR_N0_P22 = 0x80;          // 0～22mA
        public const Int32 DAM3000M_CUR_N10_P10A = 0x85;        // -10～+10A
        public const Int32 DAM3000M_CUR_N0_P10A = 0x86;         // 0～+10A
        public const Int32 DAM3000M_CUR_N10_P0A = 0x6F;         // -10～+0A
        public const Int32 DAM3000M_CUR_N50_P50A = 0x87;        // -50～+50A
        public const Int32 DAM3000M_CUR_N0_P50A = 0x88;         // 0～+50A
        public const Int32 DAM3000M_CUR_YH_N0_P20A = 0x4D;      // 研华协议下0～20mA
        public const Int32 DAM3000M_CUR_YH_N4_P20A = 0x07;      // 研华协议下4～20mA
        public const Int32 DAM3000M_CUR_YH_N20_P20A = 0x0D;     // 研华协议下-20～20mA
        public const Int32 DAM3000M_CUR_N0_P200 = 0x73;         // 0～200mA
        public const Int32 DAM3000M_CUR_N200_P0 = 0x7C;         // -200～0mA
        public const Int32 DAM3000M_CUR_N200_P200 = 0x7D;       // -200～200mA
        public const Int32 DAM3000M_CUR_N0_P500 = 0x74;         // 0～500mA
        public const Int32 DAM3000M_CUR_N500_P0 = 0x7A;         // -500～0mA
        public const Int32 DAM3000M_CUR_N500_P500 = 0x7B;       // -500～500mA
        public const Int32 DAM3000M_CUR_N0_P1500 = 0x75;        // 0～1500mA(0~1.5A)
        public const Int32 DAM3000M_CUR_N1500_P0 = 0x78;        // -1500～0mA
        public const Int32 DAM3000M_CUR_N1500_P1500 = 0x79;     // -1500～1500mA
        public const Int32 DAM3000M_CUR_N0_P400UA = 0x77;       // 0～+400uA
        public const Int32 DAM3000M_CUR_N0_P1000 = 0x6C;        // 0 ～ 1000mA
        public const Int32 DAM3000M_CUR_N1000_P0 = 0x6D;        // -1000 ～ 0mA
        public const Int32 DAM3000M_CUR_N1000_P1000 = 0x6E;     // -1000 ～ 1000mA
        public const Int32 DAM3000M_CUR_YH_N0_P1 = 0x6C;        // 研华协议下0 ～ 1A
        public const Int32 DAM3000M_CUR_YH_N1_P1 = 0x6E;        // 研华协议下-1 ～ 1A

        // 模拟量输入类型(电流类型) 供DAM3000M_SetModeAD函数中的lMode参数使用
        public const Int32 DAM3000M_R_N0_R400Ω = 0x88; // 远传压力表电阻   0～400Ω

        // 模拟量输入类型(热电偶类型) 供DAM3000M_SetModeAD函数中的lMode参数使用
        public const Int32 DAM3000M_TMC_J = 0x10;   // J型热电偶   0～1200℃
        public const Int32 DAM3000M_TMC_K = 0x11;   // K型热电偶   0～1300℃
        public const Int32 DAM3000M_TMC_T = 0x12;   // T型热电偶 -200～400℃
        public const Int32 DAM3000M_TMC_E = 0x13;   // E型热电偶   0～1000℃
        public const Int32 DAM3000M_TMC_R = 0x14;   // R型热电偶 0～1700℃
        public const Int32 DAM3000M_TMC_S = 0x15;   // S型热电偶 0～1768℃
        public const Int32 DAM3000M_TMC_B = 0x16;   // B型热电偶 0～1800℃
        public const Int32 DAM3000M_TMC_N = 0x17;   // N型热电偶   0～1300℃
        public const Int32 DAM3000M_TMC_C = 0x18;   // C型热电偶   0～2090℃
        public const Int32 DAM3000M_TMC_WRE = 0x19; // 钨铼5-钨铼26 0～2310℃
        public const Int32 DAM3000M_TMC_K_EX = 0x70;// K型热电偶   -40～1300℃
        public const Int32 DAM3000M_TMC_B_N = 0x71; // B型热电偶 250～1800℃
        public const Int32 DAM3000M_NTC_10K = 0x90;  //NTC10K(-40～150℃)
        public const Int32 DAM3000M_NTC_100K = 0x91; //NTC100K(-40～150℃)

        // 模拟量输入类型(热电阻类型) 供DAM3000M_SetModeAD函数中的lMode参数使用
        public const Int32 DAM3000M_RTD_PT100_385_N200_P600 = 0x20; // Pt100(385)热电阻 -200℃～600℃
        public const Int32 DAM3000M_RTD_PT100_385_N100_P100 = 0x21; // Pt100(385)热电阻 -100℃～100℃
        public const Int32 DAM3000M_RTD_PT100_385_N0_P100 = 0x22;   // Pt100(385)热电阻    0℃～100℃
        public const Int32 DAM3000M_RTD_PT100_385_N0_P200 = 0x23;   // Pt100(385)热电阻    0℃～200℃
        public const Int32 DAM3000M_RTD_PT100_385_N0_P600 = 0x24;   // Pt100(385)热电阻    0℃～600℃
        public const Int32 DAM3000M_RTD_PT100_3916_N200_P600 = 0x25;// Pt100(3916)热电阻-200℃～600℃
        public const Int32 DAM3000M_RTD_PT100_3916_N100_P100 = 0x26;// Pt100(3916)热电阻-100℃～100℃
        public const Int32 DAM3000M_RTD_PT100_3916_N0_P100 = 0x27;  // Pt100(3916)热电阻   0℃～100℃
        public const Int32 DAM3000M_RTD_PT100_3916_N0_P200 = 0x28;  // Pt100(3916)热电阻   0℃～200℃
        public const Int32 DAM3000M_RTD_PT100_3916_N0_P600 = 0x29;  // Pt100(3916)热电阻   0℃～600℃
        public const Int32 DAM3000M_RTD_PT1000 = 0x30;              // Pt1000热电阻     -200℃～600℃
        public const Int32 DAM3000M_RTD_CU50 = 0x40;                // Cu50热电阻        -50℃～150℃
        public const Int32 DAM3000M_RTD_CU100 = 0x41;               // Cu100热电阻       -50℃～150℃
        public const Int32 DAM3000M_RTD_BA1 = 0x42;                 // BA1热电阻        -200℃～650℃
        public const Int32 DAM3000M_RTD_BA2 = 0x43;                 // BA2热电阻        -200℃～650℃
        public const Int32 DAM3000M_RTD_G53 = 0x44;                 // G53热电阻         -50℃～150℃
        public const Int32 DAM3000M_RTD_Ni50 = 0x45;                // Ni50热电阻        100℃
        public const Int32 DAM3000M_RTD_Ni508 = 0x46;               // Ni508热电阻         0℃～100℃
        public const Int32 DAM3000M_RTD_Ni1000 = 0x47;              // Ni1000热电阻      -60℃～160℃
        public const Int32 DAM3000M_RTD_103AT = 0x60;               // 103AT电阻		  -50℃～110℃

        //########################## AO ###################################
        // 模块量输出斜率类型	供DAM3000M_SetModeDA函数中的参数 lType 使用
        public const Int32 DAM3000M_SLOPE_IMMEDIATE = 0x00; // Immediate
        public const Int32 DAM3000M_SLOPE_POINT125 = 0x01;  // 0.125 mA/S
        public const Int32 DAM3000M_SLOPE_POINT25 = 0x02;   // 0.25  mA/S
        public const Int32 DAM3000M_SLOPE_POINT5 = 0x03;    // 0.5  mA/S
        public const Int32 DAM3000M_SLOPE_1 = 0x04;         // 1.0  mA/S
        public const Int32 DAM3000M_SLOPE_2 = 0x05;         // 2.0  mA/S
        public const Int32 DAM3000M_SLOPE_4 = 0x06;         // 4.0  mA/S
        public const Int32 DAM3000M_SLOPE_8 = 0x07;         // 8.0  mA/S
        public const Int32 DAM3000M_SLOPE_16 = 0x08;        // 16.0  mA/S
        public const Int32 DAM3000M_SLOPE_32 = 0x09;        // 32.0  mA/S
        public const Int32 DAM3000M_SLOPE_64 = 0x0A;        // 64.0  mA/S
        public const Int32 DAM3000M_SLOPE_128 = 0x0B;       // 128.0  mA/S
        public const Int32 DAM3000M_SLOPE_256 = 0x0C;       // 256.0  mA/S
        public const Int32 DAM3000M_SLOPE_512 = 0x0D;       // 512.0  mA/S
        public const Int32 DAM3000M_SLOPE_1024 = 0x0E;      // 1024.0  mA/S
        public const Int32 DAM3000M_SLOPE_2048 = 0x0F;      // 2048.0  mA/S

        //########################## DI ###################################
        // DI工作模式 供DAM3000M_DISetMode和DAM3000M_DIGetMode函数中的lpBuffer参数使用
        public const Int32 DAM3000M_DI_MODE_INPUT = 0x00;    // DI工作模式,0:DI输入
        public const Int32 DAM3000M_DI_MODE_CNT = 0x01;      // DI工作模式,1:计数
        public const Int32 DAM3000M_DI_MODE_LATCH_L_H = 0x02;// DI工作模式,2:低到高锁存
        public const Int32 DAM3000M_DI_MODE_LATCH_H_L = 0x03;// DI工作模式,3:高到低锁存
        public const Int32 DAM3000M_DI_MODE_FREQ = 0x04;     // DI工作模式,4:频率工作模式

        // DI计数方式 供DAM3000M_SetDeviceMode函数中的lEdgeMode参数使用
        public const Int32 DAM3000M_DIR_FALLING = 0x00;// 下降沿
        public const Int32 DAM3000M_DIR_RISING = 0x01; // 上升沿

        //##########################DO###################################
        // DO工作模式 供DAM3000M_DOSetMode和DAM3000M_DOGetMode函数中的lMode参数使用
        public const Int32 DAM3000M_DO_MODE_OUTPUT_IMMED = 0x00;    // DO工作模式,0:立即输出模式
        public const Int32 DAM3000M_DO_MODE_OUTPUT_DELAY_L_H = 0x01;// DO工作模式,1:低到高延时输出
        public const Int32 DAM3000M_DO_MODE_OUTPUT_DELAY_H_L = 0x02;// DO工作模式,2:高到低延时输出
        public const Int32 DAM3000M_DO_MODE_OUTPUT_PULSE = 0x03;    // DO工作模式,3:连续脉冲输出

        // DO脉冲输出模式 供DAM3000M_DOSetPulseMode和DAM3000M_DOGetPulseMode函数中的lpBuffer参数使用
        public const Int32 DAM3000M_DO_PULSE_MODE_CONTINUE = 0x00;   // DO脉冲冲输出模式,0:继续输出
        public const Int32 DAM3000M_DO_PULSE_MODE_NONCONTINUE = 0x01;// DO脉冲冲输出模式,1:非继续输出

        //########################## 计数器 ###################################
        // 模块的工作模式 供DAM3000M_SetDevWorkMode函数中的lMode参数使用
        public const Int32 DAM3000M_WORKMODE_CNT = 0x00; // 计数器
        public const Int32 DAM3000M_WORKMODE_FREQ = 0x01;// 频率器

        // 计数器/频率的输入方式 供DAM3000M_PARA_CNT结构体中的lInputMode参数使用
        public const Int32 DAM3000M_UNISOLATED = 0x00; // 非隔离
        public const Int32 DAM3000M_ISOLATED = 0x01;   // 隔离

        // 门槛值状态 供DAM3000M_PARA_CNT结构体中的GateSts参数使用
        public const Int32 DAM3000M_GATE_LOW = 0x00; // 门槛值为低电平
        public const Int32 DAM3000M_GATE_HIGH = 0x01;// 门槛值为高电平
        public const Int32 DAM3000M_GATE_NULL = 0x02;// 门槛值无效

        // 报警方式 供DAM3000M_CNT_ALARM结构体中的AlarmMode参数使用
        public const Int32 CNT_ALARM_MODE0 = 0x00;// 报警方式0	0通道-1通道上限
        public const Int32 CNT_ALARM_MODE1 = 0x01;// 报警方式1	0通道上限 / 上上限

        // 报警方式0使能 供DAM3000M_CNT_ALARM结构体中的EnableAlarm0 和 EnableAlarm1参数使用
        public const Int32 CNT_ALAMODE0_DISABLE = 0x00;// 报警方式0禁止报警
        public const Int32 CNT_ALAMODE0_ENABLE = 0x01; // 报警方式0允许报警

        // 报警方式1使能 供DAM3000M_CNT_ALARM结构体中的EnableAlarm0参数使用
        public const Int32 CNT_ALAMODE1_DISABLE = 0x00;// 报警方式1 计数器0 禁止报警
        public const Int32 CNT_ALAMODE1_INSTANT = 0x01;// 报警方式1 计数器0 瞬间报警允许
        public const Int32 CNT_ALAMODE1_LATCH = 0x02;  // 报警方式1 计数器0 闭锁报警允许

        // 滤波状态使能 供DAM3000M_PARA_FILTER结构体中的bEnableFilter参数使用
        public const Int32 DAM3000M_FILTER_DISABLE = 0x00;// 禁止滤波
        public const Int32 DAM3000M_FILTER_ENABLE = 0x01; // 允许滤波
        //-----------------------------------------------------

        //########################## 电量 ###################################
        // 获得电量值 供DAM3000M_GetEnergyVal中的lAanlogType参数使用
        public const Int32 DAM3000M_GET_I_RMS = 0x00;       // 获得电流有效值
        public const Int32 DAM3000M_GET_V_RMS = 0x01;       // 获得电压有效值
        public const Int32 DAM3000M_GET_PHVOLTAGE = 0x01;   // 获得电压有效值、相电压
        public const Int32 DAM3000M_GET_POWER = 0x02;       // 获得有功功率
        public const Int32 DAM3000M_GET_VAR = 0x03;         // 获得无功功率
        public const Int32 DAM3000M_GET_VA = 0x04;          // 获得视在功率
        public const Int32 DAM3000M_GET_WATTHR = 0x05;      // 获得正相有功电度
        public const Int32 DAM3000M_GET_RWATTHR = 0x06;     // 获得反相有功电度
        public const Int32 DAM3000M_GET_VARHR = 0x07;       // 获得正相无功电度
        public const Int32 DAM3000M_GET_RVARHR = 0x08;      // 获得反相无功电度
        public const Int32 DAM3000M_GET_PF = 0x09;          // 获得功率因数
        public const Int32 DAM3000M_GET_FREQ = 0x0A;        // 获得输入信号频率
        public const Int32 DAM3000M_GET_VAWATTHR = 0x0B;    // 获得电度
        public const Int32 DAM3000M_GET_LINEVOLTAGE = 0x0C; // 获得线电压

        //########################## ADC采样速率 ###################################
        public const Int32 DAM3000M_ADCRATE_500 = 0x00;     // 500Hz
        public const Int32 DAM3000M_ADCRATE_1K = 0x01;      // 1KHz
        public const Int32 DAM3000M_ADCRATE_2K = 0x02;      // 2KHz
        public const Int32 DAM3000M_ADCRATE_10 = 0x03;      // 10Hz
        public const Int32 DAM3000M_ADCRATE_100 = 0x04;     // 100Hz

        //###########################################################################
        // ****************** 设备基本信息的结构体 ******************************
        public struct DAM3000M_DEVICE_INFO
        {
            public Int32 DeviceType;		// 模块类型 
            public Int32 TypeSuffix;		// 类型后缀
            public Int32 ModusType;		    // M
            public Int32 VesionID;		    // 版本号(2字节)
            public Int32 DeviceID;		    // 模块ID号(SetDeviceInfo时，为设备的新ID)
            public Int32 BaudRate;		    // 波特率
            public Int32 bParity;		    // 0:无校验 1:偶校验 2:奇校验(只有这3个值才能表示该模块有可能支持此功能，设置时此值不为0 1 2表示不设置此参数)
        }

        //###########################################################################################
        //####################### 设备对象管理函数 ##################################################
        //###########################################################################################

        //****************************************************************************	
        // 说明：创建设备对象
        // 参数：返回句柄，供与模块通信使用
        //****************************************************************************	
        [DllImport("DAM3000M_32.DLL")]
        public static extern IntPtr DAM3000M_CreateDevice(
                                        Int32 lPortNum);// 串口号

        //****************************************************************************	
        // 说明：初始化串口（初始与模块之间的通信参数）
        // 参数：波特率、奇偶校验、超时时间
        //****************************************************************************
        [DllImport("DAM3000M_32.DLL")]
        public static extern Boolean DAM3000M_InitDevice(
                                                            IntPtr hDevice,                         // 设备对象句柄
                                                            Int32 lBaud,						    // 波特率
                                                            Int32 lDataBits,						// 数据位
                                                            Int32 lStopBits,						// 停止位
                                                            Int32 lParity,							// 校验方式
                                                            Int32 lTimeOut,			                // 超时时间，主要用于接收数据，如果为-1 则使用默认超时时间
                                                            Int32 lFlowControl);                    // 超时时间，主要用于接收数据，如果为-1 则使用默认超时时间
        //****************************************************************************	
        // 说明：释放设备对象（串口），执行后无法操作串口
        // 参数：句柄
        //****************************************************************************	
        [DllImport("DAM3000M_32.DLL")]
        public static extern Boolean DAM3000M_ReleaseDevice(IntPtr hDevice);
        //****************************************************************************	
        // 说明：复位设置（恢复出厂设置）
        // 功能码：0x10
        // 地址：0x207 
        //****************************************************************************	
        [DllImport("DAM3000M_32.DLL")]
        public static extern Boolean DAM3000M_ResetDevice(
                                    IntPtr hDevice,	// 设备对象句柄
                                    Int32 lDeviceID,	// 设备地址
                                    Boolean bReset);	// 复位设备标志 =TRUE 复位 =FALSE 无操作

        //****************************************************************************	
        // 使模块进入(退出)校准模式（保留功能，不推荐用户使用）
        // 功能码：0x10
        // 地址：0x208 
        //****************************************************************************	
        [DllImport("DAM3000M_32.DLL")]
        public static extern Boolean DAM3000M_EnterCalibration(
                                    IntPtr hDevice,	// 设备对象句柄
                                    Int32 lDeviceID,	// 设备地址
                                    Boolean bCalibrate);// 进入校准标志  =TRUE 进入校准模式 =FALSE 不操作

        //###########################################################################################
        //################################### 模块信息取得/修改函数 #################################
        //###########################################################################################
        //****************************************************************************	
        // 读取模块信息(类型、地址、波特率、校验模式等)
        // 功能码：0x03
        // 地址：0x80 
        //****************************************************************************	
        [DllImport("DAM3000M_32.DLL")]
        public static extern Boolean DAM3000M_GetDeviceInfo(
                                                            IntPtr hDevice,					// 设备对象句柄
                                                            Int32 lDeviceID,				// 设备地址
                                                            ref DAM3000M_DEVICE_INFO pInfo);// 设备信息
        //****************************************************************************	
        // 修改模块信息(地址、波特率、校验)
        // 功能码：0x10
        // 地址：0x80 
        //****************************************************************************	
        [DllImport("DAM3000M_32.DLL")]
        public static extern Boolean DAM3000M_SetDeviceInfo(
                                                            IntPtr hDevice,					// 设备对象句柄
                                                            Int32 lDeviceID,				// 设备地址
                                                            ref DAM3000M_DEVICE_INFO Info);	// 设备信息

        //###########################################################################################
        //####################################### Modus 功能操作函数 ################################
        //#如函数无特别说明，默认的数据通信方式为：寄存器外小端，寄存器内大端###################
        //#即：寄存器内数据先发送高位；当两个寄存器组成一个32位数据时，低16位在寄存器小地址####
        //#具体寄存器地址，请遵照模块用户手册寄存器定义###########################################

        //###########################################################################################

        // ## 01功能码 ######
        // ## 01功能码 ######
        //****************************************************************************	
        // 读继电器状态
        // 功能码：0x01
        // 返回值：TRUE=成功 FALSE=失败
        // 参数：
        // 		hDevice [IN]设备句柄，由CreateDevice创建
        // 		lDeviceID [IN]设备ID号
        // 		addr [IN]通信地址
        // 		len [IN]读取寄存器个数
        // 		flag [OUT]返回读到的寄存器的数据（0或1）
        //****************************************************************************
        [DllImport("DAM3000M_32.DLL")]
        public static extern Boolean DAM3000M_ReadCoils(
                                    IntPtr hDevice,
                                    Int32 lDeviceID,
                                    Int32 addr,
                                    Int32 len,
                                    Byte[] flag);

        // ## 02功能码 ######
        // ## 02功能码 ######
        //****************************************************************************	
        // 读开关量输入
        // 功能码：0x02
        // 返回值：TRUE=成功 FALSE=失败
        // 参数：
        // 		hDevice [IN]设备句柄，由CreateDevice创建
        // 		lDeviceID [IN]设备ID号
        // 		addr [IN]通信地址
        // 		len [IN]读取寄存器个数
        // 		state [OUT]返回读到的寄存器的数据（0或1）
        //****************************************************************************	
        [DllImport("DAM3000M_32.DLL")]
        public static extern Boolean DAM3000M_ReadDiscretes(
                                    IntPtr hDevice,
                                    Int32 lDeviceID,
                                    Int32 addr,
                                    Int32 len,
                                    Byte[] state);

        // ## 03功能码 ######
        // ## 03功能码 ######
        //****************************************************************************	
        // 读保持寄存器，返回数据8位无符号整形
        // 功能码：0x03
        // 返回值：TRUE=成功 FALSE=失败
        // 参数：
        // 		hDevice [IN] 设备句柄，由CreateDevice创建
        // 		lDeviceID [IN] 设备ID号
        // 		addr [IN] 通信地址
        // 		len [IN] 读取寄存器个数
        // 		buf [OUT] 返回读到的寄存器的数据,，每个寄存器占用2个元素。
        //				  buf[0]表示第一个寄存器的高位，buf[1]表示第一个寄存器的低位，以此类推。
        // 				  如，第一个寄存器数据内容为0x1234，则buf[0]=0x12 buf[1]=0x34。 	
        //****************************************************************************	
        [DllImport("DAM3000M_32.DLL")]
        public static extern Boolean DAM3000M_ReadMultiRegs(
                                    IntPtr hDevice,
                                    Int32 lDeviceID,
                                    Int32 addr,
                                    Int32 len,
                                    Byte[] buf);

        //****************************************************************************	
        // 读保持寄存器，返回数据16位无符号整形
        // 功能码：0x03
        // 返回值：TRUE=成功 FALSE=失败
        // 参数：
        // 		hDevice [IN] 设备句柄，由CreateDevice创建
        // 		lDeviceID [IN] 设备ID号
        // 		addr [IN] 通信地址
        // 		len [IN] 读取数据个数
        // 		buf [OUT] 返回读到的寄存器的数据，每个寄存器占用一个元素。
        //				  buf[0]表示第一个地址对应寄存器的值，以此类推。
        //				  如，第一个寄存器的数据内容是0x1234，则返回的buf[0]=0x1234
        //****************************************************************************	
        [DllImport("DAM3000M_32.DLL")]
        public static extern Boolean DAM3000M_ReadMultiRegsUInt16(
                                    IntPtr hDevice,
                                    Int32 lDeviceID,
                                    Int32 addr,
                                    Int32 len,
                                    UInt16[] buf);

        //****************************************************************************	
        // 读保持寄存器，返回数据32位无符号整形
        // 功能码：0x03
        // 返回值：TRUE=成功 FALSE=失败
        // 参数：
        // 		hDevice [IN] 设备句柄，由CreateDevice创建
        // 		lDeviceID [IN] 设备ID号
        // 		addr [IN] 通信地址
        // 		len [IN] 读取数据个数
        // 		buf [OUT] 返回读到的寄存器的数据，每两个寄存器值组成一个元素值。
        //				  buf[0]表示第一个地址和第二个地址对应寄存器的值，以此类推。
        //				  如，第一个寄存器的数据内容是0x1234，第二个寄存器的数据内容是0x5678，则返回的buf[0]=0x56781234
        //****************************************************************************	
        [DllImport("DAM3000M_32.DLL")]
        public static extern Boolean DAM3000M_ReadMultiRegsUInt32(
                                    IntPtr hDevice,
                                    Int32 lDeviceID,
                                    Int32 addr,
                                    Int32 len,
                                    UInt32[] buf);

        //****************************************************************************	
        // 读保持寄存器，返回数据32位浮点数
        // 功能码：0x03
        // 返回值：TRUE=成功 FALSE=失败
        // 参数：
        // 		hDevice [IN] 设备句柄，由CreateDevice创建
        // 		lDeviceID [IN] 设备ID号
        // 		addr [IN] 通信地址
        // 		len [IN] 读取数据个数
        // 		buf [OUT] 返回读到的寄存器的数据，每两个寄存器值组成一个元素值。
        //				  buf[0]表示第一个地址和第二个地址对应寄存器的值，以此类推。
        //				  如，第一个寄存器的数据内容是0x1234，第二个寄存器的数据内容是0x5678，则返回的buf[0]=
        //****************************************************************************	
        [DllImport("DAM3000M_32.DLL")]
        public static extern Boolean DAM3000M_ReadMultiRegsFloat32(
                                    IntPtr hDevice,
                                    Int32 lDeviceID,
                                    Int32 addr,
                                    Int32 len,
                                    Single[] buf);

        //****************************************************************************	
        // 读保持寄存器，返回数据32位无符号整形，寄存器外为大端发送
        // 功能码：0x03
        // 返回值：TRUE=成功 FALSE=失败
        // 参数：
        // 		hDevice [IN] 设备句柄，由CreateDevice创建
        // 		lDeviceID [IN] 设备ID号
        // 		addr [IN] 通信地址
        // 		len [IN] 读取数据个数
        // 		buf [OUT] 返回读到的寄存器的数据，每两个寄存器值组成一个元素值。
        //				  buf[0]表示第一个地址和第二个地址对应寄存器的值，以此类推。
        //				  如，第一个寄存器的数据内容是0x1234，第二个寄存器的数据内容是0x5678，则返回的buf[0]=0x12345678
        //****************************************************************************	
        [DllImport("DAM3000M_32.DLL")]
        public static extern Boolean DAM3000M_ReadMultiRegsUInt32_BigEndian(
                                    IntPtr hDevice,
                                    Int32 lDeviceID,
                                    Int32 addr,
                                    Int32 len,
                                    UInt32[] buf);

        // ## 04功能码 ######
        // ## 04功能码 ######
        //****************************************************************************	
        // 读输入寄存器，返回数据8位无符号整形
        // 功能码：0x04
        // 返回值：TRUE=成功 FALSE=失败
        // 参数：
        // 		hDevice [IN]设备句柄，由CreateDevice创建
        // 		lDeviceID [IN]设备ID号
        // 		addr [IN]通信地址
        // 		len [IN]读取数据个数
        // 		buf [OUT] 返回读到的寄存器的数据,，每个寄存器占用2个元素。
        //				  buf[0]表示第一个寄存器的高位，buf[1]表示第一个寄存器的低位，以此类推。
        // 				  如，第一个寄存器数据内容为0x1234，则buf[0]=0x12 buf[1]=0x34。 	
        //****************************************************************************	
        [DllImport("DAM3000M_32.DLL")]
        public static extern Boolean DAM3000M_ReadInputRegs(
                                    IntPtr hDevice,
                                    Int32 lDeviceID,
                                    Int32 addr,
                                    Int32 len,
                                    Byte[] buf);

        //****************************************************************************	
        // 读输入寄存器，返回数据16位无符号整形
        // 功能码：0x04
        // 返回值：TRUE=成功 FALSE=失败
        // 参数：
        // 		hDevice [IN] 设备句柄，由CreateDevice创建
        // 		lDeviceID [IN] 设备ID号
        // 		addr [IN] 通信地址
        // 		len [IN] 读取数据个数
        // 		buf [OUT] 返回读到的寄存器的数据，每个寄存器占用一个元素。
        //				  buf[0]表示第一个地址对应寄存器的值，以此类推。
        //				  如，第一个寄存器的数据内容是0x1234，则返回的buf[0]=0x1234
        //****************************************************************************	
        [DllImport("DAM3000M_32.DLL")]
        public static extern Boolean DAM3000M_ReadInputRegsUInt16(
                                    IntPtr hDevice,
                                    Int32 lDeviceID,
                                    Int32 addr,
                                    Int32 len,
                                    UInt16[] buf);

        //****************************************************************************	
        // 读输入寄存器，返回数据32位无符号整形
        // 功能码：0x04
        // 返回值：TRUE=成功 FALSE=失败
        // 参数：
        // 		hDevice [IN] 设备句柄，由CreateDevice创建
        // 		lDeviceID [IN] 设备ID号
        // 		addr [IN] 通信地址
        // 		len [IN] 读取数据个数
        // 		buf [OUT] 返回读到的寄存器的数据，每两个寄存器占用一个元素。
        //				  buf[0]表示第一个地址和第二个地址对应寄存器的值，以此类推。
        //				  如，第一个寄存器的数据内容是0x1234，第二个寄存器的数据内容是0x5678，则返回的buf[0]=0x56781234
        //****************************************************************************	
        [DllImport("DAM3000M_32.DLL")]
        public static extern Boolean DAM3000M_ReadInputRegsUInt32(
                                    IntPtr hDevice,
                                    Int32 lDeviceID,
                                    Int32 addr,
                                    Int32 len,
                                    UInt32[] buf);

        //****************************************************************************	
        // 读输入寄存器,返回数据32位浮点数
        // 功能码：0x04
        // 返回值：TRUE=成功 FALSE=失败
        // 参数：
        // 		hDevice [IN] 设备句柄，由CreateDevice创建
        // 		lDeviceID [IN] 设备ID号
        // 		addr [IN] 通信地址
        // 		len [IN] 读取数据个数
        // 		buf [OUT] 返回读到的寄存器的数据，每两个寄存器占用一个元素。
        //				  buf[0]表示第一个地址和第二个地址对应寄存器的值，以此类推。
        //				  如，第一个寄存器的数据内容是0x1234，第二个寄存器的数据内容是0x5678，则返回的buf[0]=
        //****************************************************************************	
        [DllImport("DAM3000M_32.DLL")]
        public static extern Boolean DAM3000M_ReadInputRegsFloat32(
                                    IntPtr hDevice,
                                    Int32 lDeviceID,
                                    Int32 addr,
                                    Int32 len,
                                    Single[] buf);

        //****************************************************************************	
        // 设置单个继电器
        // 功能码：0x05
        //****************************************************************************	
        [DllImport("DAM3000M_32.DLL")]
        public static extern Boolean DAM3000M_WriteCoil_old(
                                    IntPtr hDevice,
                                    Int32 lDeviceID,
                                    Int32 addr,
                                    Byte status);

        // ## 05功能码 ######
        // ## 05功能码 ######
        //****************************************************************************
        // 设置单个继电器
        // 功能码：0x05
        // 返回值：TRUE=成功 FALSE=失败
        // 参数：
        // 		hDevice [IN] 设备句柄，由CreateDevice创建
        // 		lDeviceID [IN] 设备ID号
        // 		addr [IN] 通信地址
        // 		status [IN] 写入寄存器的值，0或1
        //****************************************************************************
        [DllImport("DAM3000M_32.DLL")]
        public static extern Boolean DAM3000M_WriteCoil(
                                    IntPtr hDevice,
                                    Int32 lDeviceID,
                                    Int32 addr,
                                    Byte status);

        // ## 0F功能码 ######
        // ## 0F功能码 ######
        //****************************************************************************	
        // 设置多个继电器
        // 功能码：0x0F
        // 返回值：TRUE=成功 FALSE=失败
        // 参数：
        // 		hDevice [IN] 设备句柄，由CreateDevice创建
        // 		lDeviceID [IN] 设备ID号
        // 		addr [IN] 通信地址
        // 		len [IN] 读取数据个数
        // 		status [IN] 写入寄存器的值，0或1
        //****************************************************************************	
        [DllImport("DAM3000M_32.DLL")]
        public static extern Boolean DAM3000M_ForceMultiCoils(
                                    IntPtr hDevice,
                                    Int32 lDeviceID,
                                    Int32 addr,
                                    Int32 len,
                                    Byte[] bDOState);

        // ## 10功能码 ######
        // ## 10功能码 ######
        //****************************************************************************	
        // 设置单个保持寄存器
        // 功能码：0x10
        // 返回值：TRUE=成功 FALSE=失败
        // 参数：
        // 		hDevice [IN] 设备句柄，由CreateDevice创建
        // 		lDeviceID [IN] 设备ID号
        // 		addr [IN] 通信地址
        // 		len [IN] 读取数据个数
        // 		val [IN] 写入寄存器的数据
        //****************************************************************************	
        [DllImport("DAM3000M_32.DLL")]
        public static extern Boolean DAM3000M_WriteSingleReg(
                                    IntPtr hDevice,
                                    Int32 lDeviceID,
                                    Int32 addr,
                                    UInt16 val);

        //****************************************************************************	
        // 设置多个保持寄存器
        // 功能码：0x10
        // 返回值：TRUE=成功 FALSE=失败
        // 参数：
        // 		hDevice [IN] 设备句柄，由CreateDevice创建
        // 		lDeviceID [IN] 设备ID号
        // 		addr [IN] 通信地址
        // 		len [IN] 读取数据个数
        // 		buf [IN] 写入寄存器的数据
        //				 数据赋值示例：写入第一个寄存器的值为0x1234，那么buf[0]=0x12 buf[1]=0x34
        //****************************************************************************	
        [DllImport("DAM3000M_32.DLL")]
        public static extern Boolean DAM3000M_WriteMultiRegs(
                                    IntPtr hDevice,
                                    Int32 lDeviceID,
                                    Int32 addr,
                                    Int32 len,
                                    Byte[] buf);

        //****************************************************************************	
        // 设置多个保持寄存器
        // 功能码：0x10
        // 返回值：TRUE=成功 FALSE=失败
        // 参数：
        // 		hDevice [IN] 设备句柄，由CreateDevice创建
        // 		lDeviceID [IN] 设备ID号
        // 		addr [IN] 通信地址
        // 		len [IN] 读取数据个数
        // 		buf [IN] 写入寄存器的数据
        // 				数据赋值示例：写入寄存器的值为0x1234，那么buf[0]=0x12 buf[1]=0x34
        //****************************************************************************
        [DllImport("DAM3000M_32.DLL")]
        public static extern Boolean DAM3000M_WriteMultiRegsUInt16(
                                    IntPtr hDevice,
                                    Int32 lDeviceID,
                                    Int32 addr,
                                    Int32 len,
                                    UInt16[] buf);

        //****************************************************************************	
        // 设置多个保持寄存器
        // 功能码：0x10
        // 返回值：TRUE=成功 FALSE=失败
        // 参数：
        // 		hDevice [IN] 设备句柄，由CreateDevice创建
        // 		lDeviceID [IN] 设备ID号
        // 		addr [IN] 通信地址
        // 		len [IN] 读取数据个数
        // 		buf [IN] 写入寄存器的数据
        // 				数据赋值示例：写入第一个寄存器的值为0x1234，第二个寄存器的值为0x5678，那么buf[0]=0x56781234
        //****************************************************************************	
        [DllImport("DAM3000M_32.DLL")]
        public static extern Boolean DAM3000M_WriteMultiRegsUInt32(
                                    IntPtr hDevice,
                                    Int32 lDeviceID,
                                    Int32 addr,
                                    Int32 len,
                                    UInt32[] buf);

        //****************************************************************************	
        // 设置多个保持寄存器
        // 功能码：0x10
        // 返回值：TRUE=成功 FALSE=失败
        // 参数：
        // 		hDevice [IN] 设备句柄，由CreateDevice创建
        // 		lDeviceID [IN] 设备ID号
        // 		addr [IN] 通信地址
        // 		len [IN] 读取数据个数
        // 		buf [OUT] 返回读到的寄存器的数据，每两个寄存器值组成一个元素值。
        //				  buf[0]表示第一个地址和第二个地址对应寄存器的值，以此类推。
        //				  如，第一个寄存器的数据内容是0x1234，第二个寄存器的数据内容是0x5678，则返回的buf[0]=0x12345678
        //****************************************************************************	
        [DllImport("DAM3000M_32.DLL")]
        public static extern Boolean DAM3000M_WriteMultiRegsUInt32_BigEndian(
                                    IntPtr hDevice,
                                    Int32 lDeviceID,
                                    Int32 addr,
                                    Int32 len,
                                    UInt32[] buf);
    }
}