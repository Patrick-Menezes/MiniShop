namespace MiniShop.Models
{
    public class Payment
    {
        public int Id { get; set; } 
        public IPaymentMethod PaymentMethod { get; set; }
        public bool IsPaid {  get; set; }
        public DateTime PaymentDate {  get; set; }

        public void ProcessPayment (Decimal amount)
        {
            IsPaid = PaymentMethod.ProcessPayment (amount);
            Console.WriteLine(PaymentMethod.GetPaymentDetails());
        }


    }
}
