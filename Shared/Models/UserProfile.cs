﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HybridPages.Shared.Models
{
    public class UserProfile : BaseEntity<UserProfile>
    {
        public string UserId { get; set; }
        public string? Name { get; set; }
        public string? Bio { get; set; }
        public string? AvatarUrl { get; set; }
        public virtual ICollection<UserProfileMeta> UserMeta { get; set; }
        public virtual ICollection<Page> Pages { get; set; }
        public UserProfile()
        {
            Pages = new HashSet<Page>();
			UserMeta = new HashSet<UserProfileMeta>();
        }
    }
}
