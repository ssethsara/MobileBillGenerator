using MobileBilling.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBilling.PackageCalculations.TimeCalculations
{
    class Minutes
    {
        public double CalculateChargers(int peektime, int duration, bool isLocal,ICharges packageCharges)
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
                double peekCharges = Math.Ceiling(peekTimeInMInutes) * packageCharges.GetPeekLongDistanceCharges();
                double OffpeekCharges = Math.Ceiling(OffpeekTimeInMInutes) * packageCharges.GetOffPeekLongDistanceCharges();

                return peekCharges + OffpeekCharges;
            }
        }
    }
}
