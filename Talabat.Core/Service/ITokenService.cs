

using Talabat.Core.Entities.Identity;

namespace Talabat.Core.Service
{
	public interface ITokenService
	{
		Task<string> CreateTokenAsync(AppUser user);

	}
}
