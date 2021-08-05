using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookInfo.Application.ViewModels.BookViewModel
{
   public class BooksPageListViewModel
    {
      
        
        public string BookName { set; get; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public string ImageUrl { get; set; }
        public int PublishYear { get; set; }
        public string PublisherPublisherName { set; get; }
        public  int Row { set; get; }
         
           
       
     
      
        
    }
}
