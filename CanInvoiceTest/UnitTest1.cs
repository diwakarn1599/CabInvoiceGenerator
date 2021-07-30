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
        /// Test for premium cab ride
        /// </summary>
        [TestMethod]
        public void GetPremiumRideFare()
        {
            try
            {
                //Arrange
                GenerateCabInvoice getInvoice = new GenerateCabInvoice(GenerateCabInvoice.RideType.PREMIUM);
                int time = 5;
                double distance = 10.6, actual, expected = 169;
                //Act
                actual = getInvoice.GetTotalFare(time, distance);
                //Assert
                Assert.AreEqual(actual, expected);

            }
            catch (CabInvoiceCustomException ex)
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
        /// <summary>
        /// Test for aggregate fare 
        /// </summary>
        [TestMethod]
        public void GetAggregateFare()
        {
            try
            {
                //Arrange
                GenerateCabInvoice getInvoice = new GenerateCabInvoice(GenerateCabInvoice.RideType.NORMAL);
                Ride[] cabRides = { new Ride(5, 10.6), new Ride(6, 10.6) }; 
                double actual, expected = 223;
                //Act
                actual = getInvoice.GetAggregateFare(cabRides);

                //Assert
                Assert.AreEqual(actual, expected);

            }
            catch (CabInvoiceCustomException ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        /// <summary>
        /// Test Method to get summary of invoice
        /// </summary>
        [TestMethod]
        public void GetInvoiceSummary()
        {
            try
            {
                //Arrange
                GenerateCabInvoice getInvoice = new GenerateCabInvoice(GenerateCabInvoice.RideType.NORMAL);
                Ride[] cabRides = { new Ride(5, 10.6), new Ride(6, 10.6) };
                string actual, expected = "Total number of rides = 2 \n TotalFare =223 \n AverageFare = 111.5";
                //Act
                actual = getInvoice.GetInvoiceSummary(cabRides);

                //Assert
                Assert.AreEqual(actual, expected);

            }
            catch (CabInvoiceCustomException ex)
            {
                Console.WriteLine(ex.Message);
            }


        }




    }
}
