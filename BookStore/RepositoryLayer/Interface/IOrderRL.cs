using ModelLayer.Service.OrderModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IOrderRL
    {
        string AddOrder(OrderModel order);
        List<GetOrderModel> RetrieveOrderDetails(int userId);
    }
}
