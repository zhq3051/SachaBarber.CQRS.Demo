using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SachaBarber.CQRS.Demo.Orders;
using SachaBarber.CQRS.Demo.Orders.ReadModel;
using SachaBarber.CQRS.Demo.Orders.ReadModel.Models;

namespace WebClient.viewmodel
{
    public class OrderViewModel
    {
        private Order Order;
        public OrderViewModel(Order order)
        {
            Order = order;

        }
    }
}