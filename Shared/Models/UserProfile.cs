using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Pages.Shared.Models
{
    public class UserProfile : BaseEntity<UserProfile>
    {
        public string Name { get; set; }
        public string Bio { get; set; }
        public string AvatarUrl { get; set; }
        public virtual ICollection<UserMeta> UserMeta { get; set; }
        [InverseProperty("Creator")]
        public virtual ICollection<Page> Pages { get; set; }
        public UserProfile()
        {
            Pages = new HashSet<Page>();
        }
    }
}
