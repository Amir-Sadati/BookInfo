using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookInfo.Application.ViewModels.BookViewModel
{
    public class BookInfoViewModel
    {
        public int BookId { get; set; }
        public string BookName { set; get; }
        public string Summary { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public int NumOfPages { get; set; }
        public bool IsPublish { get; set; }
        public int PublishYear { get; set; }
        public string PublisherName { set; get; }
        public List<String> Authors { set; get; }
        public List<String> Categories { set; get; }
        public List<CommentsBookViewModel> Comments { set; get; }

     
        
        
    }
}
