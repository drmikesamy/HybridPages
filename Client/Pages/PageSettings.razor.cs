using Microsoft.AspNetCore.Components;

namespace HybridPages.Client.Pages
{
	public partial class PageSettings
	{
		[Parameter]
		public string? UniqueName { get; set; }
	}
}