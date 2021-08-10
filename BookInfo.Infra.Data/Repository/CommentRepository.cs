using BookInfo.Application.Interfaces;
using BookInfo.Application.ViewModels.CommentViewModel;
using BookInfo.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BookInfo.Infra.Data.Repository
{
    public class CommentRepository : ICommentsRepository
    {
        private readonly DataContext _context;

        public CommentRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> ConfirmComment(int[] CommentId)
        {
            if (CommentId.Length > 0)
            {
                foreach (var item in CommentId)
                {
                    var comment = await _context.Comment.FindAsync(item);
                    if (comment == null)
                        return false;
                    comment.IsConfirm = true;

                }
                return true;
            }
            return false;

        }
    }
}
