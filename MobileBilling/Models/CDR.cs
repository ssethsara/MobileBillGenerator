using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBilling.Models
{
    public class CDR
    {
        string SubscribeNumber;
        string recieveNumber;
         TimeSpan startTime;
         int duration;


        public CDR(string SubscribeNumber, string recieveNumber, TimeSpan startTime, int duration)
        {
            this.SubscribeNumber= SubscribeNumber;
            this.recieveNumber= recieveNumber;
            this.startTime= startTime;
            this.duration= duration;
        }


        public string GetSubscribeNumber()
        {
            return SubscribeNumber;
        }

        public string GetRecieveNumber()
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
