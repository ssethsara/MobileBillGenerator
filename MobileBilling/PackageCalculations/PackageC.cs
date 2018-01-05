using MobileBilling.MobileCharges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBilling.PackageCalculations
{
    class PackageC:IPackage
    {
        PackageCCharges packageC = new PackageCCharges();

        public double CalculateChargers(int peektime, int duration, bool isLocal)
        {
            double peekTimeInMInutes = Math.Ceiling(((double)peektime / 60));
            double OffpeekTimeInMInutes = Math.Ceiling((double)(duration - peektime) / 60);

            if (isLocal)
            {
                double peekCharges = peekTimeInMInutes * packageC.GetPeekLocalCharges();
                double OffpeekCharges = OffpeekTimeInMInutes * packageC.GetOffPeekLocalCharges();

                return peekCharges + OffpeekCharges;
            }
            else
            {
                double peekCharges = Math.Ceiling(peekTimeInMInutes) * packageC.GetPeekLongDistanceCharges();
                double OffpeekCharges = Math.Ceiling(OffpeekTimeInMInutes) * packageC.GetOffPeekLongDistanceCharges();

                return peekCharges + OffpeekCharges;
            }
        }
    }
}
