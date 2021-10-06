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

namespace ShoppingCartSample.Components
{
    public partial class ProductsList
    {

        [Inject]
        public IItemsService ItemsService { get; set; }

        private IEnumerable<Item> _items => ItemsService.ListAllItems();

    }
}