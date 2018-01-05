using MobileBilling.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBilling.MobileCharges
{
    class PackageCCharges: ICharges
    {
        int peekLocalCharge = 2;
        int peekLongDistCharge = 3;
        int offpeekLocalCharge = 1;
        int offpeekLongDistCharge = 2;

        double rental = 300;

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
