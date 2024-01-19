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
    public interface INewsDal : IEntityRepository<News>
    {
        List<NewsDetailDto> GetNewsListDetail(Expression<Func<NewsDetailDto, bool>> filter = null);
        NewsDetailDto GetNewsDetail(Expression<Func<NewsDetailDto, bool>> filter = null);
    }
}
