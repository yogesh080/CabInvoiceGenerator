namespace cabInvoiceGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to taxi Service:");
            Console.WriteLine("Premium fare");
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.PRIMIUM);
            double fare = invoiceGenerator.CalculateFare(2.0, 5);
            Console.WriteLine($"Fare: {fare}");

        }
    }
}