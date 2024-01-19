using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class WorkImage : IEntity
    {
        public int Id { get; set; }
        public int WorkId { get; set; }
        public string WorkImagePath { get; set; }
        public DateTime Date { get; set; }
    }
}
