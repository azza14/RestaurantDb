using RestaurantDb.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace RestaurantDb.Repository
{
    public class ItemRepository
    {
        private RestaurantDBEntities context;
        public ItemRepository()
        {
            context = new RestaurantDBEntities();
        }


        public IEnumerable<SelectListItem> GetAllItems()
        {
            IEnumerable<SelectListItem> objSelected = new List<SelectListItem>();

            objSelected = (from obj in context.Items
                           select new SelectListItem()
                           {
                               Text = obj.ItemName,
                               Value = obj.ItemId.ToString(),
                               Selected = false
                           }).ToList();
            return objSelected;

            //context.Customers.ToList();

        }
    }
}