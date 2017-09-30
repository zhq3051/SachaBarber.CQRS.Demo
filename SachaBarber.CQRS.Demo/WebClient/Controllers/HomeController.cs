using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SachaBarber.CQRS.Demo.Orders;
using SachaBarber.CQRS.Demo.Orders.ReadModel;
using System.Threading.Tasks;
using SachaBarber.CQRS.Demo.Orders.ReadModel.Models;

namespace WebClient.Controllers
{
    public class HomeController : Controller
    {
        public List<StoreItem> Items;
        public async Task<ActionResult> Index()
        {
            try
            {
                var orderServiceInvoker = new OrderServiceInvoker();
                var newOrders = orderServiceInvoker.CallService(service => service.GetAllStoreItemsAsync());
                await Task.WhenAll(newOrders);
                Items = newOrders.Result;
                return View(Items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}