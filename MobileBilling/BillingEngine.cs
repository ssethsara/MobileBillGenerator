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
        TimeSpan peakTimeStart = new TimeSpan(08, 00, 00);
        TimeSpan peakTimeEnd = new TimeSpan(20, 00, 00);
        int peakLocalCharge = 3;
        int peakLongDistCharge = 5;
        int OffpeakLocalCharge = 2;
        int OffpeakLongDistCharge = 4;

        double taxRate = 0.2;

        public Customer AddCustomer(String Fullname, string BillingAddress, string PhoneNumber, int PackageCode, DateTime dateRegistered)
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
                    totalCharge = totalCharge+ calculatedCharge;
                    CallDetails detail = new CallDetails(call.GetStartTime(), call.GetDuration(), call.GetRecieveNumber(), calculatedCharge);
                    customerBill.SetCallDetails(detail);

                }
            }

            customerBill.SetTotalCallChagers(totalCharge);
            customerBill.SetTax(CalculateTax(customerBill.GetTotalCallCharge(), customerBill.GetRental()));
            customerBill.SetAmount(CalculateTotalAmount(customerBill.GetTotalCallCharge(), customerBill.GetRental(), customerBill.GetTax()));
            Console.WriteLine(customerBill.GetTotalCallCharge());

            return customerBill;
        }




        Boolean CheckPeakTime(TimeSpan calledTime)
        {
            if (calledTime >= peakTimeStart && calledTime < peakTimeEnd)
            {
                return true;
            }
            return false;
        }


        double CalculateCharges(CDR call)
        {
     
            int DurationMin= call.GetDuration()/60;
            if ((call.GetDuration() % 60) !=0)
            {
                DurationMin++;
            }

            if (CheckIsLocalCall(call.GetSubscribeNumber(), call.GetRecieveNumber()))
            {
                if (CheckPeakTime(call.GetStartTime()))
                {
                    return DurationMin * peakLocalCharge;
                }
                else
                {
                    return DurationMin * OffpeakLocalCharge;
                }
            }
            else
            {
                if (CheckPeakTime(call.GetStartTime()))
                {
                    return DurationMin * peakLongDistCharge;
                }
                else
                {
                    return DurationMin * OffpeakLongDistCharge;
                }
            }
            


        }


        Boolean CheckIsLocalCall(string subscriberNumber,string recieverNumber)
        {
            string subscribersFirstThreeDigits = subscriberNumber.Split('-')[0];
            string recieversFirstThreeDigits = recieverNumber.Split('-')[0];

            if (subscribersFirstThreeDigits== recieversFirstThreeDigits)
            {
                return true;
            }

            return false;
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

