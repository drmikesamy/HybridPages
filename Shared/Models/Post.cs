using HybridPages.Shared.Enums;
using SimpleTextEditor.Helpers;
using SimpleTextEditor.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace HybridPages.Shared.Models
{
    public class Post : BaseEntity<Post>
    {
        public long PageId { get; set; }
		public string Title { get; set; } = "Title";
        public string Content { get; set; } = "Content";
        public string HtmlContent => TextBlocks.ToHtml();
		[NotMapped]
		public List<SimpleTextBlock> TextBlocks { get; set; } = new List<SimpleTextBlock> { new SimpleTextBlock { Characters = new List<SimpleTextCharacter> { new SimpleTextCharacter() } } };
		public PostTypeEnum Type { get; set; } = PostTypeEnum.Text;
		public Style? Style { get; set; }
		public virtual ICollection<PostMeta> PostMeta { get; set; }
		public Post()
		{
			PostMeta = new HashSet<PostMeta>();
		}
	}
}
