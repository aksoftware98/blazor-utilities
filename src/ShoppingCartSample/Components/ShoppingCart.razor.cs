using AKSoftware.Blazor.Utilities;
using Microsoft.AspNetCore.Components;
using ShoppingCartSample.Models;
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

        private List<CartItem> _cartItems = new();

        protected override void OnInitialized()
        {
            _cartItems = GetCartListFromCart();

            // Subscribe to the item_added message sent from the ProductsList and fire a callback whenever a new item added to the cart 
            MessagingCenter.Subscribe<ProductsList, Item>(this, "item_added", (sender, args) =>
            {
                // Recaulcate the items in the cart 
                _cartItems = GetCartListFromCart();

                // Notify the UI about the change
                StateHasChanged(); 
            });
        }

        /// <summary>
        /// Remove a specific Item from Cart
        /// </summary>
        /// <param name="itemId"></param>
        private void RemoveItemFromCart(string itemId)
        {
            // Get the item id
            var item = ItemsService.ListAllItems().SingleOrDefault(i => i.Id == itemId);

            // Remove the item from the cart
            ItemsService.RemoveItemFromCart(itemId);

            // Send a message to notify other components about the removing process
            MessagingCenter.Send(this, "item_removed", item);
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

    /// <summary>
    /// CartItem is a class that will be used to represent objects in the 
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
