using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantDb.ViewModel
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public int CustomerId  { get; set; }
        public int PaymentTypeId  { get; set; }
        public int ItemId    { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderNumber { get; set; }
        public decimal FinalTotal { get; set; }
        public IEnumerable<OrderDetailViewModel> ListOrderDetails { get; set; }

    }
}