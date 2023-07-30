
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
    public class Style : BaseEntity<Style>
    {
		public Font? HeadingFontFace { get; set; }
		public Font? ParagraphFontFace { get; set; }
		public string? HeadingFontColour { get; set; }
		public string? ParagraphFontColour { get; set; }
		public BackgroundTypeEnum BackgroundType { get; set; }
		public string? BackgroundColour { get; set; }
		public string? BackgroundImageUrl { get; set; }
		public BackgroundMesh? BackgroundMesh { get; set; }
	}
}

