using MobileBilling.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBilling.MobileCharges
{
    public class PackageACharges : ICharges
    {
        int peekLocalCharge = 3;
        int peekLongDistCharge = 5;
        int offpeekLocalCharge = 2;
        int offpeekLongDistCharge = 4;

        double rental = 100;

        public int GetOffPeekLocalCharges()
        {
            return offpeekLocalCharge;
        }

        public int GetOffPeekLongDistanceCharges()
        {
            return offpeekLongDistCharge;
        }

        public int GetPeekLocalCharges()
        {
            return peekLocalCharge;
        }

        public int GetPeekLongDistanceCharges()
        {
            return peekLongDistCharge;
        }

        public double GetRental()
        {
            return rental;
        }
    }
}
