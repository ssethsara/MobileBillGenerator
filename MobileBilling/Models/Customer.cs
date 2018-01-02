using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBilling.Models
{
    public class Customer
    {
         string Fullname;
         string BillingAddress;
         string PhoneNumber;
         char Package;
         DateTime RegisteredDate;

        public Customer(string Fullname, string BillingAddress, string PhoneNumber, char PackageCode, DateTime RegisteredDate)
        {
            this.Fullname= Fullname;
            this.BillingAddress=BillingAddress;
            this.PhoneNumber=PhoneNumber;
            this.Package=PackageCode;
            this.RegisteredDate=RegisteredDate;
        }


        public string getFullname()
        {
            return Fullname;
        }

        public string getBillingAddress()
        {
            return BillingAddress;
        }

        public string getPhoneNumber()
        {
            return PhoneNumber;
        }

        public char getPackage()
        {
            return Package;
        }

        public DateTime getRegisteredDate()
        {
            return RegisteredDate;
        }


       

    }
}
