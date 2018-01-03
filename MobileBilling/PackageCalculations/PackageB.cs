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

        Determinations check = new Determinations();

        TimeSpan peakTimeStart = new TimeSpan(08, 00, 00);
        TimeSpan peakTimeEnd = new TimeSpan(20, 00, 00);

        PackageBCharges packageB = new PackageBCharges();

        public double packagechargersCalculation(CDR call)
        {
            int peaktime = check.PeekCallduraion(call);
            bool isLocal = check.IsLocalCall(call.GetSubscribeNumber(), call.GetRecieveNumber());
            double chargers = CalculateChargers(peaktime, call.GetDuration(), isLocal);
            return chargers;
        }


        double CalculateChargers(int peektime, int duration, bool isLocal)
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
