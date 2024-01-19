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
    public class WorkManager : IWorkService
    {
        IWorkDal _workDal;

        public WorkManager(IWorkDal workDal)
        {
            _workDal = workDal;
        }

        public IResult Add(Work work)
        {
            _workDal.Add(work);
            return new SuccessResult();
        }

        public IResult Delete(Work work)
        {
            _workDal.Delete(work);
            return new SuccessResult();
        }

        public IDataResult<WorkDetailDto> Get(int workId)
        {
            return new SuccessDataResult<WorkDetailDto>(_workDal.GetWorkDetail(p => p.Id == workId));
        }

        public IDataResult<List<WorkDetailDto>> GetAll()
        {
            return new SuccessDataResult<List<WorkDetailDto>>(_workDal.GetWorkDetails());
        }

        public IResult Update(Work work)
        {
            _workDal.Update(work);
            return new SuccessResult();
        }
    }
}
