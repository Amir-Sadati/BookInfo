using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookInfo.Domain.Entities
{
     public  class BookCategory
    {
        
        public Book Book { set; get; }
        public int BookId { set; get; }
        public Category Category { set; get; }
        public int CategoryId { set; get; }

    }
}
