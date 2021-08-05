using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookInfo.Application.ViewModels
{
   public class EmailViewModel
    {
        public string[] EmailAddress { set; get; }
        public string Message { set; get; }
        public string Subject { set; get; }
    }
}
