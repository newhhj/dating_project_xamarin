using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Strawberry.MobileApp.Helpers
{
	public interface IAuthenticationService
	{
		bool IsAuthenticated { get; }

		User AuthenticatedUser { get; }

		Task<bool> LoginAsync(string email, string password);

		Task LoginWithSNSAsync(SNSProvider provider);

		Task<bool> UserIsAuthenticatedAndValidAsync();

		Task LogoutAsync();
	}
}
