using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using GFShop.ApplicationLayer.Dto.Base;
using GFShop.DataAccessLayer.Entities;
using GFShop.DataAccessLayer.Repositories.Interfaces;

namespace GFShop.DataAccessLayer.Repositories
{
    public class ProductRepository : RepositoryBase, IProductRepository
    {
        public ProductRepository(GFStoreContext Context) : base(Context)
        {

        }

        public Product Create(Product product)
        {
            
            _context.Products.Add(product);
            _context.SaveChanges();

            return product;
        }

        public void Delete(Product product)
        {
            
                _context.Products.Remove(product);
                _context.SaveChanges();    
        }

        
        public void Update(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        

        public IEnumerable<Product> GetAll(ProductParamsDto productParams)
        {
             var query = _context.Products;
            
            //Sort
            if (productParams.Order_by == "ASC")
                query.OrderBy(order => productParams.Sort_by);
            else
            {
                query.OrderByDescending(order => productParams.Sort_by);
            }

            //filter
            if (!string.IsNullOrWhiteSpace(productParams.Filter))
            query.Where(filter => filter.Category == "Promotions");
            
            //Paging
            query.Take(productParams.Take).Skip(productParams.Skip);

          
            return query.ToList();
        }

        public Product GetById(int id)
        {
             return _context.Products.Find(id);
        }
    }
}