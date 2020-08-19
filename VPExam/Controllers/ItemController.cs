using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VPExam.Repository;

namespace VPExam.Controllers
{
    public class ItemController : Controller
    {
        private ItemRepository productRepository;
        public ActionResult Index()
        {
            int? pageNumber=0;
            productRepository = new ItemRepository();
            var model = productRepository.GetItems(pageNumber);
            return View(model);
        }
        /// <summary>
        /// Get All Item
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ItemList(int? pageNumber)
        {
            productRepository = new ItemRepository();
            var model = productRepository.GetItems(pageNumber);
            return PartialView("~/Views/Item/ItemList.cshtml", model);
        }         
    }
}
