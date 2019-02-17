using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using GFShop.ApplicationLayer.Dto.Base;
using GFShop.DataAccessLayer.Entities;
using GFShop.DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

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
            IQueryable<Product> query = _context.Products;

            //filter
            if (!string.IsNullOrWhiteSpace(productParams.Category))
            query = query.Where(filter => filter.Category == productParams.Category).AsQueryable<Product>();

            //Sort
            if (productParams.Order_by == "ASC")
                query = query.OrderBy(order => productParams.Sort_by)
                    .AsQueryable<Product>();
            else
            {
                query = query.OrderByDescending(order => productParams.Sort_by)
                    .AsQueryable<Product>();
            }

            //Paging
            query = query.Skip(productParams.Skip).Take(productParams.Take);

            //Navigation Props for Stock
            query = query.Include(inv => inv.Inventory);

            //search
             if (!string.IsNullOrWhiteSpace(productParams.Search))
             query = query.Where(prod => prod.Name.Contains(productParams.Search)).AsQueryable<Product>();

            
            return query.ToList();
        }

        public Product GetById(int id)
        {
             return _context.Products.Find(id);
        }

        
    }
}