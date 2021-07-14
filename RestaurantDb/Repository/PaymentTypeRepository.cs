using RestaurantDb.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace RestaurantDb.Repository
{
    public class PaymentTypeRepository
    {
        private RestaurantDBEntities context;
        public PaymentTypeRepository()
        {
            context = new RestaurantDBEntities();
        }



        public IEnumerable<SelectListItem> GetAllPAymentType()
        {
            IEnumerable<SelectListItem> objSelected = new List<SelectListItem>();

            objSelected = (from obj in context.PaymentTypes
                           select new SelectListItem()
                           {
                               Text = obj.PaymentTypeName,
                               Value = obj.PaymentTypeId.ToString(),
                               Selected = true
                           }).ToList();
            return objSelected;

            //context.Customers.ToList();

        }
    }
}