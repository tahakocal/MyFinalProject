﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using FluentValidation;
using Core.Aspect.AutoFac.Validation;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }



        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 17)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);

            }

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            //if (DateTime.Now.Hour == 20)
            //{
            //    return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);

            //}
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }


        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
           ValidationTool.Validate(new ProductValidator(),product);

            _productDal.Add(product);
            return new Result(true, Messages.ProductAdded);
        }
    }
}
