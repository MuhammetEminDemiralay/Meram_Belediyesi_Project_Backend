using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAnswerService
    {
        IDataResult<List<Answer>> GetAll();
        IDataResult<Answer> Get(int answerId);
        IResult Add(Answer answer);
        IResult Update(Answer answer);
        IResult Delete(Answer answer);
    }
}
