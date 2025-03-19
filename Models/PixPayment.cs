namespace MiniShop.Models
{
    public class PixPayment:IPaymentMethod
    {
        public string PixKey { get; set; }

        public bool ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processando pagamento de R$ {amount} via Pix...");
            return true; // Simulando sucesso
        }

        public string GetPaymentDetails()
        {
            return $"Pagamento via Pix: {PixKey}";
        }

    }
}
