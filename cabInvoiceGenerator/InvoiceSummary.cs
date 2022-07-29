using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cabInvoiceGenerator
{
    public class InvoiceSummary
    {
        //variables 
        private int numberOfRides;
        private double totalFare;
        private double averageFare;



        public InvoiceSummary(int numberOfRides, double totalFare)
        {
            this.numberOfRides=numberOfRides;
            this.totalFare=totalFare;
            this.averageFare= this.totalFare/this.numberOfRides;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if(!(obj is InvoiceSummary)) return false;

            InvoiceSummary inputedObject = (InvoiceSummary)obj;
            return this.numberOfRides == inputedObject.numberOfRides && this.totalFare == inputedObject.totalFare;
        }
        public override int GetHashCode()
        {
            return this.numberOfRides.GetHashCode() ^ this.totalFare.GetHashCode() ^ this.averageFare.GetHashCode();
        }


    }
}
