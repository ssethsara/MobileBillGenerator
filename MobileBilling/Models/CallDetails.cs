using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBilling.Models
{
    public class CallDetails
    {
        TimeSpan startTime;
        int duration;
        string destinationNumber;
        double charge;

        public CallDetails(TimeSpan startTime, int duration, string destinationNumber, double charge)
        {
            this.startTime = startTime;
            this.duration = duration;
            this.destinationNumber = destinationNumber;
            this.charge = charge;
        }

        public TimeSpan GetStartTime()
        {
            return startTime;
        }

        public int GetDuration()
        {
            return duration;
        }

        public string GetDestinationNumber()
        {
            return destinationNumber;
        }

        public double GetCharge()
        {
            return charge;
        }


        public void Display()
        {
            Console.WriteLine("start Time:"+startTime);
            Console.WriteLine("Duration:" + duration+" Seconds");
            Console.WriteLine("Destination number:" + destinationNumber);
            Console.WriteLine("Charge:" + charge);
        }
    }

   
}
