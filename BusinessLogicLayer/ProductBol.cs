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
        public IEnumerable<ProductDto> GetAll()
        {
            return _mapper.Map<IEnumerable<ProductDto>>(_productRepository.GetAll());
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

        

        
      
    }
}
