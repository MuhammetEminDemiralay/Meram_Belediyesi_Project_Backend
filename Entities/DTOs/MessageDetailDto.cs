using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class MessageDetailDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AnswerId { get; set; }
        public string Title { get; set; }
        public string QuestionBody { get; set; }
        public string AnswerBody { get; set; }
        public bool President { get; set; }
        public bool Completed { get; set; }
        public DateTime? SendDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
