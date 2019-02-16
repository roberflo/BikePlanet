using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GFStore.ApplicationLayer.Dto.Response
{
    public interface IAuthorizable
    {
         string Token { get; set; }
    }
}
