using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VPExam.DBContext;
using VPExam.Models;

namespace VPExam.Repository
{
    public class CartRepository
    {
        public int GetTotal()
        {
            using (var context = new Items())
            {
                return context.CartsDetails.ToList<Cart>().Count;
            }
        }

        public void AddItem(Cart cart)
        {
            using (var context = new Items())
            {
                context.CartsDetails.Add(cart);
                context.SaveChanges();
                context.Dispose();
            }
        }
        public void Remove(int id)
        {
            using (var context = new Items())
            {
                var cart = context.CartsDetails.SingleOrDefault(e => e.Id == id);
                context.CartsDetails.Remove(cart);
                context.SaveChanges();
                context.Dispose();
            }
        }
        private const int pageSize = 1000;
        public List<Cart> GetCarts(int? pageNumber)
        {
            var numberOfRecordToskip = pageNumber * pageSize;
            using (var context = new Items())
            {
                return context.CartsDetails.OrderBy(x => x.Id).Skip(Convert.ToInt32(numberOfRecordToskip)).Take(pageSize).ToList();
            }
        }
    }
}