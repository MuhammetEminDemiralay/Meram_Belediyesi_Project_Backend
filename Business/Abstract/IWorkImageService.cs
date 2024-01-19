using Core.Utilities.Result;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface IWorkImageService
    {

        IDataResult<List<WorkImage>> GetAll();
        IDataResult<WorkImage> GetImageByImageId(int imageId);
        IResult Add(IFormFile file, WorkImage workImage);
        IResult AddCollective(IFormFile[] files, WorkImage workImage);
        IResult Update(IFormFile file, WorkImage workImage);
        IResult Delete(WorkImage workImage);
        IDataResult<List<WorkImage>> GetImagesByWorkId(int workId);

    }
}
