using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBilling.Models
{
    public class CDR
    {
         int SubscribeNumber;
         int recieveNumber;
         TimeSpan startTime;
         int duration;


        public CDR(int SubscribeNumber, int recieveNumber, TimeSpan startTime, int duration)
        {
            this.SubscribeNumber= SubscribeNumber;
            this.recieveNumber= recieveNumber;
            this.startTime= startTime;
            this.duration= duration;
        }


        public int GetSubscribeNumber()
        {
            return SubscribeNumber;
        }

        public int GetRecieveNumber()
        {
            return recieveNumber;
        }

        public TimeSpan GetStartTime()
        {
            return startTime;
        }

        public int GetDuration()
        {
            return duration;
        }



    }
}
