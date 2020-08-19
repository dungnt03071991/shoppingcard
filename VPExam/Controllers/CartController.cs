using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VPExam.Models;
using VPExam.Repository;

namespace VPExam.Controllers
{
    public class CartController : Controller
    {
        private CartRepository cartRepository = new CartRepository();
        // GET: Cart
        public ActionResult Index()
        {
            ModelState.Clear();
            int? pageNumber = 0;
            var model = cartRepository.GetCarts(pageNumber);
            return View(model);
        }
        /// <summary>
        /// Add item in to card
        /// </summary>
        /// <param name="ItemId"></param>
        /// <param name="ItemName"></param>
        /// <returns></returns>
        [HttpGet]
        public int AddItem(int ItemId, string ItemName)
        {
            Cart cart = new Cart();
            int count = GetTotal();
            cart.ItemId = ItemId;
            cart.ItemName = ItemName + " in cart " + count++;
            cartRepository.AddItem(cart);
            return cart.Id;
        }
        /// <summary>
        /// Get All item
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult IteamList(int? pageNumber)
        {
            ModelState.Clear();
            var model = cartRepository.GetCarts(pageNumber);
            return PartialView("~/Views/Cart/CartList.cshtml", model);
        }
        /// <summary>
        /// Delete item
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult RemoveItem(int Id)
        {
            int? pageNumber = 0;
            ModelState.Clear();
            cartRepository.Remove(Id);
            var redirectUrl = new UrlHelper(Request.RequestContext).Action("Index", "Cart");
            var model = cartRepository.GetCarts(pageNumber);
            return PartialView("~/Views/Cart/CartList.cshtml", model);
        }
        /// <summary>
        /// Count item
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public int GetTotal()
        {
            var count = cartRepository.GetTotal();
            return count;
        }
    }
}