using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookInfo.Application.ViewModels.BookViewModel
{
    public class CommentsBookViewModel
    {
        public string Description { set; get; }
        public string Writter { get; set; }
        public DateTime PostageDateTime { get; set; }
        public List<CommentsBookViewModel> SubComments { set; get; }


    }
}
