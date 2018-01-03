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
            int peaktime= check.PeekCallduraion(call);
            bool isLocal = check.IsLocalCall(call.GetSubscribeNumber(), call.GetRecieveNumber());
            double chargers = CalculateChargers(peaktime, call.GetDuration(), isLocal);
            return chargers;
        }



        double CalculateChargers(int peektime, int duration,bool isLocal)
        {
            if (isLocal)
            {
                double peekCharges = peektime/60 * packageA.GetPeekLocalCharges();
                double OffpeekCharges = (duration-peektime) / 60 * packageA.GetOffPeekLocalCharges();
                if (peektime % 60 != 0)
                {
                    peekCharges = peekCharges + packageA.GetPeekLocalCharges();
                }
                if ((duration - peektime) % 60 != 0)
                {
                    peekCharges = peekCharges + packageA.GetOffPeekLocalCharges();
                }
                return peekCharges + OffpeekCharges;
            }
            else
            {
                double peekCharges = peektime/60 * packageA.GetPeekLongDistanceCharges();
                double OffpeekCharges = (duration - peektime)/60 * packageA.GetOffPeekLongDistanceCharges();
                if (peektime % 60 != 0)
                {
                    peekCharges = peekCharges + packageA.GetPeekLongDistanceCharges();
                }
                if ((duration - peektime) % 60 != 0)
                {
                    peekCharges = peekCharges + packageA.GetOffPeekLongDistanceCharges();
                }
                return peekCharges + OffpeekCharges;
            }
        }


    }
}
