using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using KursovayaBlazorNet6.BusinessLogic;
using System;
using KursovayaBlazorNet6.Helpers;

namespace KursovayaBlazorNet6.Components
{
    [ViewComponent]
    public class CartViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var cart = HttpContext.LoadFromSession<Cart>();
            return View(cart);
        }

        //public Cart GetCart()
        //{
        //    Cart cart = null;
        //    string json = HttpContext.Session.GetString("Cart");

        //    if (string.IsNullOrEmpty(json))
        //    {
        //        cart = new Cart();

        //    }
        //    else
        //    {
        //        cart = JsonConvert.DeserializeObject<Cart>(json);
        //    }
        //    return cart;
        //}
    }
}
