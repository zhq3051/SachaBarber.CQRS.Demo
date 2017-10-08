using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SachaBarber.CQRS.Demo.Orders;
using SachaBarber.CQRS.Demo.Orders.ReadModel;
using System.Threading.Tasks;
using SachaBarber.CQRS.Demo.Orders.ReadModel.Models;
using SachaBarber.CQRS.Demo.Orders.Commands;

namespace WebClient.Controllers
{
    public class HomeController : Controller
    {
        public List<StoreItem> Items;
        public List<Order> Orders;
        public async Task<ActionResult> Index()
        {
            try
            {
                var orderServiceInvoker = new OrderServiceInvoker();
                var newItems = orderServiceInvoker.CallService(service => service.GetAllStoreItemsAsync());
                await Task.WhenAll(newItems);
                Items = newItems.Result;
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

        [HttpPost]
        public async Task<ActionResult> AddOrder()
        {
            var random = new Random().Next(1000);
            var id = Guid.NewGuid();
            var orderServiceInvoker = new OrderServiceInvoker();
            var orderCreated = await orderServiceInvoker.CallService(service => service.SendCommandAsync(
                new CreateOrderCommand()
            {
                ExpectedVersion = 1,
                Id = id,
                Address = "Address" + random,
                Description = "Description" + random,
                OrderItems = new List<SachaBarber.CQRS.Demo.Orders.DTOs.OrderItem>() {
                    new SachaBarber.CQRS.Demo.Orders.DTOs.OrderItem() {
                         OrderId = id,
                        StoreItemId = Guid.NewGuid(),
                        StoreItemDescription = "storeitem description",
                        StoreItemUrl ="http://www.baidu.com"
                } }
            }));

            return Redirect("Order");
        }

        public async Task<ActionResult> Order()
        {
            var orderServiceInvoker = new OrderServiceInvoker();
            var newOrders = orderServiceInvoker.CallService(service =>
                                service.GetAllOrdersAsync());
            await Task.WhenAll(newOrders);
            Orders = newOrders.Result;
            return View(Orders);
            
        }
    }
}