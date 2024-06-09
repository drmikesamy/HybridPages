using Blazored.TextEditor;
using HybridPages.Shared.Enums;
using HybridPages.Shared.Helpers;
using HybridPages.Shared.Models;
using System.ComponentModel;
using System.Net.Http.Json;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;

namespace HybridPages.Client.State
{
	public class PageService
	{
		private HttpClient _httpClient;
		public PageService(HttpClient httpClient) {
			_httpClient = httpClient;
		}
		public Page? Page { get; set; }
		public Post? SelectedPost { get; set; }
		public Post? Payload { get; set; }

		public event Action OnStateChange;
		public async Task Get(string uniqueName)
		{
			var response = await _httpClient.GetAsync("page/" + uniqueName);
			if (response.IsSuccessStatusCode)
			{
				Page = await response.Content.ReadFromJsonAsync<Page>();
            }
			NotifyStateChanged();
		}
		public async Task AddPost(PostTypeEnum postType)
		{
			var newPost = new Post { Type = postType };

			var response = await _httpClient.PostAsJsonAsync<Tuple<Post, string>>("post", new Tuple<Post, string>(newPost, Page.UniqueName), CancellationToken.None);

			var responseContent = await response.Content.ReadAsStringAsync();

			var postId = long.Parse(responseContent);

			newPost.Id = postId;

			Page.Posts.AddAfter(ListManipulation.FindById(Page.Posts, SelectedPost.Id), newPost);

			SelectedPost = newPost;
			NotifyStateChanged();
		}
		public void SelectPost(Post post)
		{

			SelectedPost = post;
			NotifyStateChanged();
		}
		public void SetPostType(PostTypeEnum postType)
		{
			SelectedPost.Type = postType;
			NotifyStateChanged();
		}
		public void MoveUp()
		{
			Page?.Posts.MoveUp(SelectedPost);
			NotifyStateChanged();
		}

		public void MoveDown()
		{
			Page?.Posts?.MoveDown(SelectedPost);
			NotifyStateChanged();
		}
		public async Task Save()
		{
			HttpResponseMessage? response;
			if(Page != null)
			{
				response = await _httpClient.PostAsJsonAsync<Page>("page", Page, CancellationToken.None);
				if(response.IsSuccessStatusCode)
				{
					var responseContent = await response.Content.ReadAsStringAsync();
					var pageId = long.Parse(responseContent);
					Page.Id = pageId;
				}
			}
			NotifyStateChanged();
		}
		public void NotifyStateChanged() => OnStateChange?.Invoke();


		public Post? DragDropPayload { get; set; }

		public Post? DragDropTarget { get; set; }

		public int? ActiveSpacerId { get; set; }
	}
}
