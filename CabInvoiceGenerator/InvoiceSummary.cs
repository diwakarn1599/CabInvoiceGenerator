using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    public class InvoiceSummary
    {
        public int totalRides;
        public double totalFare, avgFare;

        /// <summary>
        /// Constructor for initializing rides and fares and getiing average fare
        /// </summary>
        /// <param name="rides"></param>
        /// <param name="fare"></param>
        public InvoiceSummary(int rides,double fare)
        {
            totalRides = rides;
            totalFare = fare;
            avgFare = totalFare / totalRides;
        }
    }
}
