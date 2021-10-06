using ShoppingCartSample.Models;
using System.Collections.Generic;

namespace ShoppingCartSample.Services
{
    public interface IItemsService
    {

        IEnumerable<Item> ListAllItems();

        void AddItemToCart(string itemId);

        void RemoveItemFromCart(string itemId);

    }
}
