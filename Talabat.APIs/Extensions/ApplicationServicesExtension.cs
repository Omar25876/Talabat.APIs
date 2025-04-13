using Microsoft.AspNetCore.Mvc;
using Talabat.APIs.Errors;
using Talabat.APIs.Helpers;
using Talabat.Core;
using Talabat.Core.Repositories;
using Talabat.Core.Service;
using Talabat.Reository;
using Talabat.Repository;
using Talabat.Service;

namespace Talabat.APIs.Extensions
{
	public static class ApplicationServicesExtension
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection Services) {

			
			Services.AddScoped<IPaymentService, PaymentService>();
			Services.AddScoped<IUnitOfWork, UnitOfWork>();
			Services.AddScoped<IOrderService, OrderService>();
			//Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
			Services.AddAutoMapper(typeof(MappingProfiles));
			Services.AddScoped(typeof(IBasketRepository), typeof(BasketRepository));

			Services.Configure<ApiBehaviorOptions>(
				options =>
				{
					options.InvalidModelStateResponseFactory = actionContext =>
					{
						var errors = actionContext.ModelState
							.Where(e => e.Value.Errors.Count > 0)
							.SelectMany(x => x.Value.Errors)
							.Select(x => x.ErrorMessage).ToArray();
						var errorResponse = new ApiValidationErrorResponse
						{
							Errors = errors
						};
						return new BadRequestObjectResult(errorResponse);
					};
				}
			);
			return Services;

		}
	}
}
