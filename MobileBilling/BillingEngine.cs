using MobileBilling.Models;
using MobileBilling.PackageCalculations;
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
        TimeSpan peakTimeStart = new TimeSpan(08, 00, 00);
        TimeSpan peakTimeEnd = new TimeSpan(20, 00, 00);
        int packageA_PeakLocalCharge = 3;
        int packageA_PeakLongDistCharge = 5;
        int packageA_OffpeakLocalCharge = 2;
        int packageA_OffpeakLongDistCharge = 4;


        int packageB_PeakLocalCharge = 4;
        int packageB_PeakLongDistCharge = 6;
        int packageB_OffpeakLocalCharge = 3;
        int packageB_OffpeakLongDistCharge = 5;



        double taxRate = 0.2;

        public Customer AddCustomer(String Fullname, string BillingAddress, string PhoneNumber, char Package, DateTime dateRegistered)
        {

            customer = new Customer(Fullname, BillingAddress, PhoneNumber, Package, dateRegistered);
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

        public CDR SetCDR(string SubscribeNumber, string recieveNumber, TimeSpan startTime, int Duration)
        {
            CDR call = new CDR(SubscribeNumber, recieveNumber, startTime, Duration);
            listOfCalls.Add(call);

            return call;
        }


        public Bill Generate()
        {
            Bill customerBill = new Bill(customer);
            customerBill.SetRental(100);
            double totalCharge = 0;
            foreach (var call in listOfCalls)
            {
                if (call.GetSubscribeNumber() == customer.getPhoneNumber())
                {
                    double calculatedCharge = CalculateCharges(call);
                    totalCharge = totalCharge + calculatedCharge;
                    CallDetails detail = new CallDetails(call.GetStartTime(), call.GetDuration(), call.GetRecieveNumber(), calculatedCharge);
                    customerBill.SetCallDetails(detail);

                }
            }
            customerBill.SetTotalCallChagers(totalCharge);
            customerBill.SetTax(CalculateTax(customerBill.GetTotalCallCharge(), customerBill.GetRental()));
            customerBill.SetAmount(CalculateTotalAmount(customerBill.GetTotalCallCharge(), customerBill.GetRental(), customerBill.GetTax()));

            return customerBill;
        }

        double CalculateCharges(CDR call)
        {
            if (customer.getPackage() == 'A')
            {
                Package pk = new PackageA();
                   return pk.packagechargersCalculation(call);
            }
            else if (customer.getPackage() == 'B')
            {
                Package pk = new PackageB();
                return pk.packagechargersCalculation(call);
            }
            return 0;
        }

        double CalculateTax(double totalCallCharge,double rental)
        {
            return ((totalCallCharge + rental) * taxRate);
        }


        double CalculateTotalAmount(double totalCallCharge, double rental,double tax)
        {
            return totalCallCharge +rental+tax;
        }
    }
}

