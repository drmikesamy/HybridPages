using HybridPages.Shared.Models.Styling;
using Microsoft.JSInterop;

namespace HybridPages.Shared.Helpers
{
	public class BackgroundMeshToCss
	{
		public static string GetBackgroundMeshCss(BackgroundMesh backgroundMesh)
		{
			var backgroundCss = $"background-color: {GetHSLACss(backgroundMesh.ColourPoints.First(c => c.IsBackground))};";
			backgroundCss += $"background-image: ";

			foreach (var colourPoint in backgroundMesh.ColourPoints.OrderBy(c => c.LayerHeight))
			{
				backgroundCss += $"radial-gradient(at {colourPoint.HPosPercent}% {colourPoint.VPosPercent}%, {GetHSLACss(colourPoint)} 0px, transparent {colourPoint.Alpha}%),";
			}
			backgroundCss = backgroundCss.Remove(backgroundCss.Length - 1, 1) + ";";

			return backgroundCss;
		}
		public static string GetHSLACss(ColourPoint sourceColourPoint)
		{
			return $"hsla({sourceColourPoint.H}, {sourceColourPoint.S}%, {sourceColourPoint.L}%, {sourceColourPoint.A})";
		}
	}
}
