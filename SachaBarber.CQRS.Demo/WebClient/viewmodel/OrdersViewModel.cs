using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SachaBarber.CQRS.Demo.Orders;
using SachaBarber.CQRS.Demo.Orders.ReadModel;
using SachaBarber.CQRS.Demo.Orders.ReadModel.Models;

namespace WebClient.viewmodel
{
    public class OrdersViewModel
    {
        private OrderServiceInvoker orderServiceInvoker;

        public OrdersViewModel()
        {
            
        orderServiceInvoker = new OrderServiceInvoker();
            var newOrders = orderServiceInvoker.CallService(service => service.GetAllOrdersAsync());

            
           

        }

        public List<StoreItem> Items
        {
            get;set;
        }
    }
}