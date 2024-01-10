using Core.Utilities.Result;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductImageService
    {

        IDataResult<List<ProductImage>> GetAll();
        IDataResult<ProductImage> GetImageByImageId(int imageId);
        IResult Add(IFormFile file, ProductImage productImage);
        IResult AddCollective(IFormFile[] files, ProductImage productImage);
        IResult Update(IFormFile file, ProductImage productImage);
        IResult Delete(ProductImage productImage);
        IDataResult<List<ProductImage>> GetImagesByProductId(int productId);

    }
}
