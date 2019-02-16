using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GFStore.ApplicationLayer.Dto.Response
{
    public class AuthenticatedUserResponse : UserDto, IAuthorizable
    {
        public string Token { get; set; }
    }
}
