using HybridPages.Shared.Enums;
using SimpleTextEditor.Helpers;
using SimpleTextEditor.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace HybridPages.Shared.Models
{
    public class Post<T> : BaseEntity<Post<T>>
    {
        public long PageId { get; set; }
		public string Title { get; set; } = "Title";
        public string Content { get; set; } = "Content";
		[NotMapped]
		public List<T> PostObject { get; set; } = new();
		public PostTypeEnum Type { get; set; } = PostTypeEnum.Text;
		public Style? Style { get; set; }
		public virtual ICollection<PostMeta> PostMeta { get; set; }
		public Post()
		{
			PostMeta = new HashSet<PostMeta>();
		}
	}
}
