
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

            if (isLocal)
            {
                double peekCharges = peekTimeInMInutes * packageCharges.GetPeekLocalCharges();
                double OffpeekCharges = OffpeekTimeInMInutes * packageCharges.GetOffPeekLocalCharges();

                return peekCharges + OffpeekCharges;
            }
            else
            {
                double peekCharges =peekTimeInMInutes * packageCharges.GetPeekLongDistanceCharges();
                double OffpeekCharges = OffpeekTimeInMInutes * packageCharges.GetOffPeekLongDistanceCharges();

                return peekCharges + OffpeekCharges;
            }
        }



        public double CalculateInSeconds(int peektime, int duration, bool isLocal, ICharges packageCharges)
        {
            if (isLocal)
            {
                double peekCharges = peektime * (double)packageCharges.GetPeekLocalCharges() / 60;
                double OffpeekCharges = (duration - peektime) * (double)packageCharges.GetOffPeekLocalCharges() / 60;

                return peekCharges + OffpeekCharges;
            }
            else
            {
                double peekCharges = peektime * (double)packageCharges.GetPeekLongDistanceCharges() / 60;
                double OffpeekCharges = (duration - peektime) * (double)packageCharges.GetOffPeekLongDistanceCharges() / 60;

                return peekCharges + OffpeekCharges;
            }
        }
    }
}
