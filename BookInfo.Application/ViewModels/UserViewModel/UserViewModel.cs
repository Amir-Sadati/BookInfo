using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookInfo.Application.ViewModels.UserViewModel
{
    public class UserViewModel
    {
        public string Password { set; get; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { set; get; }
        public int CityId { set; get; } 
        public string Token { set; get; }
      
    }
}
