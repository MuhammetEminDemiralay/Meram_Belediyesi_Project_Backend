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
    public interface INewsService
    {
        IDataResult<List<NewsDetailDto>> GetAll();
        IDataResult<NewsDetailDto> Get(int newsId);
        IResult Add(News news);
        IResult Update(News news);
        IResult Delete(News news);
    }
}
