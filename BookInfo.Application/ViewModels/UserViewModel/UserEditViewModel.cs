using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookInfo.Application.ViewModels.UserViewModel
{
   public class UserEditViewModel
    {
        public int Id { set; get; }
        public string Password { set; get; }
        public string Name { get; set; }
        public string Family { get; set; }
        public bool IsActive { get; set; }
        public int CityId { set; get; } 
      
       
    }
}
