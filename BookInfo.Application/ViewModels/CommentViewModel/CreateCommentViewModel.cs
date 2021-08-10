using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookInfo.Application.ViewModels.CommentViewModel
{
    public class CreateCommentViewModel
    {
        public string Desription { get; set; }
        public int? ParentCommentId { get; set; }
        public int AppUserId { get; set; }
        public int BookId { get; set; }

        
        


    }
}
