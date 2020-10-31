using System;
using System.Collections.Generic;
using System.Text;

namespace Cab_Invoice_Generator
{
    public class InvoiceGenerator
    {
        public RideRepository rideRepository;

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
            double totalFare = 0;
            foreach (Ride ride in rides)
            {
                totalFare += this.CalculateFare(ride.distance, ride.time);
            }
            return new InvoiceSummary(rides.Length, totalFare);
        }

        /// <summary>
        /// Function to Add Rides For UserId.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="rides"></param>
        public void AddRides(string userId, Ride[] rides)
        {
            rideRepository.AddRide(userId, rides);
        }

        /// <summary>
        /// Function to Get Summary By UserId.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public InvoiceSummary GetInvoiceSummary(string userId)
        {
            return this.CalculateFare(rideRepository.GetRides(userId));
        }
    }
}
