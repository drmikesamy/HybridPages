using HybridPages.Shared.Helpers;
using HybridPages.Shared.Models.Styling;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace HybridPages.Client.Pages
{
	public partial class BackgroundDesigner
	{
		[Parameter]
		public string? UniqueName { get; set; }
		private WindowDimensions windowDimensions = new WindowDimensions { Height = 0, Width = 0 };
		private string backgroundCss = "";
		private ColourPoint? _colourPoint;
		private bool _dragging = false;
		private bool _colourSettingsActive = false;

		protected override async Task OnInitializedAsync()
		{
			if (_pageService.Page.Style.BackgroundMesh == null)
			{
				_pageService.Page.Style.BackgroundMesh = new BackgroundMesh();
				_pageService.Page.Style.BackgroundMesh.ColourPoints = GetSeedColourPoints();
			}

			RenderBackground();
			UpdateColourPoints();

			var timer = new PeriodicTimer(TimeSpan.FromSeconds(1));

			while (await timer.WaitForNextTickAsync())
			{
				windowDimensions = await DOMElements.GetWindowDimensions();
			}
		}

		public void RenderBackground()
		{

			backgroundCss = BackgroundMeshToCss.GetBackgroundMeshCss(_pageService.Page.Style.BackgroundMesh);
			StateHasChanged();
		}


		public void SelectColourPoint(ColourPoint colourPoint)
		{
			_colourPoint = colourPoint;
		}
		public void MouseDown()
		{
			if (!_colourSettingsActive)
			{
				_dragging = true;
			}

		}

		public async void MouseMove(MouseEventArgs args)
		{
			if (_dragging && _colourPoint != null)
			{
				_colourPoint.HPosAbs = Convert.ToInt32(Math.Round(_colourPoint.HPosAbs + args.MovementX));
				_colourPoint.VPosAbs = Convert.ToInt32(Math.Round(_colourPoint.VPosAbs + args.MovementY));

				windowDimensions = await DOMElements.GetWindowDimensions();

				_colourPoint.HPosPercent = Convert.ToInt32(Math.Round(_colourPoint.HPosAbs / (double)windowDimensions.Width * 100));
				_colourPoint.VPosPercent = Convert.ToInt32(Math.Round(_colourPoint.VPosAbs / (double)windowDimensions.Height * 100));
			}
			StateHasChanged();
			RenderBackground();
		}

		public void MouseUp(MouseEventArgs args)
		{
			_dragging = false;
		}

		public void ColourSettingsActive(bool active)
		{
			_colourSettingsActive = active;
		}

		public async void UpdateColourPoints()
		{
			windowDimensions = await DOMElements.GetWindowDimensions();

			foreach (var colourPoint in _pageService.Page.Style.BackgroundMesh.ColourPoints)
			{
				colourPoint.HPosAbs = Convert.ToInt32(Math.Round((double)colourPoint.HPosPercent / 100 * windowDimensions.Width, 0));
				colourPoint.VPosAbs = Convert.ToInt32(Math.Round((double)colourPoint.VPosPercent / 100 * windowDimensions.Height, 0));
			}

			StateHasChanged();
		}

		public List<ColourPoint> GetSeedColourPoints()
		{
			return new List<ColourPoint>
			{
				new ColourPoint { HPosPercent = 0, VPosPercent = 0, H = 237, S = 100, L = 50, A = 1, Alpha = 100, IsBackground = true },
				new ColourPoint { HPosPercent = 55, VPosPercent = 68, H = 228, S = 40, L = 83, A = 1, Alpha = 50, LayerHeight = 1 },
				new ColourPoint { HPosPercent = 38, VPosPercent = 31, H = 200, S = 100, L = 50, A = 0.84f, Alpha = 50, LayerHeight = 2 },
				new ColourPoint { HPosPercent = 24, VPosPercent = 60, H = 310, S = 95, L = 60, A = 1, Alpha = 50, LayerHeight = 3 },
				new ColourPoint { HPosPercent = 67, VPosPercent = 41, H = 100, S = 95, L = 62, A = 1, Alpha = 50, LayerHeight = 4 },
				new ColourPoint { HPosPercent = 0, VPosPercent = 100, H = 100, S = 0, L = 73, A = 1, Alpha = 50, LayerHeight = 5 },
				new ColourPoint { HPosPercent = 80, VPosPercent = 100, H = 201, S = 57, L = 76, A = 1, Alpha = 50, LayerHeight = 6 },
				new ColourPoint { HPosPercent = 15, VPosPercent = 20, H = 258, S = 100, L = 11, A = 1, Alpha = 50, LayerHeight = 7 }
			};
		}
	}
}