using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBilling.Models
{
    public class Bill
    {
        Customer customerDetails;
        double TotalCallCharges;
        double TotalDiscount;
        double Tax;
        double rental;
        double amount;
        List<CallDetails> callDetails;


        public Bill(Customer customerDetails)
        {
            this.customerDetails = customerDetails;
        
        }

        public void SetCustomerDetails(Customer customerDetails)
        {
            this.customerDetails = customerDetails;
        }

        public void SetTotalCallChagers(double TotalCallCharges)
        {
            this.TotalCallCharges = TotalCallCharges;
        }

        public void SetTotalDiscount(double TotalDiscount)
        {
            this.TotalDiscount = TotalDiscount;
        }

        public void SetTax(double Tax)
        {
            this.Tax = Tax;
        }

        public void SetRental(double rental)
        {
            this.rental = rental;
        }

        public void SetAmount(double amount)
        {
            this.amount = amount;
        }

        public void SetCallDetails(List<CallDetails> callDetails)
        {
            this.callDetails = callDetails;
        }


        public Customer GetCustomer()
        {
            return customerDetails;
        }

        public double GetTotalCallCharge()
        {
            return TotalCallCharges;
        }



    }
}
