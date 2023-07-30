
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
    public class Page : BaseEntity<Page>
    {
        public PageTypeEnum Type { get; set; }
        public string Title { get; set; }
        public string UniqueName { get; set; }
        public string FeaturedImageUrl { get; set; }
        public long UserProfileId { get; set; }
        public virtual LinkedList<Post> Posts { get; set; }
        public virtual ICollection<PageMeta> PageMeta { get; set; }
        public Style? Style { get; set; }
		public Page()
		{
			Posts = new LinkedList<Post>();
			PageMeta = new HashSet<PageMeta>();
		}
	}
}

