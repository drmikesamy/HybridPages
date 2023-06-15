using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pages.Shared.Models
{
    public class PageMeta : BaseEntity<PageMeta>
    {
        public long PageId { get; set; }
        public virtual Page Page { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
