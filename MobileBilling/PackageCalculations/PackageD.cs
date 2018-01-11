using MobileBilling.Interfaces;
using MobileBilling.MobileCharges;
using System;

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

        public TimeSpan GetPeekStartTime()
        {
            return package.getPeekStartTime();
        }


        public TimeSpan GetPeekEndTime()
        {
            return package.getPeekEndTime();
        }

        public double GetTotalDiscount(double totalCharges)
        {
            totalCharges = totalCharges + package.GetRental();

            if (totalCharges > 1000)
            {
                return totalCharges * package.getDiscounts();
            }
            return 0;
        }
    }
}
