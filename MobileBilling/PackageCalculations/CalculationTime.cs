
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
        public double CalculateInMinutes(int peektime, int duration, bool isLocal,ICharges packageCharges)
        {



            double peekTimeInMInutes = Math.Ceiling(((double)peektime / 60));
            double OffpeekTimeInMInutes = Math.Ceiling((double)(duration - peektime) / 60);

            int freeLocalPeekMinutes = packageCharges.getFreeLocalPeekMinutes();
            int freeLocalOffPeekMinutes =packageCharges.getFreeLocalOffPeekMinutes();
            int freeLongDistancePeekMinutes = packageCharges.getFreeLongDistancePeekMinutes();
            int freeLongDistanceOffPeekMinutes = packageCharges.getFreeLongDistanceOffPeekMinutes();

            

            if (isLocal)
            {
                peekTimeInMInutes = peekTimeInMInutes - freeLocalPeekMinutes;
                if (peekTimeInMInutes < 0)
                {
                    peekTimeInMInutes = 0;
                }

                OffpeekTimeInMInutes = OffpeekTimeInMInutes - freeLocalOffPeekMinutes;
                if (OffpeekTimeInMInutes < 0)
                {
                    OffpeekTimeInMInutes = 0;
                }

                double peekCharges = peekTimeInMInutes * packageCharges.GetPeekLocalCharges();
                double OffpeekCharges = OffpeekTimeInMInutes * packageCharges.GetOffPeekLocalCharges();

                return peekCharges + OffpeekCharges;
            }
            else
            {
                peekTimeInMInutes = peekTimeInMInutes - freeLongDistancePeekMinutes;
                if (peekTimeInMInutes < 0)
                {
                    peekTimeInMInutes = 0;
                }

                OffpeekTimeInMInutes = OffpeekTimeInMInutes - freeLongDistanceOffPeekMinutes;
                if (OffpeekTimeInMInutes < 0)
                {
                    OffpeekTimeInMInutes = 0;
                }


                double peekCharges =peekTimeInMInutes * packageCharges.GetPeekLongDistanceCharges();
                double OffpeekCharges = OffpeekTimeInMInutes * packageCharges.GetOffPeekLongDistanceCharges();

                return peekCharges + OffpeekCharges;
            }
        }

      


        public double CalculateInSeconds(int peektimeInSeconds, int duration, bool isLocal, ICharges packageCharges)
        {
            int freeLocalPeekSeconds = packageCharges.getFreeLocalPeekMinutes()*60;
            int freeLocalOffPeekSeconds = packageCharges.getFreeLocalOffPeekMinutes() * 60;
            int freeLongDistancePeekSeconds = packageCharges.getFreeLongDistancePeekMinutes() * 60;
            int freeLongDistanceOffPeekSeconds = packageCharges.getFreeLongDistanceOffPeekMinutes() * 60;

            int offpeekTimeInSeconds = duration - peektimeInSeconds;

            if (isLocal)
            {

                peektimeInSeconds = peektimeInSeconds - freeLocalPeekSeconds;
                if (peektimeInSeconds < 0)
                {
                    peektimeInSeconds = 0;
                }

                offpeekTimeInSeconds = offpeekTimeInSeconds - freeLocalOffPeekSeconds;
                if (offpeekTimeInSeconds < 0)
                {
                    offpeekTimeInSeconds = 0;
                }

                double peekCharges = peektimeInSeconds * (double)packageCharges.GetPeekLocalCharges() / 60;
                double OffpeekCharges = offpeekTimeInSeconds * (double)packageCharges.GetOffPeekLocalCharges() / 60;

                return peekCharges + OffpeekCharges;
            }
            else
            {
                peektimeInSeconds = peektimeInSeconds - freeLongDistancePeekSeconds;
                if (peektimeInSeconds < 0)
                {
                    peektimeInSeconds = 0;
                }

                offpeekTimeInSeconds = offpeekTimeInSeconds - freeLongDistanceOffPeekSeconds;
                if (offpeekTimeInSeconds < 0)
                {
                    offpeekTimeInSeconds = 0;
                }


                double peekCharges = peektimeInSeconds * (double)packageCharges.GetPeekLongDistanceCharges() / 60;
                double OffpeekCharges = offpeekTimeInSeconds * (double)packageCharges.GetOffPeekLongDistanceCharges() / 60;

                return peekCharges + OffpeekCharges;
            }
        }

    }
}
