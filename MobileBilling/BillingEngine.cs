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
            int durationSec = call.GetDuration();
            int durationMin= durationSec / 60;
            if ((durationSec % 60) !=0)
            {
                durationMin++;
            }
            if (customer.getPackage() == 'A')
            {
                if (CheckIsLocalCall(call.GetSubscribeNumber(), call.GetRecieveNumber()))
                {
                    return CheckPeakTimePackageA(call.GetStartTime(), durationMin, true);
                }
                else
                {
                    return CheckPeakTimePackageA(call.GetStartTime(), durationMin, false);
                }
            }
            else if (customer.getPackage() == 'B')
            {
                if (CheckIsLocalCall(call.GetSubscribeNumber(), call.GetRecieveNumber()))
                {
                    return CheckPeakTimePackageB(call.GetStartTime(), durationSec, true);
                }
                else
                {
                    return CheckPeakTimePackageB(call.GetStartTime(), durationSec, false);
                }
            }
            return 0;

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

        bool CheckPeakTime(TimeSpan calledTime)
        {
                if (calledTime < peakTimeEnd && calledTime >= peakTimeStart)
                {
                    return true;
                }
            return false;
        }


        double CheckPeakTimePackageA(TimeSpan calledTime, int durationMin, Boolean localCall)
        {
            double charges = 0;
            for (int a = 0; a < durationMin; a++)
            {
                if (CheckPeakTime(calledTime))
                {
                    if (localCall)
                        charges = charges + packageA_PeakLocalCharge;
                    else
                        charges = charges + packageA_PeakLongDistCharge;
                }
                else
                {
                    if (localCall)
                        charges = charges + packageA_OffpeakLocalCharge;
                    else
                        charges = charges + packageA_OffpeakLongDistCharge;
                }
                calledTime = calledTime + new TimeSpan(0, 1, 0);
            }
            return charges;
        }


        double CheckPeakTimePackageB(TimeSpan calledTime, int durationSec, Boolean localCall)
        {
            double charges = 0;
            for (int a = 0; a < durationSec; a++)
            {
                if (CheckPeakTime(calledTime))
                {
                    if (localCall)
                        charges = charges + (double)packageB_PeakLocalCharge /60;
                    else
                        charges = charges + (double)packageB_PeakLongDistCharge / 60;
                }
                else
                {
                    if (localCall)
                        charges = charges + (double)packageB_OffpeakLocalCharge / 60;
                    else
                        charges = charges + (double)packageB_OffpeakLongDistCharge / 60;
                }
                calledTime = calledTime + new TimeSpan(0, 0, 1);
            }
            return Math.Round(charges,1);
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

