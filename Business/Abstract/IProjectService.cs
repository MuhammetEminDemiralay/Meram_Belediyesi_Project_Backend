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
    public interface IProjectService
    {
        IDataResult<List<Project>> GetAll();
        IDataResult<ProjectDetailDto> Get(int projectId);
        IDataResult<List<ProjectDetailDto>> GetProjectDetailByCategoryId(int projectCategoryId);
        IResult Add(Project project);
        IResult Update(Project project);
        IResult Delete(Project project);

    }

}
