using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Microsoft.JSInterop;
using ShoppingCartSample;
using ShoppingCartSample.Shared;
using ShoppingCartSample.Services;
using ShoppingCartSample.Models;
using AKSoftware.Blazor.Utilities;

namespace ShoppingCartSample.Components
{
    public partial class ProductsList
    {

        [Inject]
        public IItemsService ItemsService { get; set; }

        private IEnumerable<Item> _items => ItemsService.ListAllItems();


        protected override void OnInitialized()
        {
            // Subscribe to the item_removed message and just refresh the state of the current component to recalculate the items
            MessagingCenter.Subscribe<ShoppingCart, Item>(this, "cartitem_removed", (sender, args) =>
            {
                StateHasChanged(); 
            });
        }

        /// <summary>
        /// Add item to the cart and push a message holds the added item
        /// </summary>
        /// <param name="itemId"></param>
        private void AddItemToCart(string itemId)
        {
            // Get the item from the store
            var item = _items.SingleOrDefault(i => i.Id == itemId);

            // Add the item to the cart
            ItemsService.AddItemToCart(itemId);

            // Send a message with the added item to the list holds the sender which is the current component, the kind of the message 'item_added' and the Item object as an argument 
            MessagingCenter.Send(this, "item_added", item);
        }

    }
}