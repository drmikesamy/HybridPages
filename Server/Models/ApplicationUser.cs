using HybridPages.Shared.Models;
using Microsoft.AspNetCore.Hosting.Builder;
using Microsoft.AspNetCore.Identity;

namespace HybridPages.Server.Models
{
	public class ApplicationUser : IdentityUser
	{
		public ApplicationUser()
		{
			UserProfile = new UserProfile
			{
				UserId = Id
			};
		}
		public UserProfile UserProfile { get; set; }
	}
}