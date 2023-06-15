using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HybridPages.Shared.Interfaces
{
    public interface IBaseEntity
    {
        public long Id { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
