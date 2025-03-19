namespace MiniShop.Models
{
    public interface IPaymentMethod
    {
        bool ProcessPayment(decimal amount);// metodo para processar o pagamento
        string GetPaymentDetails();//Retorna detalhes do pagamento

    }
}
