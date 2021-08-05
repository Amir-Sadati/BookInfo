using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookInfo.Domain.Entities
{
  public class BookAuthor
    {
        public Book Book  { get; set; }
        public int BookId  { get; set; }
        public int AuthorId  { get; set; }

        public Author Author{ get; set; }

    }
}
