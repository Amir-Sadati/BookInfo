using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookInfo.Domain.Entities
{
  
        public class Publisher
      {
        [Key]
        public int PublisherID { get; set; }

        
        public string PublisherName { get; set; }

        public  ICollection<Book> Books { get; set; }
      }
    
}
