
using MobileBilling.Interfaces;
using MobileBilling.MobileCharges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBilling.PackageCalculations
{
    public class CalculationTime
    {
        ICharges packageCharges;

        int freeLocalPeekMinutes;
        int freeLocalOffPeekMinutes;
        int freeLongDistancePeekMinutes;
        int freeLongDistanceOffPeekMinutes;

        public void SetFreeTimes()
        {
             freeLocalPeekMinutes = packageCharges.getFreeLocalPeekMinutes();
             freeLocalOffPeekMinutes = packageCharges.getFreeLocalOffPeekMinutes();
             freeLongDistancePeekMinutes = packageCharges.getFreeLongDistancePeekMinutes();
             freeLongDistanceOffPeekMinutes = packageCharges.getFreeLongDistanceOffPeekMinutes();
        }

        public double CalculateInMinutes(int peekDuration, int duration, bool isLocal,ICharges packageCharges)
        {

            this.packageCharges = packageCharges;
            SetFreeTimes();

            return CalculateFreeTime(peekDuration, duration, isLocal, true);
        }


        public double CalculateInSeconds(double peekDuration, int duration, bool isLocal, ICharges packageCharges)
        {
            this.packageCharges = packageCharges;
            SetFreeTimes();

            return CalculateFreeTime(peekDuration, duration, isLocal, false);
        }


        public double CalculateFreeTime(double peekDuration, int duration, bool isLocal, bool isInMinutes)
        {
            double peekTime = peekDuration;
            double OffpeekTime = duration - peekDuration;

            if (isLocal)
            {
                peekTime = ReduceFreeTime(peekTime, freeLocalPeekMinutes, isInMinutes);
                OffpeekTime = ReduceFreeTime(OffpeekTime, freeLocalOffPeekMinutes, isInMinutes);

                double peekCharges = peekTime * packageCharges.GetPeekLocalCharges();
                double OffpeekCharges = OffpeekTime * packageCharges.GetOffPeekLocalCharges();

                if(isInMinutes)
                    return peekCharges + OffpeekCharges;
                else
                    return (peekCharges + OffpeekCharges)/60;
            }
            else
            {
                peekTime = ReduceFreeTime(peekTime, freeLongDistancePeekMinutes, isInMinutes);
                OffpeekTime = ReduceFreeTime(OffpeekTime, freeLongDistanceOffPeekMinutes, isInMinutes);

                double peekCharges = peekTime * packageCharges.GetPeekLongDistanceCharges();
                double OffpeekCharges = OffpeekTime * packageCharges.GetOffPeekLongDistanceCharges();

                if (isInMinutes)
                    return peekCharges + OffpeekCharges;
                else
                    return (peekCharges + OffpeekCharges) / 60;
            }
        }

          public double ReduceFreeTime(double time,int freeCharges,bool isInMinutes)
          {
            if (isInMinutes)
                time = Math.Ceiling((double)time / 60);
            else
                freeCharges = freeCharges * 60;

            time = time - freeCharges;

            if (time < 0)
                  time = 0;

            return time;
         }

        

    }
}
