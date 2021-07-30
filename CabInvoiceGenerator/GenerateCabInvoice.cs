using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    public class GenerateCabInvoice
    {
        double ratePerKm;
        double minimumCabFare;
        double ratePerMin;

        //Enum to decide type of ride
        public enum RideType
        {
            PREMIUM,NORMAL
        }

        
        public GenerateCabInvoice(RideType type)
        {
            if (type.Equals(RideType.NORMAL))
            {
                ratePerKm = 10;
                minimumCabFare = 5;
                ratePerMin = 1;
            }
            if (type.Equals(RideType.PREMIUM))
            {
                ratePerKm = 15;
                minimumCabFare = 20;
                ratePerMin = 2;
            }


        }
        /// <summary>
        /// method to get total fare of cab ride
        /// </summary>
        /// <param name="time"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        public double GetTotalFare(int time,double distance)
        {
            double fare = default;
            try
            {
                
                if (time <= 0)
                {
                    throw new CabInvoiceCustomException(CabInvoiceCustomException.ExceptionType.INVALID_TIME, "Time is invalid");
                }
                if (distance <= 0)
                {
                    throw new CabInvoiceCustomException(CabInvoiceCustomException.ExceptionType.INVALID_DISTANCE, "Distance is invalid");
                }
                //Calculate total fare
                fare = (distance * ratePerKm) + (ratePerMin * time);
                //compare minimum fare and calculated fare return the maximum one
                return Math.Max(fare, minimumCabFare);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public double GetAggregateFare(Ride[] cabRides)
        {
            double aggFare = default;
            if (cabRides.Length == 0) 
                throw new CabInvoiceCustomException(CabInvoiceCustomException.ExceptionType.INVALID_RIDE_LIST, "Ride list id invalid");
            foreach(var i in cabRides)
            {
                aggFare += GetTotalFare(i.time,i.distance);
            }
            return aggFare;
        }
        /// <summary>
        /// Method to get Invoice summary
        /// </summary>
        /// <param name="cabRides"></param>
        /// <returns></returns>
        public string GetInvoiceSummary(Ride[] cabRides)
        {
            double totalFare = GetAggregateFare(cabRides);
            InvoiceSummary summary = new InvoiceSummary(cabRides.Length,totalFare);
            return $"Total number of rides = {summary.totalRides} \nTotalFare ={summary.totalFare} \nAverageFare = {summary.avgFare}";
        }

        
    }
}
