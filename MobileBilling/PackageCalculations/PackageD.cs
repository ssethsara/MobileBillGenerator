using MobileBilling.Interfaces;
using MobileBilling.MobileCharges;


namespace MobileBilling.PackageCalculations
{
    class PackageD : IPackage
    {
        CalculationTime Charges = new CalculationTime();

        public double CalculateChargers(int peektime, int duration, bool isLocal)
        {
            return Charges.CalculateInSeconds(peektime, duration, isLocal, new PackageDCharges());
        }

    }
}
