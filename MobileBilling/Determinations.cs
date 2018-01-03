using MobileBilling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBilling.PackageCalculations
{
    public class Determinations
    {

        TimeSpan peakTimeStart = new TimeSpan(08, 00, 00);
        TimeSpan peakTimeEnd = new TimeSpan(20, 00, 00);

        public int PeakTime(TimeSpan calledTime)
        {
            if (calledTime < peakTimeEnd && calledTime >= peakTimeStart)
            {
                return 1;
            }
            return 0;
        }


        public bool IsLocalCall(string subscriberNumber, string recieverNumber)
        {
            string subscribersFirstThreeDigits = subscriberNumber.Split('-')[0];
            string recieversFirstThreeDigits = recieverNumber.Split('-')[0];

            if (subscribersFirstThreeDigits == recieversFirstThreeDigits)
            {
                return true;
            }
            return false;
        }


        public int PeekCallduraion(CDR call)
        {
            int durationinSec = call.GetDuration();
            TimeSpan startTime = call.GetStartTime();
            TimeSpan endTime = startTime + new TimeSpan(0, 0, durationinSec);

            if (PeakTime(startTime) > PeakTime(endTime))
            {
                int peakLimit = (int)(peakTimeEnd - startTime).TotalSeconds;
                return peakLimit;
            }
            else if (PeakTime(startTime) < PeakTime(endTime))
            {
                int peakLimit = (int)(endTime - peakTimeStart).TotalSeconds;
                return peakLimit;
            }
            else if (PeakTime(startTime) == 1)
            {
                return durationinSec;
            }
            else
            {
                return 0;
            }

        }



    }
}
