using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class ProjectCategory : IEntity
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
    }
}
