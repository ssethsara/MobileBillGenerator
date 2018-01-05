using MobileBilling.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBilling.PackageCalculations.TimeCalculations
{
    class Second
    {
        public double CalculateChargers(int peektime, int duration, bool isLocal, ICharges packageCharges)
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
