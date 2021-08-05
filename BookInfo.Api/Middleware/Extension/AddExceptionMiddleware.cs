using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookInfo.Api.Middleware.Extension
{
    public static class AddExceptionMiddleware
    {
        public static IApplicationBuilder AddException(this IApplicationBuilder app )
        {
           return app.UseMiddleware<ExceptionMiddleware>();
         
        }
    }
}
