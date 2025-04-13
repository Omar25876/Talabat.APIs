using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core;
using Talabat.Core.Entities;
using Talabat.Core.Entities.Order_Aggregate;
using Talabat.Core.Repositories;
using Talabat.Core.Service;
using Talabat.Core.Specifications.Order_Spec;

namespace Talabat.Service
{
	public class OrderService : IOrderService
	{
		private readonly IBasketRepository _basketRepository;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IPaymentService _paymentService;

		public OrderService(IBasketRepository basketRepository, IUnitOfWork unitOfWork, IPaymentService paymentService)
		{
			_basketRepository = basketRepository;
			_unitOfWork = unitOfWork;
			_paymentService = paymentService;
		}
		public async Task<Order?> CreateOrderAsync(string buyerEmail, string basketId, int DeliveryMethodId, Address shippingAddress)
		{
			var Basket = await _basketRepository.GetBasketAsync(basketId);

			var OrderItems = new List<OrderItem>();

			if(Basket?.Items.Count  > 0)
			{
				foreach (var item in Basket.Items)
				{
					
					var Product = await _unitOfWork.Repository<Product>().GetByIdAsync(item.Id);
					var ProductItemOrdered = new ProductItemOrdered(Product.Id, Product.Name, Product.PictureUrl);
					var OrderItem = new OrderItem(ProductItemOrdered, Product.Price, item.Quantity);
					OrderItems.Add(OrderItem); 
				}	

			}


			var SubTotal = OrderItems.Sum(item => item.Price * item.Quantity);


			var DeliveryMethod = await _unitOfWork.Repository<DeliveryMethod>().GetByIdAsync(DeliveryMethodId);


			var Spec = new OrederWithPaymentIntendSpec(Basket.PaymentIntentId);
			var ExOrder = await _unitOfWork.Repository<Order>().GetEntityWithSpecAsync(Spec);

			if (ExOrder != null)
			{
				_unitOfWork.Repository<Order>().Delete(ExOrder);
				await _paymentService.CreateOrUpdatePaymentIntent(basketId);
			}


			var Order = new Order(buyerEmail, shippingAddress, DeliveryMethod, OrderItems,SubTotal,Basket.PaymentIntentId);

			await _unitOfWork.Repository<Order>().Add(Order);

			var Result = await _unitOfWork.CompleteAsync();

			if (Result <= 0) return null;

			return Order;

		}

		public Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync()
		{
			var DeliveryMethods = _unitOfWork.Repository<DeliveryMethod>().GetAllAsync();
			return DeliveryMethods;
		}

		public async Task<Order> GetOrderByIdForSpecificUserAsync(string buyerEmail, int orderId)
		{
			var Spec = new OrderSpecifications(buyerEmail, orderId);
			var Order = await _unitOfWork.Repository<Order>().GetEntityWithSpecAsync(Spec);
			return Order;

		}

		public Task<IReadOnlyList<Order>> GetOrdersForSpecificUserAsync(string buyerEmail)
		{
			var Spec = new OrderSpecifications(buyerEmail) ;
			var Orders = _unitOfWork.Repository<Order>().GetAllWithSpecAsync(Spec);
			return Orders;
		}
	}
}
