using Business.Abstract;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class NewsManager : INewsService
    {
        INewsDal _newsDal;

        public NewsManager(INewsDal newsDal)
        {
            _newsDal = newsDal;
        }

        public IResult Add(News news)
        {
            _newsDal.Add(news);
            return new SuccessResult();
        }

        public IResult Delete(News news)
        {
            _newsDal.Delete(news);
            return new SuccessResult();
        }

        public IDataResult<NewsDetailDto> Get(int newsId)
        {
            return new SuccessDataResult<NewsDetailDto>(_newsDal.GetNewsDetail(p => p.Id == newsId));
        }

        public IDataResult<List<NewsDetailDto>> GetAll()
        {
            return new SuccessDataResult<List<NewsDetailDto>>(_newsDal.GetNewsListDetail());
        }

        public IResult Update(News news)
        {
            _newsDal.Update(news);
            return new SuccessResult();
        }
    }
}
