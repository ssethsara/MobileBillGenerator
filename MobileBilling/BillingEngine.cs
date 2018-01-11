using MobileBilling.Interfaces;
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
        Bill customerBill;
        List<CDR> listOfCalls = new List<CDR>();
        Determinations check = new Determinations();
        IPackage package;

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
            customerBill = new Bill(customer);
            package=CheckPackageType();
            double totalCharge = 0;
            foreach (var call in listOfCalls)
            {
                if (call.GetSubscribeNumber() == customer.getPhoneNumber())
                {
                    double calculatedCharge = PackagechargersCalculation(call);
                    totalCharge = totalCharge + calculatedCharge;
                    CallDetails detail = new CallDetails(call.GetStartTime(), call.GetDuration(), call.GetRecieveNumber(), calculatedCharge);
                    customerBill.SetCallDetails(detail);
                }
            }
            customerBill.SetRental(package.GetRental());
            customerBill.SetTotalCallChagers(totalCharge);
            customerBill.SetTotalDiscount(package.GetTotalDiscount(totalCharge));
            customerBill.SetTax(CalculateTax(customerBill.GetTotalCallCharge(), customerBill.GetRental()));
            customerBill.SetAmount();

            return customerBill;
        }


        public double PackagechargersCalculation(CDR call)
        {
            check.setPeekTime(package.GetPeekStartTime(), package.GetPeekEndTime());

            int peektime = check.PeekCallduraion(call);
            bool isLocal = check.IsLocalCall(call.GetSubscribeNumber(), call.GetRecieveNumber());
            double chargers = package.CalculateChargers(peektime, call.GetDuration(), isLocal);
            return chargers;
        }



        IPackage CheckPackageType()
        {
            switch (customer.getPackage())
            {
                case 'A':
                    return new PackageA();
                case 'B':
                    return new PackageB();
                case 'C':
                    return new PackageC();
                case 'D':
                    return new PackageD();
                default:
                    throw new NullReferenceException();
            }



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

