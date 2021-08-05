using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookInfo.Application.ViewModels.BookViewModel
{
   public class CommentsBookViewModel
    {
        public string writter { set; get; }
        public int CommentId { get; set; }
        public string Desription { get; set; }
        public DateTime PostageDateTime { get; set; }
      
     
    }
}
