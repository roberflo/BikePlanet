using GFShop.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GFStore.Utils
{
    public interface IAuthenticationHelper
    {
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        string AuthenticationToken(User user);
        bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt);

    }
}
