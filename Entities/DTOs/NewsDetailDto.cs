using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class NewsDetailDto : IDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public List<string> NewsImagePath { get; set; }
    }
}
