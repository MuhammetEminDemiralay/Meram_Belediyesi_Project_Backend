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
    public class NewsImageManager : INewsImageService
    {
        private INewsImageDal _newsImageDal;

        public NewsImageManager(INewsImageDal newsImageDal)
        {
            _newsImageDal = newsImageDal;
        }

        public IResult Add(IFormFile file, NewsImage newsImage)
        {
            newsImage.NewsImagePath = FileHelper.Add(file);
            newsImage.Date = DateTime.Now;
            _newsImageDal.Add(newsImage);
            return new SuccessResult("News image added");
        }

        public IResult AddCollective(IFormFile[] files, NewsImage newsImage)
        {
            foreach (var file in files)
            {
                newsImage = new NewsImage { NewsId= newsImage.NewsId};
                Add(file, newsImage);
            }
            return new SuccessResult("Oldu");
        }

        public IResult Delete(NewsImage newsImage)
        {
            _newsImageDal.Delete(newsImage);
            return new SuccessResult();
        }

        public IDataResult<List<NewsImage>> GetAll()
        {
            return new SuccessDataResult<List<NewsImage>>(_newsImageDal.GetAll(), "Hberler listelendi");
        }

        public IDataResult<List<NewsImage>> GetImagesByNewsId(int newsId)
        {
            return new SuccessDataResult<List<NewsImage>>(_newsImageDal.GetAll(p => p.NewsId == newsId));
        }

        public IDataResult<NewsImage> GetImageByImageId(int imageId)
        {
            return new SuccessDataResult<NewsImage>(_newsImageDal.Get(p => p.Id == imageId));
        }


        public IResult Update(IFormFile file, NewsImage newsImage)
        {
            NewsImage oldNewImage = GetImageByImageId(newsImage.Id).Data;
            newsImage.NewsImagePath= FileHelper.Update(file, oldNewImage.NewsImagePath);
            newsImage.Date = DateTime.Now;
            newsImage.NewsId= oldNewImage.NewsId;
            _newsImageDal.Update(newsImage);
            return new SuccessResult("News image updated");
        }
    }
}

