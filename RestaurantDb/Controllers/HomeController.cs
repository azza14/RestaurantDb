using RestaurantDb.Models;
using RestaurantDb.Repository;
using RestaurantDb.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace RestaurantDb.Controllers
{
    public class HomeController : Controller
    {
        private RestaurantDBEntities context;

        public HomeController()
        {
            context = new RestaurantDBEntities();

        }
        // GET: Home
        public ActionResult Index()
        {

            CustomerRepository customerRepository = new CustomerRepository();
            ItemRepository itemRepository = new ItemRepository();
            PaymentTypeRepository paymentTypeRepository = new PaymentTypeRepository();
            var objectSelectedList = new Tuple<IEnumerable<SelectListItem>, IEnumerable<SelectListItem>, IEnumerable<SelectListItem>>
                                     (customerRepository.GetAllCustomers(),
                                          itemRepository.GetAllItems(),
                                          paymentTypeRepository.GetAllPAymentType());


            return View(objectSelectedList);
        }

        public JsonResult GetItemUnitPrice(int itemId)
        {
            var unitPrice = context.Items.Single(m => m.ItemId == itemId).ItemPrice;
            return Json(unitPrice, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Index(OrderViewModel orderViewModel )
        {
            OrderRepository orderRepository = new OrderRepository();
            orderRepository.AddOrder(orderViewModel);

            return Json(" Your order had been suuceefuly added", JsonRequestBehavior.AllowGet);
        }
    }
}