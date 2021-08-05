using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookInfo.Application.ViewModels
{
    public class BooksViewModel
    {
        [Display(Name ="نام کتاب")]

        public string BookName { set; get; }
        [Display(Name = "خلاصه")]
        public string Summary { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public string ImageUrl { get; set; }
        public int NumOfPages { get; set; }
        public short Weight { get; set; }
        public bool? IsPublish { get; set; }
        public DateTime? PublishDate { get; set; }
        public int PublishYear { get; set; }
        public int PublisherName { set; get; }
        public ICollection<BookCategoryViewModel> BookCategories { get; set; }
        //public ICollection<BookAuthor> BookAuthors { get; set; }
        //public ICollection<Comment> Comments { get; set; }
    }
}
