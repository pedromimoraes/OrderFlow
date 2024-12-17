using OrderFlow.Entities.Enums;

namespace OrderFlow.Entities
{
    class Order
    {
        public DateTime Moment { get; private set; }
        public OrderStatus Status { get; private set; }
        public List<OrderItem> Items { get; private set; } = new List<OrderItem>();

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

    }
}