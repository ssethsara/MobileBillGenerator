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
            Customer actual= _but.AddCustomer("Supun Sethsara", "No:123,Colombo", "071-9283743", 1,new DateTime(17,12,23));
            //Act
            Customer expected = new Customer("Supun Sethsara", "No:123,Colombo", "071-9283743", 1, new DateTime(17, 12, 23));
       
            //Assert

            Assert.AreEqual(expected.getFullname(), actual.getFullname());
            Assert.AreEqual(expected.getBillingAddress(), actual.getBillingAddress());
            Assert.AreEqual(expected.getPhoneNumber(), actual.getPhoneNumber());
            Assert.AreEqual(expected.getPackageCode(), actual.getPackageCode());
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
            Customer expected=_but.AddCustomer("Supun Sethsara", "No:123,Colombo", "071-0000000", 1, new DateTime(17, 12, 23));
            _but.SetCDR("071-0000000", "071-1111111", new TimeSpan(12, 00, 00), 30);
            _but.SetCDR("071-0000000", "071-1111111", new TimeSpan(08, 00, 00), 15);

            //Act
            Bill actual = _but.Generate();
            //Assert
            Assert.AreEqual(expected.getFullname(), actual.GetCustomer().getFullname());
            Assert.AreEqual(expected.getBillingAddress(), actual.GetCustomer().getBillingAddress());
            Assert.AreEqual(expected.getPhoneNumber(), actual.GetCustomer().getPhoneNumber());
            Assert.AreEqual(expected.getPackageCode(), actual.GetCustomer().getPackageCode());
            Assert.AreEqual(expected.getRegisteredDate(), actual.GetCustomer().getRegisteredDate());

        }



        //Peak Basic Test

        [TestMethod]
        public void OnGenerate_withPeakLocalCall1Miniute_ShouldAddTotalChargeToBill()
        {

            //Arrange
            _but.AddCustomer("Supun Sethsara", "No:123,Colombo", "071-0000000", 1, new DateTime(17, 12, 23));
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
            _but.AddCustomer("Supun Sethsara", "No:123,Colombo", "071-0000000", 1, new DateTime(17, 12, 23));
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
            _but.AddCustomer("Supun Sethsara", "No:123,Colombo", "071-0000000", 1, new DateTime(17, 12, 23));
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
            _but.AddCustomer("Supun Sethsara", "No:123,Colombo", "071-0000000", 1, new DateTime(17, 12, 23));
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
            _but.AddCustomer("Supun Sethsara", "No:123,Colombo", "071-0000000", 1, new DateTime(17, 12, 23));
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
            _but.AddCustomer("Supun Sethsara", "No:123,Colombo", "071-0000000", 1, new DateTime(17, 12, 23));
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
            _but.AddCustomer("Supun Sethsara", "No:123,Colombo", "071-0000000", 1, new DateTime(17, 12, 23));
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
            _but.AddCustomer("Supun Sethsara", "No:123,Colombo", "071-0000000", 1, new DateTime(17, 12, 23));
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
            _but.AddCustomer("Supun Sethsara", "No:123,Colombo", "071-0000000", 1, new DateTime(17, 12, 23));
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
            _but.AddCustomer("Supun Sethsara", "No:123,Colombo", "071-0000000", 1, new DateTime(17, 12, 23));
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
            _but.AddCustomer("Supun Sethsara", "No:123,Colombo", "071-0000000", 1, new DateTime(17, 12, 23));
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
            _but.AddCustomer("Supun Sethsara", "No:123,Colombo", "071-0000000", 1, new DateTime(17, 12, 23));
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
            _but.AddCustomer("Supun Sethsara", "No:123,Colombo", "071-0000000", 1, new DateTime(17, 12, 23));
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
            _but.AddCustomer("Supun Sethsara", "No:123,Colombo", "071-0000000", 1, new DateTime(17, 12, 23));
            _but.SetCDR("071-0000000", "072-1111111", new TimeSpan(20, 00, 00), 140);

            double expected = 12;
            //Act
            Bill actual = _but.Generate();
            //Assert
            Assert.AreEqual(expected, actual.GetTotalCallCharge());


        }

    }
}
