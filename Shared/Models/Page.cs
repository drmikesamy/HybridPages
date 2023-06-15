
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using HybridPages.Shared.Enums;
using HybridPages.Shared.Helpers;

namespace HybridPages.Shared.Models
{
    public class Page : BaseEntity<Page>
    {
        public PageTypeEnum Type { get; set; }
        public string Title { get; set; }
        public string UniqueName { get; set; }
        public long CreatorId { get; set; }
        public virtual UserProfile Creator { get; set; }
        public string FeaturedImageUrl { get; set; }
        [InverseProperty("Page")]
        public virtual ICollection<Link> Links { get; set; }
        public virtual ICollection<PageMeta> PageMeta { get; set; }
    }
}

