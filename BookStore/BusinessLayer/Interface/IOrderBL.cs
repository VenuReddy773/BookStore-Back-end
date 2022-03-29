using ModelLayer.Service.OrderModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IOrderBL
    {
        string AddOrder(OrderModel order);
        List<GetOrderModel> RetrieveOrderDetails(int userId);
        bool DeleteOrder(int OrderId);
    }
}
