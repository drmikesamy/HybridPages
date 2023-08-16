using HybridPages.Shared.Enums;
using HybridPages.Shared.Models.TextEditor;
using System.ComponentModel.DataAnnotations.Schema;

namespace HybridPages.Shared.Models
{
    public class Post : BaseEntity<Post>
    {
        public long PageId { get; set; }
		public string Title { get; set; } = "Title";
        public string Content { get; set; } = "Content";
		public PostTypeEnum Type { get; set; } = PostTypeEnum.Text;
		public Style? Style { get; set; }
		public virtual ICollection<PostMeta> PostMeta { get; set; }
		[NotMapped]
		public List<TextLine> ContentTextLines { get; set; }
		public Post()
		{
			PostMeta = new HashSet<PostMeta>();
			ContentTextLines = new List<TextLine>();
			ContentTextLines.Add(new TextLine());
		}
	}
}
