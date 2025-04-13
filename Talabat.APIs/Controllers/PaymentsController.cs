using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.APIs.DTOs;
using Talabat.APIs.Errors;
using Talabat.Core.Entities;
using Talabat.Core.Service;

namespace Talabat.APIs.Controllers
{
	public class PaymentsController : APIsBaseController
	{
		private readonly IPaymentService _paymentService;
		private readonly IMapper _mapper;

		public PaymentsController(IPaymentService paymentService, IMapper mapper)
		{
			_paymentService = paymentService;
			_mapper = mapper;
		}
		[ProducesResponseType(typeof(CustomerBasketDto), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(CustomerBasketDto), StatusCodes.Status400BadRequest)]
		[HttpPost]
		public async Task<ActionResult<CustomerBasketDto>> CreateOrUpdatePaymentIntent(string basketId)
		{
			var CustomerBasket = await _paymentService.CreateOrUpdatePaymentIntent(basketId);
			if (CustomerBasket == null) return BadRequest(new ApiResponse(400,"There is a Problem with your Basket"));
			var MappedCustomerBasket = _mapper.Map<CustomerBasket,CustomerBasketDto>(CustomerBasket);
			return Ok(MappedCustomerBasket);
		}
	}
}
