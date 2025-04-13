using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.APIs.DTOs;
using Talabat.APIs.Errors;
using Talabat.APIs.Helpers;
using Talabat.Core;
using Talabat.Core.Entities;
using Talabat.Core.Repositories;
using Talabat.Core.Specifications;

namespace Talabat.APIs.Controllers
{
 
	public class ProductController : APIsBaseController
	{
		
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _unitOfWork;
	

		public ProductController(IMapper mapper, IUnitOfWork unitOfWork) {
			// Dependency Injection
			_mapper = mapper;
			_unitOfWork = unitOfWork;
			
		}

		[HttpGet]
		public async Task<ActionResult<Pagination<ProductToReturnDto>>> GetProducts([FromQuery]ProductSpecParams Params)
		{
			var Spec = new ProductWithBrandAndTypeSpecifications(Params);
			var products = await _unitOfWork.Repository<Product>().GetAllWithSpecAsync(Spec);
			if(products == null) return NotFound(new ApiResponse(404));
			var Mapproducts = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products);

			var CountSpec = new ProductWithFilterationForCountSpec(Params);

			var Count = await _unitOfWork.Repository<Product>().GetCountWithSpecAsync(CountSpec);
			return Ok(new Pagination<ProductToReturnDto>(Params.PageSize,Params.PageIndex,Mapproducts, Count));
		}


		[HttpGet("{id}")]
		[ProducesResponseType(typeof(ProductToReturnDto),StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(ApiResponse),StatusCodes.Status404NotFound)]
	 
		public async Task<ActionResult<Product>> GetProduct(int id)
		{
			var Spec = new ProductWithBrandAndTypeSpecifications(id);
			var product = await _unitOfWork.Repository<Product>().GetEntityWithSpecAsync(Spec);
			if (product == null) return NotFound(new ApiResponse(404));
			var MapProduct = _mapper.Map<Product, ProductToReturnDto>(product);
			return Ok(MapProduct);
		}


		[HttpGet("Types")]
		public async Task<ActionResult<IEnumerable<ProductType>>> GetTypes()
		{
			var types = await _unitOfWork.Repository<ProductType>().GetAllAsync();
			if (types == null) return NotFound(new ApiResponse(404));
			return Ok(types);
		}

		[HttpGet("Brands")]
		public async Task<ActionResult<IEnumerable<ProductBrand>>> GetBrands()
		{
			var brands = await _unitOfWork.Repository<ProductBrand>().GetAllAsync();
			if (brands == null) return NotFound(new ApiResponse(404));
			return Ok(brands);
		}
	}
}
