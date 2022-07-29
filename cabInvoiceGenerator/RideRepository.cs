using System;
using System.Collections.Generic;
namespace cabInvoiceGenerator
{
    public class RideRepository
    {
        Dictionary<string,List<Ride>> userRides = null;
        public RideRepository()
        {
            this.userRides = new Dictionary<string, List<Ride>>();
        }

        public void AddRide(string userId, Ride[] rides)
        {
            bool rideList = this.userRides.ContainsKey(userId);
            try
            {
                if (!rideList)
                {
                    List<Ride> list = new List<Ride>();
                    list.AddRange(rides);
                    this.userRides.Add(userId, list);
                }

            }
            catch (CabInvoiceExpection)
            {

                throw new CabInvoiceExpection(CabInvoiceExpection.ExceptionType.INVALID_RIDE, "RIDE ARE NULL");
            }
        }

        public Ride[] GetRides(String userId)
        {
            try
            {
                return this.userRides[userId].ToArray();

            }
            catch (CabInvoiceExpection)
            {

                throw new CabInvoiceExpection(CabInvoiceExpection.ExceptionType.INVALID_USER_ID, "Invalid userID");

            }
        }
    }
}