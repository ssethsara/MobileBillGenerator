using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileBilling.Models;

namespace MobileBilling.PackageCalculations
{
    class PackageB: Package
    {
        int peakLocalCharge = 4;
        int peakLongDistCharge = 6;
        int offpeakLocalCharge = 3;
        int offpeakLongDistCharge = 5;


        TimeSpan peakTimeStart = new TimeSpan(08, 00, 00);
        TimeSpan peakTimeEnd = new TimeSpan(20, 00, 00);

       
        public override double packagechargersCalculation(CDR call)
        {
            int peaktime = CheckPeekCallduraion(call);
            bool isLocal = CheckIsLocalCall(call.GetSubscribeNumber(), call.GetRecieveNumber());
            double chargers = CalculateChargers(peaktime, call.GetDuration(), isLocal);
            return chargers;
        }

        int CheckPeekCallduraion(CDR call)
        {
            int durationinSec = call.GetDuration();
            TimeSpan startTime = call.GetStartTime();
            TimeSpan endTime = startTime + new TimeSpan(0, 0, durationinSec);

            if (CheckPeakTime(startTime) > CheckPeakTime(endTime))
            {
                int peakLimit = (int)(peakTimeEnd - startTime).TotalSeconds;
                return peakLimit;
            }
            else if (CheckPeakTime(startTime) < CheckPeakTime(endTime))
            {
                int peakLimit = (int)(endTime - peakTimeStart).TotalSeconds;
                return peakLimit;
            }
            else if (CheckPeakTime(startTime) == 1)
            {
                return durationinSec;
            }
            else
            {
                return 0;
            }

        }

        int CheckPeakTime(TimeSpan calledTime)
        {
            if (calledTime < peakTimeEnd && calledTime >= peakTimeStart)
            {
                return 1;
            }
            return 0;
        }


        bool CheckIsLocalCall(string subscriberNumber, string recieverNumber)
        {
            string subscribersFirstThreeDigits = subscriberNumber.Split('-')[0];
            string recieversFirstThreeDigits = recieverNumber.Split('-')[0];

            if (subscribersFirstThreeDigits == recieversFirstThreeDigits)
            {
                return true;
            }
            return false;
        }


        double CalculateChargers(int peektime, int duration, bool isLocal)
        {
            if (isLocal)
            {
                double peekCharges = peektime  * (double)peakLocalCharge / 60;
                double OffpeekCharges = (duration - peektime)  * (double)offpeakLocalCharge/60;
              
                return peekCharges + OffpeekCharges;
            }
            else
            {
                double peekCharges = peektime  * (double)peakLongDistCharge/60;
                double OffpeekCharges = (duration - peektime) * (double)offpeakLongDistCharge / 60 ;
             
                return peekCharges + OffpeekCharges;
            }
        }

       
    }
}
