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
using GFShop.ApplicationLayer.Dto.Base;
using GFShop.ApplicationLayer.Dto.Request.Products;

namespace GFStore.BusinessLogicLayer
{
    public class ProductBol : IProductBol
    {
        private IProductRepository _productRepository { get; set; }
         private IInventoryRepository _inventoryRepository {get; set;}
        private IMapper _mapper { get; set; }

        public ProductBol(IProductRepository productRepository, IMapper mapper, IInventoryRepository inventoryRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _inventoryRepository = inventoryRepository;
           
        }
        public IEnumerable<FullProductResponse> GetAll(ProductParamsDto productParams)
        {
            return _mapper.Map<IEnumerable<FullProductResponse>>(_productRepository.GetAll(productParams));
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

        public void InventoryMove(InventoryMoveRequest inventoryMove, int ProductId)
        {
            var product = _productRepository.GetById(ProductId);
             if (product==null)
            {
                 new AppException("Product not found, we cant made the inventory move");       
            }
            var Inventory = new Inventory(){
                   ProductId = ProductId,
                   Product = product,
                   UnitCost = inventoryMove.UnitCost,
                   Quantity = inventoryMove.Quantity,
                   MovementReference = inventoryMove.MovementReference
            };
            if (inventoryMove.Entry)
            {
                Inventory.Entry = DateTime.Now;
            }  else {
                 Inventory.Exit = DateTime.Now;
            }
            _inventoryRepository.Create(Inventory);
        }
    }
}
