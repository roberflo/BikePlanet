using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GFStore.ApplicationLayer.Dto.Response
{
    public class UserAuthenticatedResponse: UserDto
    {
        public string UserId { get; set; }
        public string Token { get; set; }
    }
}
