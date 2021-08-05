using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookInfo.Application.ViewModels.BookViewModel
{
   public class BookEditViewModel
    {
        
        public int BookId { get; set; }
        public string BookName { set; get; }
        public string Summary { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public string ImageUrl { get; set; }
        public int NumOfPages { get; set; }
        public short Weight { get; set; }
        public bool? IsPublish { get; set; }
        public DateTime? PublishDate { get; set; }
        public int PublishYear { get; set; }
        public bool Delete { set; get; }
        public int PublisherId { set; get; }
        public List<int> AuthorId { set; get; }
        public List<int> CategroyId { set; get; }
        

    }
}
