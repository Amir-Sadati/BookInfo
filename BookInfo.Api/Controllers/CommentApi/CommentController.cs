using AutoMapper;
using BookInfo.Application.Interfaces;
using BookInfo.Application.ViewModels.CommentViewModel;
using BookInfo.Domain.Classes.Identity;
using BookInfo.Domain.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BookInfo.Api.Controllers.CommentApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;

        public CommentController(IUnitOfWork unitofwork,IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }

         [Authorize(AuthenticationSchemes = 
         JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public async Task<IActionResult> Create(CreateCommentViewModel viewmodel)
        {
            if (User.GetUserId() != viewmodel.AppUserId)
                return BadRequest("خطایی رخ داده است");
         if (_unitofwork.BaseRepository<Book>().FindById(viewmodel.BookId) == null)
                return BadRequest("خطایی رخ داده است");
         
        await _unitofwork.BaseRepository<Comment>().AddAsync(_mapper.Map(viewmodel, new Comment() {PostageDateTime=DateTime.Now }));
           if( await _unitofwork.Complete())
            return Ok("پیام شما با موفقیت ثبت شد منتظر تایید مدیر باشید");
           else
            return BadRequest("خطایی رخ داده است");
        }

        [Authorize(AuthenticationSchemes = 
         JwtBearerDefaults.AuthenticationScheme,Policy ="Admin")]
        [HttpPost("ConfirmComment")]
        public async Task<IActionResult> ConfirmComment(int[] CommentId)
        {
          var result= await _unitofwork.commentRepository.ConfirmComment(CommentId);
            if (result)
            {
                 if( await _unitofwork.Complete())
                return Ok("با موفقیت تایید شدند");
            }
            return BadRequest("خطایی رخ داده است");
        }
    }
}
