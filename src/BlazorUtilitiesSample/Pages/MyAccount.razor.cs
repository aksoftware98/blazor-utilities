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
using BlazorUtilitiesSample;
using BlazorUtilitiesSample.Shared;
using AKSoftware.Blazor.Utilities;

namespace BlazorUtilitiesSample.Pages
{
    public partial class MyAccount
    {

        private string _username = UserSettings.DefaultUsername;

        private void UpdateUsername(KeyboardEventArgs args)
        {
            // Set the new value of the username 
            UserSettings.DefaultUsername = _username;

            // Send the updated
            // You can use the Send function to send the sender object with the value you want to send 
            MessagingCenter.Send(this, "username_updated", _username);
        }

    }
}