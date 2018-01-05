using MobileBilling.MobileCharges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBilling.PackageCalculations
{
    class PackageD : IPackage
    {
        PackageDCharges packageD = new PackageDCharges();

        public double CalculateChargers(int peektime, int duration, bool isLocal)
        {
            if (isLocal)
            {
                double peekCharges = peektime * (double)packageD.GetPeekLocalCharges() / 60;
                double OffpeekCharges = (duration - peektime) * (double)packageD.GetOffPeekLocalCharges() / 60;

                return peekCharges + OffpeekCharges;
            }
            else
            {
                double peekCharges = peektime * (double)packageD.GetPeekLongDistanceCharges() / 60;
                double OffpeekCharges = (duration - peektime) * (double)packageD.GetOffPeekLongDistanceCharges() / 60;

                return peekCharges + OffpeekCharges;
            }
        }
    }
}
