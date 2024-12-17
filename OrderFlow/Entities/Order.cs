using System.Text;
using OrderFlow.Entities.Enums;

namespace OrderFlow.Entities
{
    class Order
    {
        public DateTime Moment { get; private set; }
        public OrderStatus Status { get; private set; }
        public List<OrderItem> Items { get; private set; } = new List<OrderItem>();
        public Client Client { get; private set; }

        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }

        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }
        public void RemoveItem(OrderItem item)
        {
            Items.Remove(item);
        }

        public double Total()
        {
            double sum = 0.0;

            foreach (OrderItem item in Items)
            {
                sum += item.SubTotal();
            }
            return sum;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("ORDER SUMMARY:");
            stringBuilder.AppendLine($"Order moment: {Moment.ToString("dd/MM/yyyy HH:mm:ss")}");
            stringBuilder.Append($"Order status: {Status.ToString()}");
            stringBuilder.Append($"Client: {Client.Name} {Client.BirthDate.ToString("dd/MM/yyyy")} - {Client.Email}");
            stringBuilder.AppendLine("Order items:");

            foreach (OrderItem item in Items)
            {
                stringBuilder.AppendLine(item.ToString());
            }

            stringBuilder.AppendLine($"Total price: ${Total():F2}");

            return stringBuilder.ToString();
        }
    }
}