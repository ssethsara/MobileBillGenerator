using MobileBilling.MobileCharges;
using MobileBilling.Models;
using MobileBilling.PackageCalculations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBilling.PackageCalculations
{
    class PackageA : IPackage
    {
        PackageACharges packageA = new PackageACharges();

        public double CalculateChargers(int peektime, int duration,bool isLocal)
        {
            double peekTimeInMInutes = Math.Ceiling(((double)peektime / 60));
            double OffpeekTimeInMInutes = Math.Ceiling((double)(duration - peektime) / 60);

            if (isLocal)
            {
                double peekCharges = peekTimeInMInutes * packageA.GetPeekLocalCharges();
                double OffpeekCharges = OffpeekTimeInMInutes * packageA.GetOffPeekLocalCharges();
             
                return peekCharges + OffpeekCharges;
            }
            else
            {
                double peekCharges = Math.Ceiling(peekTimeInMInutes) * packageA.GetPeekLongDistanceCharges();
                double OffpeekCharges = Math.Ceiling(OffpeekTimeInMInutes) * packageA.GetOffPeekLongDistanceCharges();
               
                return peekCharges + OffpeekCharges;
            }
        }


    }
}
