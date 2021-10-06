using Microsoft.AspNetCore.Components;
using ShoppingCartSample.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCartSample.Components
{
    public partial class ShoppingCart
    {
       
        [Inject]
        public IItemsService ItemsService { get; set; }

        private List<CartItem> _items = new()
        {
            new CartItem
            {
                Id = "543",
                Name = "Surface Laptop Studio",
                ItemPrice = 2500,
                Quantity = 2,
                TotalPrice = 5000,
            },
            new CartItem
            {
                Id = "65432",
                Name = "Surface Pro",
                ItemPrice = 2200,
                Quantity = 1,
                TotalPrice = 2200,
            }
        };

        protected override void OnInitialized()
        {
            //_items = GetCartListFromCart();
        }

        private List<CartItem> GetCartListFromCart()
        {
            var allItems = ItemsService.ListAllItems(); 
            var groupedItems = ItemsService.GetInCartItemIds().GroupBy(i => i).Select(i => new
            {
                Item = allItems.SingleOrDefault(item => item.Id == i.Key),
                Quantity = i.Count()
            });

            return groupedItems.Select(i => new CartItem
            {
                Id = i.Item.Id,
                Quantity = i.Quantity,
                ItemPrice = i.Item.Price,
                Name = i.Item.Name,
                TotalPrice = i.Quantity * i.Item.Price
            }).ToList();
        }

    }

    public class CartItem
    {
        public string Name { get; set; }

        public string Id { get; set; }

        public int Quantity { get; set; }

        public decimal ItemPrice { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
