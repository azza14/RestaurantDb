using RestaurantDb.Models;
using RestaurantDb.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantDb.Repository
{
    public class OrderRepository
    {
        private RestaurantDBEntities context;
        public OrderRepository()
        {
            context = new RestaurantDBEntities();

        }

        public bool AddOrder(OrderViewModel orderViewModel)
        {
            Order objectOrder = new Order();

            objectOrder.CustomerId = orderViewModel.CustomerId;
            objectOrder.ItemId = orderViewModel.ItemId;
            objectOrder.FinalTotal = orderViewModel.FinalTotal;
            objectOrder.OrderDate = DateTime.Now;
            objectOrder.OrderNumber = 
                string.Format("{0:ddmmyyyyhhmmss}", DateTime.Now);
            objectOrder.PaymentTypeId = orderViewModel.PaymentTypeId;

            context.Orders.Add(objectOrder);
            context.SaveChanges();

            int orderId = objectOrder.OrderId;
            foreach (var item in orderViewModel.ListOrderDetails)
            {
                OrderDetail orderDetail = new OrderDetail();

                orderDetail.OrderId = orderId;
                orderDetail.Discount = item.Discount;
                orderDetail.UnitPrice = item.UnitPrice;
                orderDetail.ItemId = item.ItemId;
                orderDetail.Quantity = item.Quantity;
                orderDetail.Total = item.Total;

                context.OrderDetails.Add(orderDetail);
                context.SaveChanges();

            }

            //objectOrder.OrderDetails;


            return true;
        }
    }
}