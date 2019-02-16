using GFStore.ApplicationLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GFStore.BusinessLogicLayer.Interfaces
{
    public interface IUserBol
    {
       
        IEnumerable<UserDto> GetAll();
        UserDto GetById(int id);

        UserDto Create(UserDto user, string password);
        void Update(UserDto user, string password = null);
        void Delete(int id);
    }
}
