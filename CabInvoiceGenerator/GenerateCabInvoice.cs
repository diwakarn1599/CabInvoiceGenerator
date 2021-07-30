﻿using System;
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


        }
        /// <summary>
        /// method to get total fare of cab ride
        /// </summary>
        /// <param name="time"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        public double GetTotalFare(int time,double distance)
        {
            double fare = 0;
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

        
    }
}
