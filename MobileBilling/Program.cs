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
            //Arrange
            _but.AddCustomer("Supun Sethsara", "No:123,Colombo", "071-0000000", 'B', new DateTime(17, 12, 23));
            _but.SetCDR("071-0000000", "071-1111111", new TimeSpan(19, 59, 30), 60);

            double totalCharge = 100 + (4 * 0.5);
            double tax = totalCharge * 0.2;
            double expected = totalCharge + tax;
            //Act
            //Act
            _but.Generate();
            //Asser

            _but.Generate().Display();

            Console.ReadLine();
        }
    }
}
