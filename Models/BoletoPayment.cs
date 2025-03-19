namespace MiniShop.Models
{
    public class BoletoPayment : IPaymentMethod
    {
        public string BoletoNumber { get; set; }

        public bool ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Gerando boleto de R$ {amount}...");
            return true; // Simulando sucesso
        }

        public string GetPaymentDetails()
        {
            return $"Pagamento com Boleto: Número {BoletoNumber}";
        }
    }

}
