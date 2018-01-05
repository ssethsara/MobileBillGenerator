
using MobileBilling.Interfaces;
using MobileBilling.MobileCharges;


namespace MobileBilling.PackageCalculations
{
    class PackageB: IPackage
    {
        CalculationTime Charges = new CalculationTime();
        ICharges package = new PackageBCharges();

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
