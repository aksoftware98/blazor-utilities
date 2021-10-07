namespace ShoppingCartSample.Models
{
	/// <summary>
	/// CartItem is a class that will be used to represent each item in the shopping cart
	/// </summary>
	public class CartItem
    {
        public string Name { get; set; }

        public string Id { get; set; }

        public int Quantity { get; set; }

        public decimal ItemPrice { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
