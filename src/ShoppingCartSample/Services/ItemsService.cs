using ShoppingCartSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartSample.Services
{

    public class ItemsService : IItemsService
    {

        #region Items store 
        private static List<Item> _items = new()
        {
            new Item
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Surface Laptop Studio",
                Price = 3250,
                Quantity = 10,
                Image = "/images/laptop-studio.webp",
            },
            new Item
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Surface Pro 8",
                Price = 1200,
                Quantity = 5,
                Image = "/images/pro-8.webp",
            },
            new Item
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Surface Pro X",
                Price = 1600,
                Quantity = 8,
                Image = "/images/pro-x.webp",
            },
            new Item
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Surface Laptop 4",
                Price = 999,
                Quantity = 10,
                Image = "/images/laptop-4.webp",
            },
            new Item
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Surface Duo 2",
                Price = 25,
                Quantity = 1600,
                Image = "/images/duo-2.webp",
            },
            new Item
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Surface Duo",
                Price = 1100,
                Quantity = 5,
                Image = "/images/duo.webp",
            },
            new Item
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Surface Go 3",
                Price = 1300,
                Quantity = 5,
                Image = "/images/go.webp",
            },
            new Item
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Surface Studio 2",
                Image = "/images/studio.webp",
                Price = 4500,
                Quantity = 2,
            }
        };
        #endregion 
        private static List<string> _cartItems = new();

        /// <summary>
        /// Add a specific item to cart and redeuce the quantity by 1
        /// </summary>
        /// <param name="itemId"></param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public void AddItemToCart(string itemId)
        {
            var item = _items.SingleOrDefault(i => i.Id == itemId);
            if (item == null)
                throw new ArgumentException("Item not found");

            if (item.Quantity == 0)
                throw new InvalidOperationException("Not available in the stock");

            item.Quantity--;
            _cartItems.Add(itemId);

        }

        /// <summary>
        /// Retrieve a collection with all the items in stock
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Item> ListAllItems()
        {
            return _items;
        }

        /// <summary>
        /// Remove the item from the cart or remove range of items if it's existing mutliple times and re-add the quantity to the stock
        /// </summary>
        /// <param name="itemId"></param>
        /// <exception cref="ArgumentException"></exception>
        public void RemoveItemFromCart(string itemId)
        {
            var item = _items.SingleOrDefault(i => i.Id == itemId);
            if (item == null)
                throw new ArgumentException("Item not found");
            var cartItems = _cartItems.Where(i => i == itemId);
            item.Quantity += cartItems.Count();
            foreach (var cartItem in cartItems)
            {
                _cartItems.Remove(cartItem);
            }
        }
    }

}
