﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class ProductDetailDto : IDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public int? CompanyId { get; set; }
        public string ProductName { get; set; }
        public int UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public string CategoryName { get; set; }
        public List<string> ProductImagePath { get; set; }
        public string? CompanyName { get; set; }
        public string Description { get; set; }
    }
}
