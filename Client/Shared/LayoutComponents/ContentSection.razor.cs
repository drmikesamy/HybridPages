using HybridPages.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace HybridPages.Client.Shared.LayoutComponents
{
	public partial class ContentSection
	{
		private bool _editable = false;
		[Parameter]
		public Post post { get; set; } = new Post { Content = "" };
		protected override async Task OnInitializedAsync()
		{
			_pageService.OnStateChange += StateHasChanged;
			var authenticationState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
			var user = authenticationState.User;
			_editable = user.Identity != null && user.Identity.IsAuthenticated;
		}
	}
}