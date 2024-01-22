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
    public class ProjectManager : IProjectService
    {
        IProjectDal _projectDal;

        public ProjectManager(IProjectDal projectDal)
        {
            _projectDal = projectDal;
        }

        public IResult Add(Project project)
        {
            _projectDal.Add(project);
            return new SuccessResult();
        }

        public IResult Delete(Project project)
        {
            _projectDal.Delete(project);
            return new SuccessResult();
        }

        public IDataResult<List<Project>> GetAll()
        {
            return new SuccessDataResult<List<Project>>(_projectDal.GetAll());
        }
        public IDataResult<ProjectDetailDto> GetProjectDetailByProjectId(int projectId)
        {
            return new SuccessDataResult<ProjectDetailDto>(_projectDal.GetProjectDetail(p => p.Id == projectId));
        }

        public IDataResult<List<ProjectDetailDto>> GetProjectDetailByCategoryId(int projectCategoryId)
        {
            return new SuccessDataResult<List<ProjectDetailDto>>(_projectDal.GetProjectDetails(p => p.CategoryId == projectCategoryId));
        }

        public IResult Update(Project project)
        {
            _projectDal.Update(project);
            return new SuccessResult();
        }
    }
}
