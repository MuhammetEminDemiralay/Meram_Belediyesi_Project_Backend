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
    public class EFNewsDal: EFEntityRepositoryBase<News, MeramContext>, INewsDal
    {
        public NewsDetailDto GetNewsDetail(Expression<Func<NewsDetailDto, bool>> filter = null)
        {
            using (var context = new MeramContext())
            {
                var result = from news in context.News
                             select new NewsDetailDto()
                             {
                                 Id = news.Id,
                                 Title = news.Title,
                                 Body = news.Body,
                                 NewsImagePath = (from img in context.NewsImages where img.NewsId == news.Id select img.NewsImagePath).ToList()

                             };


                return result.Where(filter).SingleOrDefault();
            }
        }

        public List<NewsDetailDto> GetNewsListDetail(Expression<Func<NewsDetailDto, bool>> filter = null)
        {
            using (var context = new MeramContext())
            {
                var result = from news in context.News
                             select new NewsDetailDto()
                             {
                                 Id = news.Id,
                                 Title = news.Title,
                                 Body = news.Body,
                                 NewsImagePath = (from img in context.NewsImages where img.NewsId == news.Id select img.NewsImagePath).ToList()
 
                             };


                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
