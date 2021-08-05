using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookInfo.Domain.Entities
{
    public class Book
    {
        [Key]
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
        [ForeignKey("Publisher")]
        public int PublisherId { set; get; }
        public Publisher Publisher { get; set; }
        public ICollection<BookCategory> BookCategories { get; set; }
        public ICollection<BookAuthor> BookAuthors { get; set; }
        public ICollection<Comment> Comments { get; set; }




    }
}
