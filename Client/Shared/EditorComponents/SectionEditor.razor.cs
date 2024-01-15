using SimpleTextEditor.Helpers;
using SimpleTextEditor.Models;

namespace HybridPages.Client.Shared.EditorComponents
{
	public partial class SectionEditor
	{
		protected override async Task OnInitializedAsync()
		{
			_pageService.OnStateChange += StateHasChanged;
		}
		public string Title
		{
			get
			{
				return _pageService.SelectedPost?.Title ?? "Title";
			}
			set
			{
				if (_pageService.SelectedPost != null)
				{
					_pageService.SelectedPost.Title = value;
					_pageService.NotifyStateChanged();
				}
			}
		}
		public string Content
		{
			get
			{
				return _pageService.SelectedPost?.Content ?? "Content";
			}
			set
			{
				if (_pageService.SelectedPost != null)
				{
					_pageService.SelectedPost.Content = value;
					_pageService.NotifyStateChanged();
				}
			}
		}
		public List<SimpleTextBlock> TextBlocks
		{
			get
			{
				return _pageService.SelectedPost?.TextBlocks ?? new List<SimpleTextBlock> { new SimpleTextBlock() };
			}
			set
			{
				if (_pageService.SelectedPost != null)
				{
					_pageService.SelectedPost.TextBlocks = value;
					_pageService.NotifyStateChanged();
				}
			}
		}
	}
}