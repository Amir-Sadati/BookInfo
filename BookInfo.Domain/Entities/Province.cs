using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BookInfo.Domain.Entities
{
   public class Province
    {
        [Key]
        public int provinceId { get; set; }
        public string provinceName { get; set; }
        public ICollection<City> city { get; set; }
    }
}
