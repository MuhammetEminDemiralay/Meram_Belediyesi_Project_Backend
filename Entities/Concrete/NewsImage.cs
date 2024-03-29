﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class NewsImage : IEntity
    {
        public int Id { get; set; }
        public int NewsId { get; set; }
        public string NewsImagePath { get; set; }
        public DateTime Date { get; set; }
    }
}
