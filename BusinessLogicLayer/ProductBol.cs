using GFShop.DataAccessLayer.Repositories.Interfaces;
using GFStore.ApplicationLayer.Dto;
using GFStore.BusinessLogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using AutoMapper;
using GFShop.DataAccessLayer.Entities;
using GFShop.Helpers;
using GFShop.Utils;
using GFStore.Utils;
using GFStore.ApplicationLayer.Dto.Response;
using GFShop.ApplicationLayer.Dto.Response.Products;

namespace GFStore.BusinessLogicLayer
{
    public class ProductBol : IProductBol
    {
        private IProductRepository _productRepository { get; set; }
        private IMapper _mapper { get; set; }

        public ProductBol(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
           
        }
        public IEnumerable<FullProductResponse> GetAll()
        {
            return _mapper.Map<IEnumerable<FullProductResponse>>(_productRepository.GetAll());
        }

        public ProductDto GetById(int id)
        {
            return _mapper.Map<ProductDto>(_productRepository.GetById(id));
        }

        public ProductDto Create(ProductDto productDto)
        {
           var product = _mapper.Map<Product>(productDto);
            return _mapper.Map<ProductDto>( _productRepository.Create(product));
        }

        public void Delete(int id)
        {
            
            var product = _productRepository.GetById(id);
            if (product==null)
            {
                 new AppException("Product not found, we cant delete");
               
            }
            _productRepository.Delete(product);
        }

        public void UpdatePrice(double price, int id)
        {
             var product = _productRepository.GetById(id);
             if (product==null)
            {
                 new AppException("Product not found, we cant update");       
            }
             product.Price = price;
             _productRepository.Update(product);
        }

        public void AddLike(int id)
        {
            var product = _productRepository.GetById(id);
             if (product==null)
            {
                 new AppException("Product not found, we cant update");       
            }
             product.Likes += 1;
             _productRepository.Update(product);
        }
    }
}
