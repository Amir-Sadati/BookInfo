using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookInfo.Domain.Entities.Identities
{
   public class AppRoleClaim :IdentityRoleClaim<int>
    {
        public AppRole Approle { get; set; }
    }
}
