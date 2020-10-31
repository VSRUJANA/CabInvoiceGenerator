using NUnit.Framework;
using Cab_Invoice_Generator;

namespace Cab_Invoice_Generator_Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GivenDistanceAndTime_CalculateFareMethodShould_ReturnTotalFare()
        {
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator();
            double distance = 20;
            int time = 45;

            // Calculating fare by passing the values of distance = 20km and time = 45 minutes
            double actualFare = invoiceGenerator.CalculateFare(distance, time);
            double expectedFare = 245;

            // Checking if the test case passes
            Assert.AreEqual(expectedFare, actualFare);
        }

        [Test]
        public void GivenDistanceAndTime_CalculateFareMethodShould_ReturnMinimumFare()
        {
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator();
            double distance = 0.2;
            int time = 2;

            // Calculating fare by passing the values of distance = 0.2km (200 m) and time = 2 minutes
            double actualFare = invoiceGenerator.CalculateFare(distance, time);
            double expectedFare = 5;

            // Checking if the test case passes
            Assert.AreEqual(expectedFare, actualFare);
        }

        [Test]
        public void Given5Rides_CalculateFareMethodShould_ReturnTotalFare()
        {
            Ride[] rides =
            {
                new Ride(1.0, 1),
                new Ride(2.0, 2),
                new Ride(3.0, 2),
                new Ride(4.0, 4),
                new Ride(5.0, 3)
            };
            double expected = 162;
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator();
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            double actual = summary.totalFare;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Given5Rides_InvoiceSummaryShould_ReturnEnhancedInvoiceSummary()
        {
            Ride[] rides =
            {
                new Ride(1.0, 1),
                new Ride(2.0, 2),
                new Ride(3.0, 2),
                new Ride(4.0, 4),
                new Ride(5.0, 3)
            };
            InvoiceSummary expected = new InvoiceSummary(5, 162);
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator();
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            Assert.AreEqual(summary, expected);
        }

        [Test]
        public void GivenUserId_InvoiceServiceShould_ReturnListOfRides()
        {
            Ride[] rides =
            {
                new Ride(1.0, 1),
                new Ride(2.0, 2),
                new Ride(3.0, 2),
                new Ride(4.0, 4),
                new Ride(5.0, 3)
            };
            string userId = "12345";
            RideRepository rideRepository = new RideRepository();
            rideRepository.AddRide(userId, rides);
            Ride[] actual = rideRepository.GetRides(userId);
            Assert.AreEqual(rides, null);
        }
    }
}