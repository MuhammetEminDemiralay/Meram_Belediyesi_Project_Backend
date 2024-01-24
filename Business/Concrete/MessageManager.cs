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
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public IResult Add(Message message)
        {
            message.Date = DateTime.Now;
            _messageDal.Add(message);
            return new SuccessResult("Message Eklendi");
        }

        public IResult Delete(Message message)
        {
            _messageDal.Delete(message);
            return new SuccessResult("Message deleted");
        }

        public IDataResult<Message> GetMessageDetail(int messageId)
        {
            return new SuccessDataResult<Message>(_messageDal.Get(p => p.Id == messageId));
        }

        public IDataResult<List<Message>> GetMessageDetailByUserId(int userId)
        {
            return new SuccessDataResult<List<Message>>(_messageDal.GetAll(p => p.UserId == userId));
        }

        public IDataResult<List<Message>> GetMessagesDetail()
        {
            return new SuccessDataResult<List<Message>>(_messageDal.GetAll());
        }

        public IResult Update(Message message)
        {
            _messageDal.Update(message);
            return new SuccessResult("Message updated");
        }
    }
}
