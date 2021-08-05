using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookInfo.Application.ViewModels.BookViewModel
{
   public class BookAuthorsViewModel
    {
        public String Name { set; get; }
        public List<String> Authors { set; get; }
    }
}
