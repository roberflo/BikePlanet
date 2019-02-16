using GFShop.DataAccessLayer.Entities;
using GFStore.ApplicationLayer.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GFShop.DataAccessLayer.Repositories.Interfaces
{
    public interface IProductRepository
    {

        IEnumerable<Product> GetAll();
        
        Product GetById(int id);
        Product Create(Product product);
        void Update(Product product);
        void Delete(Product product);


    }
}