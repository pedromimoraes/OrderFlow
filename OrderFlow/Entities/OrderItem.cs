using System.Text;
using System.Globalization;

namespace OrderFlow.Entities
{
    class OrderItem
    {
        public int Quantity { get; private set; }
        public double Price { get; private set; }

        public Product Product { get; private set; }

        public OrderItem(int quantity, double price, Product product)
        {
            Quantity = quantity;
            Price = price;
            Product = product;
        }

        public double SubTotal()
        {
            return Price * Quantity;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append($"{Product.Name}, ${Product.Price.ToString("F2", CultureInfo.InvariantCulture)}, Quantity: {Quantity}, Subtotal: ${SubTotal().ToString("F2", CultureInfo.InvariantCulture)}");

            return stringBuilder.ToString();
        }
    }
}