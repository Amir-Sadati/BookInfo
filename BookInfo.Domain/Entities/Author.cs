using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookInfo.Domain.Entities
{
   public class Author
    {
        [Key]
        public int AuthorId { set; get; }
        public string Name  { get; set; }
        public string Family  { get; set; }
        public ICollection<BookAuthor> BookAuthors { get; set; }


    }
}
