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
    public class EFProjectDal : EFEntityRepositoryBase<Project, MeramContext>, IProjectDal
    {
        public ProjectDetailDto GetProjectDetail(Expression<Func<ProjectDetailDto, bool>> filter = null)
        {
            using (var context = new MeramContext())
            {
                var result = from project in context.Projects
                             join category in context.Categories
                             on project.CategoryId equals category.Id


                             select new ProjectDetailDto()
                             {
                                 Id = project.Id,
                                 Title = project.Title,
                                 CategoryId = category.Id,
                                 Body = project.Body,
                                 ProjectImagePath = (from img in context.ProjectImages where img.ProjectId == project.Id select img.ProjectImagePath).ToList()

                             };


                return result.Where(filter).SingleOrDefault();
            }
        }

        public List<ProjectDetailDto> GetProjectDetails(Expression<Func<ProjectDetailDto, bool>> filter = null)
        {
            using (var context = new MeramContext())
            {
                var result = from project in context.Projects
                             join category in context.Categories
                             on project.CategoryId equals category.Id

                             select new ProjectDetailDto()
                             {
                                 Id = project.Id,
                                 CategoryId = category.Id,
                                 Title = project.Title,
                                 Body = project.Body,
                                 ProjectImagePath = (from img in context.ProjectImages where img.ProjectId == project.Id select img.ProjectImagePath).ToList()
                             };


                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
