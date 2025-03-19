using Microsoft.VisualBasic;

namespace MiniShop.Models
{
    public class CredicardPayment:IPaymentMethod
    {

        public string CardNumber { get; set; }
        public string CardHolder { get;set; }
        public string ExpirationDate {  get; set; }


        public bool ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processando pagamento de R$ {amount} via Cartão de Crédito...");
            return true; // Simulando pagamento bem-sucedido
        }

        public string GetPaymentDetails()
        {
            return $"Pagamento com Cartão de Crédito: {CardHolder}, Número: **** **** **** {CardNumber.Substring(CardNumber.Length - 4)}";
        }


    }
}
