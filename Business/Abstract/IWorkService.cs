using Core.Utilities.Result;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IWorkService
    {
        IDataResult<List<WorkDetailDto>> GetAll();
        IDataResult<WorkDetailDto> Get(int workId);
        IResult Add(Work work);
        IResult Update(Work work);
        IResult Delete(Work work);
    }
}
