using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IMessageDal : IEntityRepository<Message>
    {
        List<ProductDetailDto> GetProductsDetail(Expression<Func<ProductDetailDto, bool>> filter = null);
    }
}
