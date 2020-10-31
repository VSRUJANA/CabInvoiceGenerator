using System;
using System.Collections.Generic;
using System.Text;

namespace Cab_Invoice_Generator
{
    public class InvoiceGenerator
    {
        // Function To Calculate Total Fare when distance and time of a ride are given
        public double CalculateFare(double distance, int time)
        {
            int costPerKilometer = 10;
            int costPerMinute = 1;
            int minimumFare = 5;
            double totalFare = distance * costPerKilometer + time * costPerMinute;
            if (totalFare < minimumFare)
                return minimumFare;
            return totalFare;
        }

        // Function To Calculate Total Fare and Generating Summary For Multiple Rides.
        public InvoiceSummary CalculateFare(Ride[] rides)
        {
            return null;
        }
    }
}
