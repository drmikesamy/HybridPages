using HybridPages.Shared.Enums;
using SimpleTextEditor.Helpers;
using SimpleTextEditor.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace HybridPages.Shared.Models
{
    public class TextPost : Post
    {
		[NotMapped]
		public List<SimpleTextBlock> TextBlocks { get; set; } = new();
		public PostTypeEnum Type { get; set; } = PostTypeEnum.Text;
		public Style? Style { get; set; }
		public virtual ICollection<PostMeta> PostMeta { get; set; }
	}
}
