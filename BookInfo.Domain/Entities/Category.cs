using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookInfo.Domain.Entities
{
     public class Category
    {
         public Category()
        {
            categories = new List<Category>();
        }
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        [ForeignKey("category")]
        public int? ParentCategoryID { get; set; }

        public  Category category { get; set; }
        public  ICollection<Category> categories { get; set; }
        public  ICollection<BookCategory> BookCategories { get; set; }
    }
}
