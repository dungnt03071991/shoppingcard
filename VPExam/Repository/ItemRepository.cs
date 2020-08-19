using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VPExam.DBContext;
using VPExam.Models;

namespace VPExam.Repository
{
    public class ItemRepository
    {
        private const int pageSize = 1000;
        public List<Item> GetItems(int? pageNumber)
        {
            var numberOfRecordToskip = pageNumber * pageSize;
            using (var context = new Items())
            {
                return context.ItemsDetails.OrderBy(x => x.Id).Skip(Convert.ToInt32(numberOfRecordToskip)).Take(pageSize).ToList<Item>();
            }
        }
    }
}