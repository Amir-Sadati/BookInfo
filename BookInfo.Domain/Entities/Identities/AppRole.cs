using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookInfo.Domain.Entities.Identities
{
   public class AppRole :IdentityRole<int>
    {
        
        public ICollection<AppUserRole> AppUserRoles { set; get; }
        public ICollection<AppRoleClaim> AppClaims { set; get; }

    }
}
