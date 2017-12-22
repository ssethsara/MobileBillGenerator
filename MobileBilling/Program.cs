using MobileBilling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBilling
{
    class Program
    {
        static void Main(string[] args)
        {

            BillingEngine _but = new BillingEngine();
            _but.AddCustomer("Supun Sethsara", "No:123,Colombo", 0710000000, 1, new DateTime(17, 12, 23));
            _but.SetCDR(0710000000, 0711111111, new TimeSpan(12, 00, 00), 30);
            _but.SetCDR(0710000000, 0711111111, new TimeSpan(08, 00, 00), 15);

            //Act
            Bill actual = _but.Generate();
        }
    }
}
