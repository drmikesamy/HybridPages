using Microsoft.JSInterop;

namespace HybridPages.Shared.Helpers
{
	public class DOMElements
	{
		private IJSRuntime _jsRuntime { get; set; }
		public DOMElements(IJSRuntime jsRuntime)
		{
			_jsRuntime = jsRuntime;
		}

		public async Task<WindowDimensions> GetWindowDimensions()
		{
			return await _jsRuntime.InvokeAsync<WindowDimensions>("DOMElements.WindowDimensions");
		}
	}
	public class WindowDimensions
	{
		public int Width { get; set; }
		public int Height { get; set; }
	}
}
