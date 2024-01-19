using Core.Utilities.Result;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IProjectCategoryService
    {
        IDataResult<List<ProjectCategory>> GetAll();
        IDataResult<ProjectCategory> Get(int projectCategoryId);
        IResult Add(ProjectCategory projectCategory);
        IResult Update(ProjectCategory projectCategory);
        IResult Delete(ProjectCategory projectCategory);
    }

}
