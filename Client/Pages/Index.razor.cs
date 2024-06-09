using HybridPages.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace HybridPages.Client.Pages
{
	public partial class Index
	{
		private IGrouping<string,Post> DropedItem;
		private IGrouping<string, Post> replacedItem;
		[Parameter]
		public string? UniqueName { get; set; }

		protected override async Task OnInitializedAsync()
		{
			_pageService.OnStateChange += StateHasChanged;
			if (UniqueName != null)
			{
				try
				{
					await _pageService.Get(UniqueName);
				}
				catch (AccessTokenNotAvailableException exception)
				{
					exception.Redirect();
				}
			}
			else
			{
				_navigation.NavigateTo("/p/start", forceLoad: true);
			}
		}

		public void SelectPost(Post post)
		{
			_pageService.SelectedPost = post;
			StateHasChanged();
		}
		public void OnItemDrop(IGrouping<string, Post> post)
		{
			DropedItem = post;
			StateHasChanged();
		}
		public void OnReplacedItemDrop(IGrouping<string, Post> post)
		{
			replacedItem = post;
			StateHasChanged();
		}
	}
}