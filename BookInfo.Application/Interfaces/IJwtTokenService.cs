using BookInfo.Domain.Entities.Identities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookInfo.Application.Interfaces
{
    public interface IJwtTokenService
    {
      Task<string> CreateToken(AppUser user);
    }
}
