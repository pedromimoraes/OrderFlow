namespace OrderFlow.Entities
{
    class OrderItem
    {
        public int Quantity { get; private set; }
        public double Price { get; private set; }

        public OrderItem(int quantity, Product product)
        {
            Quantity = quantity;
            Price = product.Price;
        }

        public double SubTotal()
        {
            return Price * Quantity;
        }
    }
}