using MobileBilling.Interfaces;
using MobileBilling.MobileCharges;


namespace MobileBilling.PackageCalculations
{
    class PackageD : IPackage
    {
        CalculationTime Charges = new CalculationTime();
        ICharges package = new PackageDCharges();

        public double CalculateChargers(int peektime, int duration, bool isLocal)
        {
            return Charges.CalculateInSeconds(peektime, duration, isLocal, package);
        }

        public double GetRental()
        {
            return package.GetRental();
        }
    }
}
