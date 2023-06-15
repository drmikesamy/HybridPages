using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Pages.Shared.Interfaces;

namespace Pages.Shared.Models
{
    public class BaseEntity<T> : IBaseEntity
    where T : class
    {
        public long Id { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
