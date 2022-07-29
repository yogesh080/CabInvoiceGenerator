using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cabInvoiceGenerator
{
    public class InvoiceGenerator
    {
        //variable
        RideType rideType;
        private RideRepository rideRepository;

        //constants
        private readonly double MINIMUM_COST_PER_KM;
        private readonly int COST_PER_TIME;
        private readonly double MINIMUM_FARE;


        public InvoiceGenerator(RideType rideType)
        {
            this.rideType = rideType;
            this.rideRepository = new RideRepository();
            try
            {
                if (rideType.Equals(RideType.PRIMIUM))
                {
                    this.MINIMUM_COST_PER_KM = 15;
                    this.COST_PER_TIME = 2;
                    this.MINIMUM_FARE = 20;
                }
                else if (rideType.Equals(RideType.NORMAL))
                {
                    this.MINIMUM_COST_PER_KM = 10;
                    this.COST_PER_TIME = 1;
                    this.MINIMUM_FARE = 5;

                }

            }
            catch (CabInvoiceExpection)
            {

                throw new CabInvoiceExpection(CabInvoiceExpection.ExceptionType.INVALID_RIDE_TYPE, "Invalid ride type");
            }
        }


        public double CalculateFare(double distance, int time)
        {
            double totalfare = 0;
            try
            {
                totalfare = distance*MINIMUM_COST_PER_KM+time*COST_PER_TIME;

            }
            catch (CabInvoiceExpection)
            {
                if (rideType.Equals(null))
                {
                    throw new CabInvoiceExpection(CabInvoiceExpection.ExceptionType.INVALID_RIDE_TYPE, "invalid ride type");
                }
                if (distance <=0)
                {
                    throw new CabInvoiceExpection(CabInvoiceExpection.ExceptionType.INVALID_DISTANCE, "invalid DISTANCE");

                }
                if (time <0)
                {
                    throw new CabInvoiceExpection(CabInvoiceExpection.ExceptionType.INVALID_TIME, "invalid time");

                }

            }
            return Math.Max(totalfare, MINIMUM_FARE);

        }
        public InvoiceSummary CalculateFare(Ride[] rides)
        {
            double totalFare = 0;
            try
            {

                foreach (Ride ride in rides)
                {
                    totalFare += this.CalculateFare(ride.distance, ride.time);
                }
            }
            catch (CabInvoiceExpection)
            {
                if (rides == null)
                {
                    throw new CabInvoiceExpection(CabInvoiceExpection.ExceptionType.INVALID_RIDE_TYPE, "rides are null");
                }
            }
            return new InvoiceSummary(rides.Length, totalFare);
        }

        public void AddRides(string userID, Ride[] rides)
        {
            try
            {
                rideRepository.AddRide(userID, rides);

            }
            catch (CabInvoiceExpection)
            {
                if(rides == null)
                {
                    throw new CabInvoiceExpection(CabInvoiceExpection.ExceptionType.INVALID_RIDE, "Ride is Invalid");
                }

                throw;
            }
        }
        public InvoiceSummary GetInvoiceSummary(string userID)
        {
            try
            {
                return this.CalculateFare(rideRepository.GetRides(userID));
            }
            catch (CabInvoiceExpection)
            {

                    throw new CabInvoiceExpection(CabInvoiceExpection.ExceptionType.INVALID_USER_ID, "Invalid UserID");

            }
        }
    }
}
