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
    public interface INewsImageService
    {

        IDataResult<List<NewsImage>> GetAll();
        IDataResult<NewsImage> GetImageByImageId(int imageId);
        IResult Add(IFormFile file, NewsImage newsImage);
        IResult AddCollective(IFormFile[] files, NewsImage newsImage);
        IResult Update(IFormFile file, NewsImage newsImage);
        IResult Delete(NewsImage newsImage);
        IDataResult<List<NewsImage>> GetImagesByNewsId(int newsId);

    }
}
