using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HybridPages.Shared.Models.Styling
{
    public class BackgroundMesh : BaseEntity<BackgroundMesh>
	{
        public List<RadialGradient> ColourPoints { get; set; }
    }
}
