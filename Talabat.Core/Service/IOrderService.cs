using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities.Order_Aggregate;

namespace Talabat.Core.Service
{
	public interface IOrderService
	{
		Task<Order?> CreateOrderAsync(string buyerEmail,string basketId,int DeliveryMethodId, Address shippingAddress);

		Task<IReadOnlyList<Order>> GetOrdersForSpecificUserAsync(string buyerEmail);

		Task<Order> GetOrderByIdForSpecificUserAsync(string buyerEmail,int orderId);

		Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync();


	}
}
