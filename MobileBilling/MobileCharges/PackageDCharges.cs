﻿using MobileBilling.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBilling.MobileCharges
{
    class PackageDCharges: ICharges
    {
        int peekLocalCharge = 3;
        int peekLongDistCharge = 5;
        int offpeekLocalCharge = 2;
        int offpeekLongDistCharge = 4;


        int freeLocalPeekMinutes = 0;
        int freeLocalOffPeekMinutes = 0;
        int freeLongDistancePeekMinutes = 0;
        int freeLongDistanceOffPeekMinutes = 0;



        double discounts =0;
        double rental = 300;

        TimeSpan peekTimeStart = new TimeSpan(08, 00, 00);
        TimeSpan peekTimeEnd = new TimeSpan(20, 00, 00);

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

        public TimeSpan getPeekStartTime()
        {
            return peekTimeStart;
        }

        public TimeSpan getPeekEndTime()
        {
            return peekTimeEnd;
        }

        public int getFreeLocalPeekMinutes()
        {
            return freeLocalPeekMinutes;
        }

        public int getFreeLocalOffPeekMinutes()
        {
            return freeLocalOffPeekMinutes;
        }


        public int getFreeLongDistancePeekMinutes()
        {
            return freeLongDistancePeekMinutes;
        }


        public int getFreeLongDistanceOffPeekMinutes()
        {
            return freeLongDistanceOffPeekMinutes;
        }

        public double getDiscounts()
        {
            return discounts;
        }


    }
}
