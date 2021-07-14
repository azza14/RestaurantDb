using RestaurantDb.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace RestaurantDb.Repository
{
    public class CustomerRepository
    {
        private RestaurantDBEntities context;
        public CustomerRepository()
        {
            context = new RestaurantDBEntities();
        }


        public IEnumerable<SelectListItem> GetAllCustomers()
        {
            IEnumerable<SelectListItem> objSelected = new List<SelectListItem>();

            objSelected = (from obj in context.Customers
                           select new SelectListItem()
                           {
                               Text = obj.CustomerName,
                               Value = obj.CustomerId.ToString(),
                               Selected = false
                           }).ToList();
            return objSelected;

            //context.Customers.ToList();

        }
    }
}