
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Pages.Shared.Enums;
using Pages.Shared.Helpers;

namespace Pages.Shared.Models
{
    public class Page : BaseEntity<Page>
    {
        public PageTypeEnum Type { get; set; }
        public string UniqueName { get; set; }
        public long CreatorId { get; set; }
        public virtual UserProfile Creator { get; set; }
        public string FeaturedImageUrl { get; set; }
        [InverseProperty("Page")]
        public virtual ICollection<Link> Links { get; set; }
        public virtual ICollection<PageMeta> PageMeta { get; set; }
    }
}

