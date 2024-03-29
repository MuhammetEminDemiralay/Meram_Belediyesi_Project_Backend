﻿using Core.Utilities.Result;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMessageService
    {
        IDataResult<List<Message>> GetMessagesDetail();
        IDataResult<List<MessageDetailDto>> GetMessageDetailByUserId(int userId);
        IDataResult<Message> GetMessageDetail(int messageId);
        IResult Add(Message message);
        IResult Update(Message message);
        IResult Delete(Message message);
    }
}
