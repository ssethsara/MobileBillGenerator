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
            _but.AddCustomer("Supun Sethsara", "No:123,Colombo", "071-0000000", 1, new DateTime(17, 12, 23));
            _but.SetCDR("071-0000000", "071-1111111", new TimeSpan(12, 00, 00), (60 * 3));
            _but.SetCDR("071-0000000", "073-1111111", new TimeSpan(20, 00, 00), (60 * 5));
            _but.SetCDR("071-0000000", "074-1111111", new TimeSpan(8, 00, 00), (60 * 3));
            _but.SetCDR("071-0002300", "074-1111111", new TimeSpan(8, 00, 00), (60 * 3));
            _but.SetCDR("071-0012000", "074-1111111", new TimeSpan(8, 00, 00), (60 * 3));
            _but.SetCDR("071-00004100", "074-1111111", new TimeSpan(8, 00, 00), (60 * 3));

            double totalCharge = 100 + (3 * 3) + (4 * 5) + (5 * 3);
            double tax = totalCharge * 0.2;
            double expected = totalCharge + tax;
            //Act
            Bill actual = _but.Generate();
            //Asser

            _but.Generate().Display();

            Console.ReadLine();
        }
    }
}
