using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;

namespace WebApi.Interfaces
{
   public interface ITokenService
   {
       Task<string> CreateToken(AppUser user);
   }
}
