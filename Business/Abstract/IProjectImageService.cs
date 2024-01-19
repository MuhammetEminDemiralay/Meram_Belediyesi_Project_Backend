using Core.Utilities.Result;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface IProjectImageService
    {
        IDataResult<List<ProjectImage>> GetAll();
        IDataResult<ProjectImage> GetImageByImageId(int imageId);
        IResult Add(IFormFile file, ProjectImage projectImage);
        IResult AddCollective(IFormFile[] files, ProjectImage projectImage);
        IResult Update(IFormFile file, ProjectImage projectImage);
        IResult Delete(ProjectImage projectImage);
        IDataResult<List<ProjectImage>> GetImagesByProjectId(int projectId);
    }

}
