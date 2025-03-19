using MiniShop.Models.Enums;

namespace MiniShop.Models
{
    public class Order
    {
        public int Id { get; set; }
        public Client Client { get; set; }
        public List<CartItem> Items { get; set; }
        public decimal TotalPrice {  get; set; }
        public DateTime OrderDate { get; set; }
        public Payment Payment {  get; set; }
        public OrderStatus Status { get; set; }


        public Order() { }

        public Order(int id, Client client, decimal totalPrice, DateTime orderDate, Payment payment, OrderStatus status)
        {
            Id = id;
            Client = client;
            TotalPrice = totalPrice;
            OrderDate = orderDate;
            Payment = payment;
            Status = status;
        }
    }
}
