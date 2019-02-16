using GFStore.ApplicationLayer.Dto;
using GFStore.BusinessLogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GFStore.BusinessLogicLayer
{
    public class UserBol : IUserBol
    {
        

        public IEnumerable<UserDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserDto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(UserDto user, string password = null)
        {
            throw new NotImplementedException();
        }

        public UserDto Create(UserDto user, string password)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
