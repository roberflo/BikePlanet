using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using GFShop.DataAccessLayer.Entities;
using GFShop.DataAccessLayer.Repositories.Interfaces;

namespace GFShop.DataAccessLayer.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public UserRepository(GFStoreContext Context) : base(Context)
        {

        }

        public User Create(User user)
        {
            
            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }

        public void Delete(int IdUser)
        {
            var user = _context.Users.Find(IdUser);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        public bool UsernameExist(string username)
        {
            
            if(_context.Users.Where(s => s.Username == username).SingleOrDefault() != null)
            {
                return true;
            }
            return false;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public User GetById(int id)
        {
            return _context.Users.Find(id);
        }

        public User GetByUsername(string username)
        {
            return _context.Users.SingleOrDefault(x => x.Username == username);
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }
    }
}