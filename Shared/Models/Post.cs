using HybridPages.Shared.Enums;
using HybridPages.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HybridPages.Shared.Models
{
    public class Post : BaseEntity<Post>
    {
        public long PageId { get; set; }
		public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
		public PostTypeEnum Type { get; set; } = PostTypeEnum.Text;
		public Style? Style { get; set; }
		public virtual ICollection<PostMeta> PostMeta { get; set; }
		public Post()
		{
			PostMeta = new HashSet<PostMeta>();
		}
	}
}
