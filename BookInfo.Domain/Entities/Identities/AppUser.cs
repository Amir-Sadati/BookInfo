using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookInfo.Domain.Entities.Identities
{
    public class AppUser :IdentityUser<int>
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { set; get; }
        public bool IsActive { get; set; }
        [ForeignKey("City")]
        public int CityId { set; get; } 
        public City City { set; get; }
        public ICollection< AppUserRole> AppUserRoles{ get; set; }
        public ICollection< AppUserClaim> AppClaims{ get; set; }
        public ICollection<Photo> Photos { set; get; }
        public ICollection< Comment> Comments{ get; set; }



    }
}
