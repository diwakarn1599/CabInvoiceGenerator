using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    public class Ride
    {
        public int time;
        public double distance;

        //Constructor for setting new distance and time
        public Ride(int time, double distance)
        {
            this.time = time; 
            this.distance = distance;
        }
    }
}
