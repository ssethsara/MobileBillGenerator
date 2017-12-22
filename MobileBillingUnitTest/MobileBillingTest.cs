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
            Customer actual= _but.AddCustomer("Supun Sethsara", "No:123,Colombo", 0719283743, 1,new DateTime(17,12,23));
            //Act
            Customer expected = new Customer("Supun Sethsara", "No:123,Colombo", 0719283743, 1, new DateTime(17, 12, 23));
       
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
            _but.SetCDR(0710232322, 0713422344, new TimeSpan(12, 00, 00), 30);
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
            CDR actual = _but.SetCDR(0710232322, 0713422344, new TimeSpan(12, 00, 00), 30);
            //Act
            CDR expected = new CDR(0710232322, 0713422344, new TimeSpan(12, 00, 00), 30);

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
            Customer expected=_but.AddCustomer("Supun Sethsara", "No:123,Colombo", 0710000000, 1, new DateTime(17, 12, 23));
            _but.SetCDR(0710000000, 0711111111, new TimeSpan(12, 00, 00), 30);
            _but.SetCDR(0710000000, 0711111111, new TimeSpan(08, 00, 00), 15);

            //Act
            Bill actual = _but.Generate();
            //Assert
            Assert.AreEqual(expected.getFullname(), actual.GetCustomer().getFullname());
            Assert.AreEqual(expected.getBillingAddress(), actual.GetCustomer().getBillingAddress());
            Assert.AreEqual(expected.getPhoneNumber(), actual.GetCustomer().getPhoneNumber());
            Assert.AreEqual(expected.getPackageCode(), actual.GetCustomer().getPackageCode());
            Assert.AreEqual(expected.getRegisteredDate(), actual.GetCustomer().getRegisteredDate());

        }



        [TestMethod]
        public void OnGenerate_withCustomerDetails_ShouldGenerateABillWithCustomerDetails()
        {

            //Arrange
            Customer expected = _but.AddCustomer("Supun Sethsara", "No:123,Colombo", 0710000000, 1, new DateTime(17, 12, 23));
            _but.SetCDR(0710000000, 0711111111, new TimeSpan(12, 00, 00), 30);
            _but.SetCDR(0710000000, 0711111111, new TimeSpan(08, 00, 00), 15);

            //Act
            Bill actual = _but.Generate();
            //Assert
            Assert.AreEqual(expected.getFullname(), actual.GetCustomer().getFullname());
            Assert.AreEqual(expected.getBillingAddress(), actual.GetCustomer().getBillingAddress());
            Assert.AreEqual(expected.getPhoneNumber(), actual.GetCustomer().getPhoneNumber());
            Assert.AreEqual(expected.getPackageCode(), actual.GetCustomer().getPackageCode());
            Assert.AreEqual(expected.getRegisteredDate(), actual.GetCustomer().getRegisteredDate());

        }
    }
}
