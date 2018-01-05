using MobileBilling.Interfaces;
using MobileBilling.MobileCharges;


namespace MobileBilling.PackageCalculations
{
    class PackageC:IPackage
    {
        CalculationTime Charges = new CalculationTime();
        ICharges package = new PackageCCharges();

        public double CalculateChargers(int peektime, int duration, bool isLocal)
        {
            return Charges.CalculateInMinutes(peektime, duration, isLocal, package);
        }

        public double GetRental()
        {
            return package.GetRental();
        }
    }
}
