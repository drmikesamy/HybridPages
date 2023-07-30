using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HybridPages.Shared.Models.Styling
{
	public class ColourPoint : BaseEntity<ColourPoint>
	{
		public int HPosPercent { get; set; }
		public int VPosPercent { get; set; }
		public int HPosAbs { get; set; }
		public int VPosAbs { get; set; }
		public int H { get; set; }
		public int S { get; set; }
		public int L { get; set; }
		public float A { get; set; }
		public int Alpha { get; set; }
		public float LayerHeight { get; set; }
		public bool IsBackground { get; set; } = false;
		public long BackgroundMeshId { get; set; }
	}
}
