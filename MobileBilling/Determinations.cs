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
            int durationInSec = call.GetDuration();
            TimeSpan startTime = call.GetStartTime();
            int Totalduration = 0;
            int DayInSecond = 60 * 60 * 24;
            if (durationInSec > DayInSecond)
            {
                Totalduration = Totalduration + checkExeedingLimit(24, startTime);
                Totalduration = Totalduration + checkExeedingLimit(durationInSec - 24, startTime);
            }
            return checkExeedingLimit(durationInSec, startTime);
        }


        int checkExeedingLimit(int durationInSec, TimeSpan startTime)
        {
            TimeSpan endTime = startTime + new TimeSpan(0, 0, durationInSec);
            int twelveHours = 12 * 60 * 60;

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
                if (durationInSec > twelveHours)
                {
                    return durationInSec - twelveHours;
                }
                return durationInSec;
            }
            else
            {
                if (durationInSec > twelveHours)
                {
                    return twelveHours;
                }
                return 0;
            }
        }



    }
}
