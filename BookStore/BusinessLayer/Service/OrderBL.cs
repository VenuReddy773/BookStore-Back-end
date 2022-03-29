using BusinessLayer.Interface;
using ModelLayer.Service.OrderModel;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class OrderBL : IOrderBL
    {
        IOrderRL orderRL;
        public OrderBL(IOrderRL orderRL)
        {
            this.orderRL = orderRL;
        }
        public string AddOrder(OrderModel order)
        {
            try
            {
                return this.orderRL.AddOrder(order);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool DeleteOrder(int OrderId)
        {
            try
            {
                return this.orderRL.DeleteOrder(OrderId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<GetOrderModel> RetrieveOrderDetails(int userId)
        {
            try
            {
                return this.orderRL.RetrieveOrderDetails(userId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
