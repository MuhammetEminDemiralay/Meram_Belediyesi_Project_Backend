using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFProductDal : EFEntityRepositoryBase<Product, MeramContext>, IProductDal
    {
        public ProductDetailDto GetProductDetail(Expression<Func<ProductDetailDto, bool>> filter = null)
        {
            using (var context = new MeramContext())
            {
                var result = from product in context.Products
                             join category in context.Categories
                             on product.CategoryId equals category.Id

                             select new ProductDetailDto()
                             {
                                 Id = product.Id,
                                 UserId = product.UserId,
                                 CategoryId = product.CategoryId,
                                 ProductName = product.ProductName,
                                 ProductImagePath = (from img in context.ProductImages where img.ProductId == product.Id select img.ProductImagePath).ToList(),
                                 UnitPrice = product.UnitPrice,
                                 UnitsInStock = product.UnitsInStock,
                                 CategoryName = category.CategoryName,
                                 Description = product.Description
                             };


                return result.Where(filter).SingleOrDefault();

            }
        }

        public List<ProductDetailDto> GetProductsDetail(Expression<Func<ProductDetailDto, bool>> filter = null)
        {
            using (var context = new MeramContext())
            {
                var result = from product in context.Products
                             join category in context.Categories
                             on product.CategoryId equals category.Id

                             select new ProductDetailDto()
                             {
                                 Id = product.Id,
                                 UserId = product.UserId,
                                 CategoryId = product.CategoryId,
                                 ProductName = product.ProductName,
                                 ProductImagePath = (from img in context.ProductImages where img.ProductId == product.Id select img.ProductImagePath).ToList(),
                                 UnitPrice = product.UnitPrice,
                                 UnitsInStock = product.UnitsInStock,
                                 CategoryName = category.CategoryName,
                                 Description = product.Description
                             };


                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
