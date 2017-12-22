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
        double totalCallCharges;
        double totalDiscount;
        double tax;
        double rental;
        double amount;
        List<CallDetails> callDetails=new List<CallDetails>();


        public Bill(Customer customerDetails)
        {
            this.customerDetails = customerDetails;
        
        }

        public void SetCustomerDetails(Customer customerDetails)
        {
            this.customerDetails = customerDetails;
        }

        public void SetTotalCallChagers(double totalCallCharges)
        {
            this.totalCallCharges = totalCallCharges;
        }

        public void SetTotalDiscount(double totalDiscount)
        {
            this.totalDiscount = totalDiscount;
        }

        public void SetTax(double tax)
        {
            this.tax = tax;
        }

        public void SetRental(double rental)
        {
            this.rental = rental;
        }

        public void SetAmount(double amount)
        {
            this.amount = amount;
        }

        public void SetCallDetails(CallDetails callDetail)
        {
            callDetails.Add(callDetail);
        }


        public Customer GetCustomer()
        {
            return customerDetails;
        }

        public double GetTotalCallCharge()
        {
            return totalCallCharges;
        }

        public double GetRental()
        {
            return rental;
        }

        public double GetTax()
        {
            return tax;
        }

        public double GetAmount()
        {
            return amount;
        }


    }
}
