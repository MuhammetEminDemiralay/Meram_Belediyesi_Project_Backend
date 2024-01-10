using Business.Abstract;
using Core.Utilities.FileHelper;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductImageMagager : IProductImageService
    {

        private IProductImageDal _imageDal;

        public ProductImageMagager(IProductImageDal imageDal)
        {
            _imageDal = imageDal;
        }

        public IResult Add(IFormFile file, ProductImage productImage)
        {
            productImage.ProductImagePath = FileHelper.Add(file);
            productImage.Date = DateTime.Now;
            _imageDal.Add(productImage);
            return new SuccessResult("Product image added");
        }

        public IResult AddCollective(IFormFile[] files, ProductImage productImage)
        {
            foreach (var file in files)
            {
                productImage = new ProductImage { ProductId = productImage.ProductId };
                Add(file, productImage);
            }
            return new SuccessResult("Oldu");
        }

        public IResult Delete(ProductImage productImage)
        {
            _imageDal.Delete(productImage);
            return new SuccessResult();
        }

        public IDataResult<List<ProductImage>> GetAll()
        {
            return new SuccessDataResult<List<ProductImage>>(_imageDal.GetAll(), "RESİMLER lİSTELENDİ");
        }

        public IDataResult<List<ProductImage>> GetImagesByProductId(int productId)
        {
            return new SuccessDataResult<List<ProductImage>>(_imageDal.GetAll(p => p.ProductId == productId));
        }

        public IDataResult<ProductImage> GetImageByImageId(int imageId)
        {
            return new SuccessDataResult<ProductImage>(_imageDal.Get(p => p.Id == imageId));
        }


        public IResult Update(IFormFile file, ProductImage productImage)
        {
            ProductImage oldProductImage = GetImageByImageId(productImage.Id).Data;
            productImage.ProductImagePath = FileHelper.Update(file, oldProductImage.ProductImagePath);
            productImage.Date = DateTime.Now;
            productImage.ProductId = oldProductImage.ProductId;
            _imageDal.Update(productImage);
            return new SuccessResult("Product image updated");
        }
    }
}
