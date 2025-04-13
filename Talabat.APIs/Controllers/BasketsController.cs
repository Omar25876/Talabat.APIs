using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.APIs.DTOs;
using Talabat.APIs.Errors;
using Talabat.Core.Entities;
using Talabat.Core.Repositories;

namespace Talabat.APIs.Controllers
{
 
	public class BasketsController : APIsBaseController
	{
		private readonly IBasketRepository _basketRepository;
		private readonly IMapper _mapper;

		public BasketsController(IBasketRepository basketRepository,IMapper mapper)
		{
			_basketRepository = basketRepository;
			_mapper = mapper;
		}


		[HttpGet]

		public async Task<ActionResult<CustomerBasket>> GetCustomerBasket(string id)
		{
			var Basket = await _basketRepository.GetBasketAsync(id);

			return Basket is null ? new CustomerBasket(id) : Ok(Basket);

		}

		[HttpPost]

		public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasketDto basket)
		{
			var MappedBasket = _mapper.Map<CustomerBasketDto, CustomerBasket>(basket);
			var CreateOrUpdateBasket = await _basketRepository.UpdateBasketAsync(MappedBasket);

			if (CreateOrUpdateBasket is null) return BadRequest(new ApiResponse(400,"There Is A Proplem With Your Basket"));
			return Ok(CreateOrUpdateBasket);
		}

		[HttpDelete]
		public async Task<ActionResult<bool>> DeleteBasket(string id)
		{
			return await _basketRepository.DeleteBasketAsync(id);
		}

	}
}
