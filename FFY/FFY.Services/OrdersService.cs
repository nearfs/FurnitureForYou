﻿using FFY.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FFY.Models;
using FFY.Data.Contracts;

namespace FFY.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IGenericRepository<Order> ordersRepository;

        public OrdersService(IUnitOfWork unitOfWork, IGenericRepository<Order> ordersRepository)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException("Unit of work cannot be null.");
            }

            if (ordersRepository == null)
            {
                throw new ArgumentNullException("Orders repository cannot be null.");
            }


            this.unitOfWork = unitOfWork;
            this.ordersRepository = ordersRepository;
        }

        public void AddOrder(Order order)
        {
            if(order == null)
            {
                throw new ArgumentNullException("Order cannot be null.");
            }

            using (this.unitOfWork)
            {
                this.ordersRepository.Add(order);
                this.unitOfWork.Commit();
            }
        }

        public IEnumerable<Order> GetOrders()
        {
            return this.ordersRepository.GetAll(null, o => o.SendOn).Reverse();
        }

        public void ChangeOrderStatus(Order order, int statusType, int paymentStatusType)
        {
            if (order == null)
            {
                throw new ArgumentNullException("Order cannot be null.");
            }

            if (!Enum.IsDefined(typeof(OrderStatusType), statusType))
            {
                throw new InvalidCastException("Order status type is out of enumeration range.");
            }

            if (!Enum.IsDefined(typeof(OrderPaymentStatusType), paymentStatusType))
            {
                throw new InvalidCastException("Order payment status type is out of enumeration range.");
            }

            order.OrderStatusType = (OrderStatusType)statusType;
            order.OrderPaymentStatusType = (OrderPaymentStatusType)paymentStatusType;

            using (this.unitOfWork)
            {
                this.ordersRepository.Update(order);
                this.unitOfWork.Commit();
            }
        }

        public Order GetOrderById(int id)
        {
            return this.ordersRepository.GetById(id);
        }
    }
}
