using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Answer : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MessageId { get; set; }
        public string Body { get; set; }
        public DateTime? Date { get; set; }
        public bool? President { get; set; }
    }
}
