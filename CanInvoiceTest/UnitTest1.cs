using Microsoft.VisualStudio.TestTools.UnitTesting;
using CabInvoiceGenerator;
using System;

namespace CanInvoiceTest
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Test fot normal cab ride
        /// </summary>
        [TestMethod]
        public void GetNormalRideFare()
        {
            try
            {
                //Arrange
                GenerateCabInvoice getInvoice = new GenerateCabInvoice(GenerateCabInvoice.RideType.NORMAL);
                int time = 5;
                double distance = 10.6,actual,expected = 111;
                //Act
                actual = getInvoice.GetTotalFare(time, distance);
                //Assert
                Assert.AreEqual(actual, expected);
                
            }
            catch(CabInvoiceCustomException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            
        }
        /// <summary>
        /// Test for invalid time
        /// </summary>
        [TestMethod]
        public void TestMethodForInvalidTime()
        {
            try
            {
                //Arrange
                GenerateCabInvoice getInvoice = new GenerateCabInvoice(GenerateCabInvoice.RideType.NORMAL);
                int time = 0;
                double distance = 10.6, actual, expected = 111;
                //Act
                actual = getInvoice.GetTotalFare(time, distance);
                //Assert
                Assert.AreEqual(actual, expected);

            }
            catch (CabInvoiceCustomException ex)
            {
                Assert.AreEqual(ex.Message, "Time is invalid");
            }


        }
        /// <summary>
        /// Test for invalid distance
        /// </summary>
        [TestMethod]
        public void TestMethodForInvalidDistance()
        {
            try
            {
                //Arrange
                GenerateCabInvoice getInvoice = new GenerateCabInvoice(GenerateCabInvoice.RideType.NORMAL);
                int time = 5;
                double distance = 0, actual, expected = 111;
                //Act
                actual = getInvoice.GetTotalFare(time, distance);
                //Assert
                Assert.AreEqual(actual, expected);

            }
            catch (CabInvoiceCustomException ex)
            {
                Assert.AreEqual(ex.Message, "Distance is invalid");
            }


        }


    }
}
