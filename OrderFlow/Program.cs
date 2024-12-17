using OrderFlow.Entities;
using OrderFlow.Entities.Enums;
using System.Globalization;
using System.Text;

namespace OderFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter client data:");

            System.Console.Write("Name: ");
            string name = Console.ReadLine();

            System.Console.Write("Email: ");
            string email = Console.ReadLine();

            System.Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime birthDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

            Client client = new Client(name, email, birthDate);

            System.Console.WriteLine("Enter order data:");

            System.Console.Write("Status (PendingPayment | Processing | Shipped | Delivered): ");
            string status = Console.ReadLine();

            System.Console.Write("How many items to this order? ");
            int items = int.Parse(Console.ReadLine());

            Order order = new Order(DateTime.Now, Enum.Parse<OrderStatus>(status));

            for (int i = 1; i <= items; i++)
            {
                System.Console.WriteLine($"Enter #{i} item data:");

                System.Console.Write("Product name: ");
                string productName = Console.ReadLine();

                System.Console.Write("Product price: ");
                double productPrice = double.Parse(Console.ReadLine());

                System.Console.Write("Quantity: ");
                int productQuantity = int.Parse(Console.ReadLine());

                Product product = new Product(productName, productPrice);
                OrderItem orderItem = new OrderItem(productQuantity, product);
                order.AddItem(orderItem);

            }
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("ORDER SUMMARY:");
            stringBuilder.AppendLine($"Order moment: {order.Moment.ToString()}");
            stringBuilder.Append($"Order status: {order.Status.ToString()}");
            stringBuilder.Append($"Client: {client.Name} {client.BirthDate.ToString()} - {client.Email}");
            stringBuilder.AppendLine("Order items:");

            foreach(OrderItem orderItem in order.Items)
            {
                stringBuilder.AppendLine($"Quantity: {}, ${orderItem.Price}, Quantity: {orderItem.Quantity}, Subtotal: ${orderItem.SubTotal()}");
            }

        }
    }
}