using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFWorkDal : EFEntityRepositoryBase<Work, MeramContext>, IWorkDal
    {
        public WorkDetailDto GetWorkDetail(Expression<Func<WorkDetailDto, bool>> filter = null)
        {
            using (var context = new MeramContext())
            {
                var result = from work in context.Works
                             select new WorkDetailDto()
                             {
                                 Id = work.Id,
                                 Title = work.Title,
                                 Body = work.Body,
                                 WorkImagePath = (from img in context.WorkImages where img.WorkId == work.Id select img.WorkImagePath).ToList()

                             };


                return result.Where(filter).SingleOrDefault();
            }
        }

        public List<WorkDetailDto> GetWorkDetails(Expression<Func<WorkDetailDto, bool>> filter = null)
        {
            using (var context = new MeramContext())
            {
                var result = from work in context.Works
                             select new WorkDetailDto()
                             {
                                 Id = work.Id,
                                 Title = work.Title,
                                 Body = work.Body,
                                 WorkImagePath = (from img in context.WorkImages where img.WorkId == work.Id select img.WorkImagePath).ToList()

                             };


                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
