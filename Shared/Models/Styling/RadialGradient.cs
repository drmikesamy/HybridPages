using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HybridPages.Shared.Models.Styling
{
	public class RadialGradient : BaseEntity<RadialGradient>
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
		public int LayerHeight { get; set; }
	}
}
