using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookInfo.Domain.Entities.Identities
{
   public class AppUserClaim :IdentityUserClaim<int>
    {
        public AppUser AppUser { get; set; }
    }
}
