using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobileBilling;
using MobileBilling.Models;
using System;

namespace MobileBillingUnitTest
{
    [TestClass]
    public class MobileBillingTest
    {
        BillingEngine _but;

        [TestInitialize]
        public void init()
        {
            _but = new BillingEngine();
        }

        [TestMethod]
        public void OnaddCustomer_withCustomerData_ShouldCoustomerDetails()
        {
            //Arrange
            Customer actual= _but.AddCustomer("Supun Sethsara", "No:123,Colombo", "071-9283743", 'A', new DateTime(17,12,23));
            //Act
            Customer expected = new Customer("Supun Sethsara", "No:123,Colombo", "071-9283743", 'A', new DateTime(17, 12, 23));
       
            //Assert

            Assert.AreEqual(expected.getFullname(), actual.getFullname());
            Assert.AreEqual(expected.getBillingAddress(), actual.getBillingAddress());
            Assert.AreEqual(expected.getPhoneNumber(), actual.getPhoneNumber());
            Assert.AreEqual(expected.getPackage(), actual.getPackage());
            Assert.AreEqual(expected.getRegisteredDate(), actual.getRegisteredDate());

        }


        [TestMethod]
        public void OnSetCDR_withCDRDataAdd_ShouldIncreaseCount()
        {
            //Arrange
            _but.SetCDR("071-0000000", "071-1111111", new TimeSpan(12, 00, 00), 30);
            //Act
            int expected = 1;
            int actual = _but.GetCDRList().Count;
            //Assert

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void OnSetCDR_withCDRDataAdd_ShouldSaveCDRDetails()
        {
            //Arrange
            CDR actual = _but.SetCDR("071-0000000", "071-1111111", new TimeSpan(12, 00, 00), 30);
            //Act
            CDR expected = new CDR("071-0000000", "071-1111111", new TimeSpan(12, 00, 00), 30);

            //Assert

            Assert.AreEqual(expected.GetSubscribeNumber(), actual.GetSubscribeNumber());
            Assert.AreEqual(expected.GetRecieveNumber(), actual.GetRecieveNumber());
            Assert.AreEqual(expected.GetStartTime(), actual.GetStartTime());
            Assert.AreEqual(expected.GetDuration(), actual.GetDuration());

        }


        [TestMethod]
        public void OnGenerate_withCustomerDetails_ShouldGenerateABillWithCustomerDetails()
        {

            //Arrange
            Customer expected=_but.AddCustomer("Supun Sethsara", "No:123,Colombo", "071-0000000", 'A', new DateTime(17, 12, 23));
            _but.SetCDR("071-0000000", "071-1111111", new TimeSpan(12, 00, 00), 30);
            _but.SetCDR("071-0000000", "071-1111111", new TimeSpan(08, 00, 00), 15);

            //Act
            Bill actual = _but.Generate();
            //Assert
            Assert.AreEqual(expected.getFullname(), actual.GetCustomer().getFullname());
            Assert.AreEqual(expected.getBillingAddress(), actual.GetCustomer().getBillingAddress());
            Assert.AreEqual(expected.getPhoneNumber(), actual.GetCustomer().getPhoneNumber());
            Assert.AreEqual(expected.getPackage(), actual.GetCustomer().getPackage());
            Assert.AreEqual(expected.getRegisteredDate(), actual.GetCustomer().getRegisteredDate());

        }



        //Peak Basic Test

        [TestMethod]
        public void OnGenerate_withPeakLocalCall1Miniute_ShouldAddTotalChargeToBill()
        {

            //Arrange
            _but.AddCustomer("Supun Sethsara", "No:123,Colombo", "071-0000000", 'A', new DateTime(17, 12, 23));
            _but.SetCDR("071-0000000", "071-1111111", new TimeSpan(12, 00, 00), 60);

            double expected = 3;
            //Act
            Bill actual = _but.Generate();
            //Assert
            Assert.AreEqual(expected, actual.GetTotalCallCharge());
           

        }

        [TestMethod]
        public void OnGenerate_withPeakLocalCall4Miniutes_ShouldAddTotalChargeToBill()
        {

            //Arrange
            _but.AddCustomer("Supun Sethsara", "No:123,Colombo", "071-0000000", 'A', new DateTime(17, 12, 23));
            _but.SetCDR("071-0000000", "071-1111111", new TimeSpan(12, 00, 00), 240);

            double expected = 12;
            //Act
            Bill actual = _but.Generate();
            //Assert
            Assert.AreEqual(expected, actual.GetTotalCallCharge());


        }

        [TestMethod]
        public void OnGenerate_withPeakLocalCall20second_ShouldAddTotalChargeToBill()
        {

            //Arrange
            _but.AddCustomer("Supun Sethsara", "No:123,Colombo", "071-0000000", 'A', new DateTime(17, 12, 23));
            _but.SetCDR("071-0000000", "071-1111111", new TimeSpan(12, 00, 00), 20);

            double expected = 3;
            //Act
            Bill actual = _but.Generate();
            //Assert
            Assert.AreEqual(expected, actual.GetTotalCallCharge());


        }

        [TestMethod]
        public void OnGenerate_withPeakLocalCall4minutesAnd20second_ShouldAddTotalChargeToBill()
        {

            //Arrange
            _but.AddCustomer("Supun Sethsara", "No:123,Colombo", "071-0000000", 'A', new DateTime(17, 12, 23));
            _but.SetCDR("071-0000000", "071-1111111", new TimeSpan(12, 00, 00), 260);

            double expected = 15;
            //Act
            Bill actual = _but.Generate();
            //Assert
            Assert.AreEqual(expected, actual.GetTotalCallCharge());


        }




        //OffPeak Basic Test

        [TestMethod]
        public void OnGenerate_withOffPeakLocalCall1Miniute_ShouldAddTotalChargeToBill()
        {

            //Arrange
            _but.AddCustomer("Supun Sethsara", "No:123,Colombo", "071-0000000", 'A', new DateTime(17, 12, 23));
            _but.SetCDR("071-0000000", "071-1111111", new TimeSpan(20, 00, 00), 60);

            double expected = 2;
            //Act
            Bill actual = _but.Generate();
            //Assert
            Assert.AreEqual(expected, actual.GetTotalCallCharge());


        }

        [TestMethod]
        public void OnGenerate_withOffPeakLocalCall4Miniutes_ShouldAddTotalChargeToBill()
        {

            //Arrange
            _but.AddCustomer("Supun Sethsara", "No:123,Colombo", "071-0000000", 'A', new DateTime(17, 12, 23));
            _but.SetCDR("071-0000000", "071-1111111", new TimeSpan(20, 00, 00), 240);

            double expected = 8;
            //Act
            Bill actual = _but.Generate();
            //Assert
            Assert.AreEqual(expected, actual.GetTotalCallCharge());


        }

        [TestMethod]
        public void OnGenerate_withOffPeakLocalCall20second_ShouldAddTotalChargeToBill()
        {

            //Arrange
            _but.AddCustomer("Supun Sethsara", "No:123,Colombo", "071-0000000", 'A', new DateTime(17, 12, 23));
            _but.SetCDR("071-0000000", "071-1111111", new TimeSpan(20, 00, 00), 20);

            double expected = 2;
            //Act
            Bill actual = _but.Generate();
            //Assert
            Assert.AreEqual(expected, actual.GetTotalCallCharge());


        }

        [TestMethod]
        public void OnGenerate_withOffPeakLocalCall4minutesAnd20second_ShouldAddTotalChargeToBill()
        {

            //Arrange
            _but.AddCustomer("Supun Sethsara", "No:123,Colombo", "071-0000000", 'A', new DateTime(17, 12, 23));
            _but.SetCDR("071-0000000", "071-1111111", new TimeSpan(20, 00, 00), 260);

            double expected = 10;
            //Act
            Bill actual = _but.Generate();
            //Assert
            Assert.AreEqual(expected, actual.GetTotalCallCharge());


        }


        //Long Distance peak Test


        [TestMethod]
        public void OnGenerate_withPeakLongDistanceCall1Miniute_ShouldAddTotalChargeToBill()
        {

            //Arrange
            _but.AddCustomer("Supun Sethsara", "No:123,Colombo", "071-0000000", 'A', new DateTime(17, 12, 23));
            _but.SetCDR("071-0000000", "072-1111111", new TimeSpan(12, 00, 00), 60);

            double expected = 5;
            //Act
            Bill actual = _but.Generate();
            //Assert
            Assert.AreEqual(expected, actual.GetTotalCallCharge());


        }

        [TestMethod]
        public void OnGenerate_withPeakLongDistanceCall20Second_ShouldAddTotalChargeToBill()
        {

            //Arrange
            _but.AddCustomer("Supun Sethsara", "No:123,Colombo", "071-0000000", 'A', new DateTime(17, 12, 23));
            _but.SetCDR("071-0000000", "072-1111111", new TimeSpan(12, 00, 00), 20);

            double expected = 5;
            //Act
            Bill actual = _but.Generate();
            //Assert
            Assert.AreEqual(expected, actual.GetTotalCallCharge());


        }

        [TestMethod]
        public void OnGenerate_withPeakLongDistanceCall2MinutesAnd20Second_ShouldAddTotalChargeToBill()
        {

            //Arrange
            _but.AddCustomer("Supun Sethsara", "No:123,Colombo", "071-0000000", 'A', new DateTime(17, 12, 23));
            _but.SetCDR("071-0000000", "072-1111111", new TimeSpan(08, 00, 00), 140);

            double expected = 15;
            //Act
            Bill actual = _but.Generate();
            //Assert
            Assert.AreEqual(expected, actual.GetTotalCallCharge());


        }


        //Long Distance offpeak Test


        [TestMethod]
        public void OnGenerate_withOffPeakLongDistanceCall1Miniute_ShouldAddTotalChargeToBill()
        {

            //Arrange
            _but.AddCustomer("Supun Sethsara", "No:123,Colombo", "071-0000000", 'A', new DateTime(17, 12, 23));
            _but.SetCDR("071-0000000", "072-1111111", new TimeSpan(20, 00, 00), 60);

            double expected = 4;
            //Act
            Bill actual = _but.Generate();
            //Assert
            Assert.AreEqual(expected, actual.GetTotalCallCharge());


        }

        [TestMethod]
        public void OnGenerate_withOffPeakLongDistanceCall20Second_ShouldAddTotalChargeToBill()
        {

            //Arrange
            _but.AddCustomer("Supun Sethsara", "No:123,Colombo", "071-0000000", 'A', new DateTime(17, 12, 23));
            _but.SetCDR("071-0000000", "072-1111111", new TimeSpan(20, 00, 00), 20);

            double expected = 4;
            //Act
            Bill actual = _but.Generate();
            //Assert
            Assert.AreEqual(expected, actual.GetTotalCallCharge());


        }


        [TestMethod]
        public void OnGenerate_withOffPeakLongDistanceCall2MinutesAnd20Second_ShouldAddTotalChargeToBill()
        {

            //Arrange
            _but.AddCustomer("Supun Sethsara", "No:123,Colombo", "071-0000000", 'A', new DateTime(17, 12, 23));
            _but.SetCDR("071-0000000", "072-1111111", new TimeSpan(20, 00, 00), 140);

            double expected = 12;
            //Act
            Bill actual = _but.Generate();
            //Assert
            Assert.AreEqual(expected, actual.GetTotalCallCharge());


        }



        /////
        ///Tax calculation Testing
        ///
        [TestMethod]
        public void OnGenerate_withOffPeakLongDistanceCall1MinutesAndTax_ShouldAddTaxAmount()
        {

            //Arrange
            _but.AddCustomer("Supun Sethsara", "No:123,Colombo", "071-0000000", 'A', new DateTime(17, 12, 23));
            _but.SetCDR("071-0000000", "071-1111111", new TimeSpan(12, 00, 00), 60);

            double expected = 20.6;
            //Act
            Bill actual = _but.Generate();
            //Assert
            Assert.AreEqual(expected, actual.GetTax());


        }


        [TestMethod]
        public void OnGenerate_withOffPeakLongDistanceCall20MinutesAndTax_ShouldAddTaxAmount()
        {

            //Arrange
            _but.AddCustomer("Supun Sethsara", "No:123,Colombo", "071-0000000", 'A', new DateTime(17, 12, 23));
            _but.SetCDR("071-0000000", "071-1111111", new TimeSpan(12, 00, 00), 1200);

            double expected = 32;
            //Act
            Bill actual = _but.Generate();
            //Assert
            Assert.AreEqual(expected, actual.GetTax());


        }

        [TestMethod]
        public void OnGenerate_withOffPeakLongDistanceCall20SecondAndTax_ShouldAddTaxAmount()
        {

            //Arrange
            _but.AddCustomer("Supun Sethsara", "No:123,Colombo", "071-0000000", 'A', new DateTime(17, 12, 23));
            _but.SetCDR("071-0000000", "071-1111111", new TimeSpan(12, 00, 00), 20);

            double expected = 20.6;
            //Act
            Bill actual = _but.Generate();
            //Assert
            Assert.AreEqual(expected, actual.GetTax());


        }


        [TestMethod]
        public void OnGenerate_withOffPeakLongDistanceCall1Minutes_ShouldAddAmount()
        {

            //Arrange
            _but.AddCustomer("Supun Sethsara", "No:123,Colombo", "071-0000000", 'A', new DateTime(17, 12, 23));
            _but.SetCDR("071-0000000", "071-1111111", new TimeSpan(12, 00, 00), 20);

            double expected = 20.6+100+3;
            //Act
            Bill actual = _but.Generate();
            //Assert
            Assert.AreEqual(expected, actual.GetAmount());


        }



        [TestMethod]
        public void OnGenerate_withMultiplePeakLocalCall20Second_ShouldAddAmount()
        {

            //Arrange
            _but.AddCustomer("Supun Sethsara", "No:123,Colombo", "071-0000000", 'A', new DateTime(17, 12, 23));
            _but.SetCDR("071-0000000", "071-1111111", new TimeSpan(12, 00, 00), 20);
            _but.SetCDR("071-0000000", "071-1111111", new TimeSpan(12, 00, 00), 20);
            _but.SetCDR("071-0000000", "071-1111111", new TimeSpan(12, 00, 00), 20);

            double expected = 100+(3*3)+21.8;
            //Act
            Bill actual = _but.Generate();
            //Assert
            Assert.AreEqual(expected, actual.GetAmount());


        }



        [TestMethod]
        public void OnGenerate_withDifferentTimeAndMinutes_ShouldAddAmount()
        {

            //Arrange
            _but.AddCustomer("Supun Sethsara", "No:123,Colombo", "071-0000000", 'A', new DateTime(17, 12, 23));
            _but.SetCDR("071-0000000", "071-1111111", new TimeSpan(12, 00, 00), (60*3));
            _but.SetCDR("071-0000000", "073-1111111", new TimeSpan(20, 00, 00), (60 * 5));
            _but.SetCDR("071-0000000", "074-1111111", new TimeSpan(8, 00, 00), (60 * 3));

            double totalCharge = 100 + (3*3)+(4*5)+(5*3);
            double tax = totalCharge*0.2;
            double expected = totalCharge+tax;
            //Act
            Bill actual = _but.Generate();
            //Assert
            Assert.AreEqual(expected, actual.GetAmount());


        }


        public void OnGenerate_withMultiplePeakLocalCallsAndOthersCDR_ShouldAddAmount()
        {


            //Arrange
            _but.AddCustomer("Supun Sethsara", "No:123,Colombo", "071-0000000", 'A', new DateTime(17, 12, 23));
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
            //Assert
            Assert.AreEqual(expected, actual.GetAmount());


        }

        //Off peak to peak Local call

        [TestMethod]
        public void OnGenerate_withOffpeakToPeakLocalCall_ShouldAddAmount()
        {

            //Arrange
            _but.AddCustomer("Supun Sethsara", "No:123,Colombo", "071-0000000", 'A', new DateTime(17, 12, 23));
            _but.SetCDR("071-0000000", "071-1111111", new TimeSpan(7, 59, 00), (60*4));

            double totalCharge = 100 + (1*2)+ (3 * 3);
            double tax = totalCharge * 0.2;
            double expected = totalCharge + tax;
            //Act
            Bill actual = _but.Generate();
            //Assert
            Assert.AreEqual(expected, actual.GetAmount());


        }


        //peak to off peak Local call

        [TestMethod]
        public void OnGenerate_withpeakToPeakOffLocalCall_ShouldAddAmount()
        {

            //Arrange
            _but.AddCustomer("Supun Sethsara", "No:123,Colombo", "071-0000000", 'A', new DateTime(17, 12, 23));
            _but.SetCDR("071-0000000", "071-1111111", new TimeSpan(19, 59, 00), (60 * 4));

            double totalCharge = 100 + (1 * 3) + (3 * 2);
            double tax = totalCharge * 0.2;
            double expected = totalCharge + tax;
            //Act
            Bill actual = _but.Generate();
            //Assert
            Assert.AreEqual(expected, actual.GetAmount());


        }



        //Off peak to peak Long Distance call

        [TestMethod]
        public void OnGenerate_withOffpeakToPeakLongDistanceCall_ShouldAddAmount()
        {

            //Arrange
            _but.AddCustomer("Supun Sethsara", "No:123,Colombo", "071-0000000", 'A', new DateTime(17, 12, 23));
            _but.SetCDR("071-0000000", "072-1111111", new TimeSpan(7, 59, 00), (60 * 4));

            double totalCharge = 100 + (1 * 4) + (3 * 5);
            double tax = totalCharge * 0.2;
            double expected = totalCharge + tax;
            //Act
            Bill actual = _but.Generate();
            //Assert
            Assert.AreEqual(expected, actual.GetAmount());


        }


        //peak to off peak Local call

        [TestMethod]
        public void OnGenerate_withpeakToPeakOffLongDistanceCall_ShouldAddAmount()
        {

            //Arrange
            _but.AddCustomer("Supun Sethsara", "No:123,Colombo", "071-0000000", 'A', new DateTime(17, 12, 23));
            _but.SetCDR("071-0000000", "072-1111111", new TimeSpan(19, 59, 00), (60 * 4));

            double totalCharge = 100 + (1 * 5) + (3 * 4);
            double tax = totalCharge * 0.2;
            double expected = totalCharge + tax;
            //Act
            Bill actual = _but.Generate();
            //Assert
            Assert.AreEqual(expected, actual.GetAmount());


        }





        ///////Package B test/////

        [TestMethod]
        public void OnGenerate_withPackageBLocalCall_ShouldAddAmount()
        {

            //Arrange
            _but.AddCustomer("Supun Sethsara", "No:123,Colombo", "071-0000000", 'B', new DateTime(17, 12, 23));
            _but.SetCDR("071-0000000", "071-1111111", new TimeSpan(09, 00, 00), 60);

            double totalCharge = 100 + 4;
            double tax = totalCharge * 0.2;
            double expected = totalCharge + tax;
            //Act
            Bill actual = _but.Generate();
            //Assert
            Assert.AreEqual(expected, actual.GetAmount());


        }

        [TestMethod]
        public void OnGenerate_withPackageBPeekLongDistanceCall_ShouldAddAmount()
        {

            //Arrange
            _but.AddCustomer("Supun Sethsara", "No:123,Colombo", "071-0000000", 'B', new DateTime(17, 12, 23));
            _but.SetCDR("071-0000000", "072-1111111", new TimeSpan(09, 00, 00), 60);

            double totalCharge = 100 +6;
            double tax = totalCharge * 0.2;
            double expected = totalCharge + tax;
            //Act
            Bill actual = _but.Generate();
            //Assert
            Assert.AreEqual(expected, actual.GetAmount());


        }

        [TestMethod]
        public void OnGenerate_withPackageBOffPeekLocalCall_ShouldAddAmount()
        {

            //Arrange
            _but.AddCustomer("Supun Sethsara", "No:123,Colombo", "071-0000000", 'B', new DateTime(17, 12, 23));
            _but.SetCDR("071-0000000", "071-1111111", new TimeSpan(21, 00, 00), 60);

            double totalCharge = 100 + 3;
            double tax = totalCharge * 0.2;
            double expected = totalCharge + tax;
            //Act
            Bill actual = _but.Generate();
            //Assert
            Assert.AreEqual(expected, actual.GetAmount());


        }

        [TestMethod]
        public void OnGenerate_withPackageBOffPeekLocal_ShouldAddAmount()
        {

            //Arrange
            _but.AddCustomer("Supun Sethsara", "No:123,Colombo", "071-0000000", 'B', new DateTime(17, 12, 23));
            _but.SetCDR("071-0000000", "072-1111111", new TimeSpan(21, 00, 00), 60);

            double totalCharge = 100 + 5;
            double tax = totalCharge * 0.2;
            double expected = totalCharge + tax;
            //Act
            Bill actual = _but.Generate();
            //Assert
            Assert.AreEqual(expected, actual.GetAmount());


        }


        [TestMethod]
        public void OnGenerate_withPackageBLocalPeekToOffPeek_ShouldAddAmount()
        {

            //Arrange
            _but.AddCustomer("Supun Sethsara", "No:123,Colombo", "071-0000000", 'B', new DateTime(17, 12, 23));
            _but.SetCDR("071-0000000", "071-1111111", new TimeSpan(19, 59, 30), 60);

            double totalCharge = 100 + (4*0.5)+(3*0.5);
            double tax = totalCharge * 0.2;
            double expected = totalCharge + tax;
            //Act
            Bill actual = _but.Generate();
            //Assert
            Assert.AreEqual(expected, actual.GetAmount());


        }


        [TestMethod]
        public void OnGenerate_withPackageBLocalPeekToOffPeekLongTime_ShouldAddAmount()
        {

            //Arrange
            _but.AddCustomer("Supun Sethsara", "No:123,Colombo", "071-0000000", 'B', new DateTime(17, 12, 23));
            _but.SetCDR("071-0000000", "075-1111111", new TimeSpan(19, 30, 30), 60*60);

            double totalCharge = 100 + (6 * 29.5) + (5 * 30.5);
            double tax = totalCharge * 0.2;
            double expected = totalCharge + tax;
            //Act
            Bill actual = _but.Generate();
            //Assert
            Assert.AreEqual(expected, actual.GetAmount());


        }



        [TestMethod]
        public void OnGenerate_withPackageCOffPeekLocalCall_ShouldAddAmount()
        {

            //Arrange
            _but.AddCustomer("Supun Sethsara", "No:123,Colombo", "071-0000000", 'C', new DateTime(17, 12, 23));
            _but.SetCDR("071-0000000", "071-1111111", new TimeSpan(06, 00, 00), 60);

            double totalCharge = 300 + (1 * 1);
            double tax = totalCharge * 0.2;
            double expected = totalCharge + tax;
            //Act
            Bill actual = _but.Generate();
            //Assert
            Assert.AreEqual(expected, actual.GetAmount());


        }




        [TestMethod]
        public void OnGenerate_withPackageDOffPeekLocalCall30Second_ShouldAddAmount()
        {

            //Arrange
            _but.AddCustomer("Supun Sethsara", "No:123,Colombo", "071-0000000", 'D', new DateTime(17, 12, 23));
            _but.SetCDR("071-0000000", "071-1111111", new TimeSpan(06, 00, 00), 30);

            double totalCharge = 300 +(double)2/60*30 ;
            double tax = totalCharge * 0.2;
            double expected = totalCharge + tax;
            //Act
            Bill actual = _but.Generate();
            //Assert
            Assert.AreEqual(expected, actual.GetAmount());


        }

        [TestMethod]
        public void OnGenerate_withPackageCOffPeekLongDistance_ShouldAddAmount()
        {

            //Arrange
            _but.AddCustomer("Supun Sethsara", "No:123,Colombo", "071-0000000", 'C', new DateTime(17, 12, 23));
            _but.SetCDR("071-0000000", "072-1111111", new TimeSpan(06, 00, 00), 60);

            double totalCharge = 300 + (2 * 1);
            double tax = totalCharge * 0.2;
            double expected = totalCharge + tax;
            //Act
            Bill actual = _but.Generate();
            //Assert
            Assert.AreEqual(expected, actual.GetAmount());


        }


        [TestMethod]
        public void OnGenerate_withPackageCPeekLocalCallPeekToOffPeek1min_ShouldAddAmount()
        {

            //Arrange
            _but.AddCustomer("Supun Sethsara", "No:123,Colombo", "071-0000000", 'C', new DateTime(17, 12, 23));
            _but.SetCDR("071-0000000", "071-1111111", new TimeSpan(12, 00, 00), 60);

            double totalCharge = 300 + (2 * 1);
            double tax = totalCharge * 0.2;
            double expected = totalCharge + tax;
            //Act
            Bill actual = _but.Generate();
            //Assert
            Assert.AreEqual(expected, actual.GetAmount());


        }


        [TestMethod]
        public void OnGenerate_withPackageCOffPeekLongDistanceCallPeekToOffPeekLongTime_ShouldAddAmount()
        {

            //Arrange
            _but.AddCustomer("Supun Sethsara", "No:123,Colombo", "071-0000000", 'C', new DateTime(17, 12, 23));
            _but.SetCDR("071-0000000", "072-1111111", new TimeSpan(19, 30, 30), 60 * 60);

            double totalCharge = 300 + (3 * 30) + (2 * 31);
            double tax = totalCharge * 0.2;
            double expected = totalCharge + tax;
            //Act
            Bill actual = _but.Generate();
            //Assert
            Assert.AreEqual(expected, actual.GetAmount());


        }


        [TestMethod]
        public void OnGenerate_withPackageDOffPeekLongDistanceCallPeekToOffPeekLongTime_ShouldAddAmount()
        {

            //Arrange
            _but.AddCustomer("Supun Sethsara", "No:123,Colombo", "071-0000000", 'D', new DateTime(17, 12, 23));
            _but.SetCDR("071-0000000", "072-1111111", new TimeSpan(19, 30, 30), 60 * 60);

            double totalCharge = 300 + 5*29.5+4*30.5;
            double tax = totalCharge * 0.2;
            double expected = totalCharge + tax;
            //Act
            Bill actual = _but.Generate();
            //Assert
            Assert.AreEqual(expected, actual.GetAmount());


        }


        [TestMethod]
        public void OnGenerate_withPackageALocalCallFullDayCall_ShouldAddAmount()
        {

            //Arrange
            _but.AddCustomer("Supun Sethsara", "No:123,Colombo", "071-0000000", 'A', new DateTime(17, 12, 23));
            _but.SetCDR("071-0000000", "071-1111111", new TimeSpan(00, 00, 00), 60 * 60 * 24);

            double totalCharge = 100 + 3*60*12 + 2*60*12;
            double tax = totalCharge * 0.2;
            double expected = totalCharge + tax;
            //Act
            Bill actual = _but.Generate();
            //Assert
            Assert.AreEqual(expected, actual.GetAmount());


        }



        [TestMethod]
        public void OnGenerate_withPackageALocalCallExceedingLimits_ShouldAddAmount()
        {

            //Arrange
            _but.AddCustomer("Supun Sethsara", "No:123,Colombo", "071-0000000", 'A', new DateTime(17, 12, 23));
            _but.SetCDR("071-0000000", "071-1111111", new TimeSpan(07, 00, 00), 60 * 60 * 14);

            double totalCharge = 100 + (3 * 60 * 12) + (2 * 60 * 2);
            double tax = totalCharge * 0.2;
            double expected = totalCharge + tax;
            //Act
            Bill actual = _but.Generate();
            //Assert
            Assert.AreEqual(expected, actual.GetAmount());


        }













    }
}
