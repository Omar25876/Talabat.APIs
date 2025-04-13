using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Talabat.APIs.DTOs;
using Talabat.APIs.Errors;
using Talabat.Core.Entities.Order_Aggregate;
using Talabat.Core.Service;
using Talabat.Service;

namespace Talabat.APIs.Controllers
{
	public class OrdersController : APIsBaseController
	{
		private readonly IOrderService _orderService;
		private readonly IMapper _mapper;

		public OrdersController(IOrderService orderService, IMapper mapper)
		{
			_orderService = orderService;
			_mapper = mapper;
		}
		[ProducesResponseType(typeof(Order),StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(ApiResponse),StatusCodes.Status400BadRequest)]
		[HttpPost]
		[Authorize]
		public async Task<ActionResult<Order>> CreateOrder(OrderDto orderDto)
		{
			var ByerEmail = User.FindFirstValue(ClaimTypes.Email);
			var MappedAddress = _mapper.Map<AddrssDto,Address>(orderDto.ShippingAddress);
			var order = await _orderService.CreateOrderAsync(ByerEmail, orderDto.BasketId, orderDto.DeliveryMethodId, MappedAddress);

			if (order == null) return BadRequest(new ApiResponse(400,"There is a problem with your order"));

			return Ok(order);

		}

		[ProducesResponseType(typeof(IReadOnlyList<OrderToReturnDto>), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
		[HttpGet]
		[Authorize]
		public async Task<ActionResult<IReadOnlyList<OrderToReturnDto>>> GetOrdersForSpecificUser()
		{
			var ByerEmail = User.FindFirstValue(ClaimTypes.Email);
			var orders = await _orderService.GetOrdersForSpecificUserAsync(ByerEmail);
			if (orders == null) return NotFound(new ApiResponse(404, "There is no orders for this user"));
			var MapOrders = _mapper.Map<IReadOnlyList<Order>, IReadOnlyList<OrderToReturnDto>>(orders);
			return Ok(MapOrders);
		}

		[ProducesResponseType(typeof(OrderToReturnDto), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
		[HttpGet("{id}")]
		[Authorize]
		public async Task<ActionResult<OrderToReturnDto>> GetOrderByIdForSpecificUser(int id)
		{
			var ByerEmail = User.FindFirstValue(ClaimTypes.Email);
			var order = await _orderService.GetOrderByIdForSpecificUserAsync(ByerEmail, id);
			if (order == null) return NotFound(new ApiResponse(404, "There is no orders for this user"));
			var MapedOrder = _mapper.Map<Order, OrderToReturnDto>(order);
			return Ok(MapedOrder);
		}


		[HttpGet("DeliveryMethods")]
		[ProducesResponseType(typeof(IReadOnlyList<DeliveryMethod>), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
		public async Task<ActionResult<IReadOnlyList<DeliveryMethod>>> GetDeliveryMethods()
		{
			var deliveryMethods = await _orderService.GetDeliveryMethodsAsync();
			if (deliveryMethods == null) return NotFound(new ApiResponse(404, "There is no delivery methods"));
			return Ok(deliveryMethods);
		}










	}
}
