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
        Determinations check = new Determinations();

        TimeSpan peakTimeStart = new TimeSpan(08, 00, 00);
        TimeSpan peakTimeEnd = new TimeSpan(20, 00, 00);
        PackageACharges packageA = new PackageACharges();

        public double packagechargersCalculation(CDR call)
        {
            int peektime= check.PeekCallduraion(call);
            bool isLocal = check.IsLocalCall(call.GetSubscribeNumber(), call.GetRecieveNumber());
            double chargers = CalculateChargers(peektime, call.GetDuration(), isLocal);
            return chargers;
        }



        double CalculateChargers(int peektime, int duration,bool isLocal)
        {
            double peekTimeInMInutes = (double)peektime / 60;
            double OffpeekTimeInMInutes = (double)(duration - peektime) / 60;

            if (isLocal)
            {

                double peekCharges = Math.Ceiling(peekTimeInMInutes) * packageA.GetPeekLocalCharges();
                double OffpeekCharges = Math.Ceiling(OffpeekTimeInMInutes) * packageA.GetOffPeekLocalCharges();
             
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
