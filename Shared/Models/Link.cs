using HybridPages.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HybridPages.Shared.Models
{
    public class Link : BaseEntity<Link>
    {
        public virtual ICollection<Page> Pages { get; set; }
        public string Label { get; set; }

        public string Url { get; set; }

        public string Path { get; set; }

        public string Icon { get; set; }
        public LinkTypeEnum Type { get; set; }
    }
}
