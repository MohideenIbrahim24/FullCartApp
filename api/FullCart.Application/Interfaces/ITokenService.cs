using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FullCart.Domain.Entities.Identities;

namespace FullCart.Application.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}