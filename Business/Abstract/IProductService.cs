using Core.Utilities.Result;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {

        IDataResult<List<Product>> GetAll();
        IDataResult<List<Product>> GetByCategoryId(int categoryId);
        IResult Add(Product product);
        IResult Delete(Product product);
        IResult Update(Product product);
        IResult AddTransactionalTest(Product product);

        IDataResult<List<ProductDetailDto>> GetProductDetails();
        IDataResult<List<ProductDetailDto>> GetProductDetailsByCategoryId(int categoryId);
        IDataResult<ProductDetailDto> GetProductDetailByProductId(int productId);
        IDataResult<List<ProductDetailDto>> GetProductDetailsByUserId(int userId);

    }
}
