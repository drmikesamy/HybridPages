using HybridPages.Shared.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using Blazored.TextEditor;

namespace HybridPages.Shared.Models
{
	public class Post : BaseEntity<Post>
	{
		public long PageId { get; set; }
		public string Title { get; set; } = "";
		public string Content { get; set; } = "";
		public string ChainedRow { get; set; } = Guid.NewGuid().ToString();
		[NotMapped]
		public BlazoredTextEditor EditorInstance { get; set; } = new BlazoredTextEditor();
		public PostTypeEnum Type { get; set; } = PostTypeEnum.Text;
		public Style? Style { get; set; }
		public virtual ICollection<PostMeta> PostMeta { get; set; }
		public Post()
		{
			PostMeta = new HashSet<PostMeta>();
		}
	}
}
