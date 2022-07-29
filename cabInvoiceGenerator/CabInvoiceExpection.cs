using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cabInvoiceGenerator
{
    public class CabInvoiceExpection: Exception
    {
        public enum ExceptionType
        {
            INVALID_RIDE_TYPE,
            INVALID_DISTANCE,
            INVALID_TIME,
            INVALID_RIDE,
            INVALID_USER_ID
        }
        ExceptionType type;

        public CabInvoiceExpection(ExceptionType type, string messsage)
        {
            this.type = type;


        }
    }
    
}
