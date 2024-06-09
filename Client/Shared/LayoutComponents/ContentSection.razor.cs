using HybridPages.Client.State;
using HybridPages.Shared.Helpers;
using HybridPages.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.ComponentModel;

namespace HybridPages.Client.Shared.LayoutComponents
{
	public partial class ContentSection
	{
		private bool _editable = false;
		private bool _dragHover { get; set; }
		private int _hoverCounter { get; set; } = 0;
		[Parameter]
		public IGrouping<string?, Post>? postGroup { get; set; }
		protected override async Task OnInitializedAsync()
		{
			_pageService.OnStateChange += StateHasChanged;
			var authenticationState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
			var user = authenticationState.User;
			_editable = user.Identity != null && user.Identity.IsAuthenticated;
		}
		public void DragStart(Post post)
		{
			_pageService.DragDropPayload = post;
			_pageService.NotifyStateChanged();
		}

		public void DragEnter(Post post)
		{
			_pageService.DragDropTarget = post;
			_pageService.NotifyStateChanged();
		}
		public void DragLeave()
		{
			_pageService.DragDropTarget = null;
			_pageService.NotifyStateChanged();
		}

		public async Task Drop()
		{
			ListManipulation.Swap(_pageService.DragDropTarget, _pageService.DragDropPayload);
			_pageService.NotifyStateChanged();
		}
	}
}