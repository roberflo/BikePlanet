using GFShop.DataAccessLayer.Entities;
using GFStore.ApplicationLayer.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GFShop.DataAccessLayer.Repositories.Interfaces
{
    public interface IUserRepository
    {

        IEnumerable<User> GetAll();
        bool validateTaken(string username);
        User GetById(int id);
        User Create(User user);
        void Update(User user);
        void Delete(int id);

    }
}