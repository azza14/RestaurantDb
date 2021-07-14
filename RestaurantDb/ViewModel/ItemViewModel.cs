using System;

namespace RestaurantDb.ViewModel
{
    public class ItemViewModel
    {

        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public Nullable<decimal> ItemPrice { get; set; }
    }
}