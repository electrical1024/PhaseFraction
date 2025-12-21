namespace PhaseFraction
{
    class Algorithm
    {

        double CalculateQGas(double d, double deltaH, double deltaT)
        {
            return (d * d * deltaH) / (4 * deltaT);
        }

         double CalculateN(double P, double V, double R, double T)
        {
            return (P * V) / (R * T);
        }

         double CalculateV0(double Vm, double Pm, double T0, double P0, double Tm)
        {
            return Vm * (Pm * T0) / (P0 * Tm);
        }

         double CalculateQ0(double QGas, double Pm, double T0, double P0, double Tm)
        {
            return QGas * (Pm * T0) / (P0 * Tm);
        }

         double CalculateQWater(double d, double deltaH1, double deltaT1)
        {            return (d * d * deltaH1) / (4 * deltaT1);
        }

         double CalculateQOil(double d, double deltaH2, double deltaT2)
        {
            return (d * d * deltaH2) / (4 * deltaT2);
        }
    }
}
