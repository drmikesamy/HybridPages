using HybridPages.Shared.Enums;
using SimpleTextEditor.Helpers;
using SimpleTextEditor.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace HybridPages.Shared.Models
{
	public class Post : BaseEntity<Post>
	{
		public long PageId { get; set; }
		public string Content { get; set; } = "";
		[NotMapped]
		public List<SimpleTextBlock> TextBlocks { get; set; }
		public PostTypeEnum Type { get; set; } = PostTypeEnum.Text;
		public Style? Style { get; set; }
		public virtual ICollection<PostMeta> PostMeta { get; set; }
		public Post()
		{
			PostMeta = new HashSet<PostMeta>();
		}
	}
}
