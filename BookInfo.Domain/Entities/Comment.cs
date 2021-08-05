using BookInfo.Domain.Entities.Identities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookInfo.Domain.Entities
{
   public class Comment
    {
        public Comment()
        {
            SubComments = new List<Comment>();
        }

        [Key]
        public int CommentId { get; set; }
        public string Desription { get; set; }
        public bool IsConfirm { get; set; }
        public DateTime PostageDateTime { get; set; }

        [ForeignKey("comment")]
        public int? ParentCommentId { get; set; }
        public  Comment comment { get; set; }
        public  ICollection<Comment> SubComments { get; set; }
        [ForeignKey("AppUser")]
        public int AppUserId { set; get; }
        public AppUser AppUser { set; get; }
        [ForeignKey("Book")]
        public int BookId { set; get; }
        public Book Book { set; get; }
     


    }
}
