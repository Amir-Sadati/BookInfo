using BookInfo.Domain.Entities.Identities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookInfo.Domain.Entities
{
    public class City
    {
        [Key]
        public int CityId { set; get; }
        public string CityName { set; get; }
        public  ICollection<AppUser> AppUsers { set; get; }

        [ForeignKey("province")]
        public  int provinceId{ set; get; }

        public  Province province { set; get; }


    }
}
