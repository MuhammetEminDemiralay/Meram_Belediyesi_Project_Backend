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
    public class EFMessageDal : EFEntityRepositoryBase<Message, MeramContext>, IMessageDal
    {
        public List<MessageDetailDto> GetMessagesDetail(Expression<Func<MessageDetailDto, bool>> filter = null)
        {
            using (var context = new MeramContext())
            {
                var result = from question in context.Messages
                             join answer in context.Answers
                             on question.Id equals answer.MessageId

                             select new MessageDetailDto()
                             {
                                 Id = question.Id,
                                 UserId = question.UserId,
                                 AnswerId = answer.MessageId,
                                 Title = question.Title,
                                 QuestionBody = question.Body,
                                 AnswerBody = answer.Body,
                                 President = question.President,
                                 SendDate = question.Date,
                                 ReturnDate = answer.Date
                             };
                             return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
