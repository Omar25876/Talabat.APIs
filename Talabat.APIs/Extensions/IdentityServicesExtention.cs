using Microsoft.AspNetCore.Identity;
using Talabat.Core.Entities.Identity;
using Talabat.Core.Service;
using Talabat.Repository.Identity;
using Talabat.Service;

namespace Talabat.APIs.Extensions
{
	public static class IdentityServicesExtention
	{
		public static IServiceCollection AddIdentityServices(this IServiceCollection Services)
		{

			Services.AddIdentity<AppUser, IdentityRole>()
							.AddEntityFrameworkStores<AppIdentityDbcontext>()
							.AddDefaultTokenProviders();

			Services.AddAuthentication();

			Services.AddScoped<ITokenService, TokenService>();

			return Services;
		}
	}
}
