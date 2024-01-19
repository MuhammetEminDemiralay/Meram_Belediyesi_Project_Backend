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
    public class ProjectCategoryManager : IProjectCategoryService
    {
        IProjectCategoryDal _projectCategoryDal;

        public ProjectCategoryManager(IProjectCategoryDal projectCategoryDal)
        {
            _projectCategoryDal = projectCategoryDal;
        }

        public IResult Add(ProjectCategory projectCategory)
        {
            _projectCategoryDal.Add(projectCategory);
            return new SuccessResult();
        }

        public IResult Delete(ProjectCategory projectCategory)
        {
            _projectCategoryDal.Delete(projectCategory);
            return new SuccessResult();
        }

        public IDataResult<ProjectCategory> Get(int projectId)
        {
            return new SuccessDataResult<ProjectCategory>(_projectCategoryDal.Get(p => p.Id == projectId));
        }

        public IDataResult<List<ProjectCategory>> GetAll()
        {
            return new SuccessDataResult<List<ProjectCategory>>(_projectCategoryDal.GetAll());
        }

        public IResult Update(ProjectCategory projectCategory)
        {
            _projectCategoryDal.Update(projectCategory);
            return new SuccessResult();
        }
    }
}
