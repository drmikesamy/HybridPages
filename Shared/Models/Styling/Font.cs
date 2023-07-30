
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using HybridPages.Shared.Enums;
using HybridPages.Shared.Helpers;
using HybridPages.Shared.Models.Styling;

namespace HybridPages.Shared.Models
{
    public class Font : BaseEntity<Font>
    {
		public string FontFace { get; set; }
		public string FontPath { get; set; }
	}
}

