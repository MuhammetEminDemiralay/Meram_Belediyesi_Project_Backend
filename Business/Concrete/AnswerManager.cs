using Business.Abstract;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AnswerManager : IAnswerService
    {
        IAnswerDal _answerDal;

        public AnswerManager(IAnswerDal answerDal)
        {
            _answerDal = answerDal;
        }

        public IResult Add(Answer answer)
        {
            _answerDal.Add(answer);
            return new SuccessResult("Cevap eklendi");
        }

        public IResult Delete(Answer answer)
        {
            _answerDal.Delete(answer);
            return new SuccessResult("Cevap silindi");
        }

        public IDataResult<Answer> Get(int answerId)
        {
            return new SuccessDataResult<Answer>(_answerDal.Get(p => p.Id == answerId));
        }

        public IDataResult<List<Answer>> GetAll()
        {
            return new SuccessDataResult<List<Answer>>(_answerDal.GetAll());
        }

        public IResult Update(Answer answer)
        {
            _answerDal.Update(answer);
            return new SuccessResult("Cevap güncellendi");
        }
    }
}
