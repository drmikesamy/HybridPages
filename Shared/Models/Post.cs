using HybridPages.Shared.Enums;
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
        public string Title { get; set; }
        public string Content { get; set; }
        public PostTypeEnum Type { get; set; }
		public virtual ICollection<PostMeta> PostMeta { get; set; }
	}
}
