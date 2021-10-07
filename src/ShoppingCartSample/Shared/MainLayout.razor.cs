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
using AKSoftware.Blazor.Utilities;
using ShoppingCartSample.Components;
using ShoppingCartSample.Models;

namespace ShoppingCartSample.Shared
{
    public partial class MainLayout
    {

		private decimal _totalAmount = 0;

		protected override void OnInitialized()
		{
			// Subscribe to the cartitem_removed message to reduce the total amount of the cart
			MessagingCenter.Subscribe<ShoppingCart, CartItem>(this, "cartitem_removed", (sender, item) =>
			{
				_totalAmount -= item.TotalPrice;
				StateHasChanged(); 
			});

			// Subscribe to the item_added message to increase the total amount of the cart
			MessagingCenter.Subscribe<ShoppingCart, Item>(this, "item_added", (sender, item) =>
			{
				_totalAmount += item.Price;
				StateHasChanged();
			});
		}

	}
}