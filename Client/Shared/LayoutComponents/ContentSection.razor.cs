using HybridPages.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace HybridPages.Client.Shared.LayoutComponents
{
	public partial class ContentSection
	{
		private bool _editable = false;
		private Task<AuthenticationState> _authenticationStateTask { get; set; }

		[Parameter]
		public Post post { get; set; } = new Post { Title = "Your title here", Content = "This is your tagline" };
		protected override async Task OnInitializedAsync()
		{
			_pageService.OnStateChange += StateHasChanged;
			var authenticationState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
			var user = authenticationState.User;
			_editable = user.Identity != null && user.Identity.IsAuthenticated;
		}
	}
}