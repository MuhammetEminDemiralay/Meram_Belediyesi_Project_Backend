using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IWorkDal : IEntityRepository<Work>
    {
        List<WorkDetailDto> GetWorkDetails(Expression<Func<WorkDetailDto, bool>> filter = null);
        WorkDetailDto GetWorkDetail(Expression<Func<WorkDetailDto, bool>> filter = null);
    }
}
