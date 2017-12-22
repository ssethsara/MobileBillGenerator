using MobileBilling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBilling
{
    public class BillingEngine
    {
        Customer customer;
        List<CDR> listOfCalls = new List<CDR>();

        public Customer AddCustomer(String Fullname, string BillingAddress, int PhoneNumber, int PackageCode,DateTime dateRegistered)
        {

            customer = new Customer(Fullname, BillingAddress, PhoneNumber, PackageCode, dateRegistered);
            return customer;
        }

        public Customer GetCustomer()
        {
            return customer;
        }

        public List<CDR> GetCDRList()
        {
            return listOfCalls;
        }

        public CDR SetCDR(int SubscribeNumber, int recieveNumber, TimeSpan startTime, int Duration)
        {
            CDR call = new CDR(SubscribeNumber, recieveNumber, startTime, Duration);
            listOfCalls.Add(call);




            return call;
        }




        public Bill Generate()
        {
            Bill customerBill = new Bill(customer);

            return customerBill;
        }
    } 
}
