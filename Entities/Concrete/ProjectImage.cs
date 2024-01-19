using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class ProjectImage : IEntity
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string ProjectImagePath { get; set; }
        public DateTime Date { get; set; }
    }
}
