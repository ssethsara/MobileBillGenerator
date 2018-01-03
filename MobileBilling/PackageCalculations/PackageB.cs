using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileBilling.MobileCharges;
using MobileBilling.Models;

namespace MobileBilling.PackageCalculations
{
    class PackageB: IPackage
    {
        PackageBCharges packageB = new PackageBCharges();

        public double CalculateChargers(int peektime, int duration, bool isLocal)
        {
            if (isLocal)
            {
                double peekCharges = peektime  * (double)packageB.GetPeekLocalCharges() / 60;
                double OffpeekCharges = (duration - peektime)  * (double)packageB.GetOffPeekLocalCharges()/60;
              
                return peekCharges + OffpeekCharges;
            }
            else
            {
                double peekCharges = peektime  * (double)packageB.GetPeekLongDistanceCharges()/60;
                double OffpeekCharges = (duration - peektime) * (double)packageB.GetOffPeekLongDistanceCharges() / 60 ;
             
                return peekCharges + OffpeekCharges;
            }
        }

       
    }
}
