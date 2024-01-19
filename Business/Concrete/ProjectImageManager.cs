using Business.Abstract;
using Core.Utilities.FileHelper;
using Core.Utilities.Result;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProjectImageManager : IProjectImageService
    {
        private IProjectImageDal _projectImageDal;

        public ProjectImageManager(IProjectImageDal projectImageDal)
        {
            _projectImageDal = projectImageDal;
        }

        public IResult Add(IFormFile file, ProjectImage projectImage)
        {
            projectImage.ProjectImagePath = FileHelper.Add(file);
            projectImage.Date = DateTime.Now;
            _projectImageDal.Add(projectImage);
            return new SuccessResult("News image added");
        }

        public IResult AddCollective(IFormFile[] files, ProjectImage projectImage)
        {
            foreach (var file in files)
            {
                projectImage = new ProjectImage { ProjectId = projectImage.ProjectId};
                Add(file, projectImage);
            }
            return new SuccessResult("Oldu");
        }

        public IResult Delete(ProjectImage projectImage)
        {
            _projectImageDal.Delete(projectImage);
            return new SuccessResult();
        }

        public IDataResult<List<ProjectImage>> GetAll()
        {
            return new SuccessDataResult<List<ProjectImage>>(_projectImageDal.GetAll(), "Proje resimleri listelendi");
        }

        public IDataResult<List<ProjectImage>> GetImagesByProjectId(int projectId)
        {
            return new SuccessDataResult<List<ProjectImage>>(_projectImageDal.GetAll(p => p.ProjectId == projectId));
        }

        public IDataResult<ProjectImage> GetImageByImageId(int imageId)
        {
            return new SuccessDataResult<ProjectImage>(_projectImageDal.Get(p => p.Id == imageId));
        }


        public IResult Update(IFormFile file, ProjectImage projectImage)
        {
            ProjectImage oldNewImage = GetImageByImageId(projectImage.Id).Data;
            projectImage.ProjectImagePath= FileHelper.Update(file, oldNewImage.ProjectImagePath);
            projectImage.Date = DateTime.Now;
            projectImage.ProjectId= oldNewImage.ProjectId;
            _projectImageDal.Update(projectImage);
            return new SuccessResult("News image updated");
        }
    }
}
