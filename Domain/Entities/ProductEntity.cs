﻿using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProductEntity : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public float Price { get; set; }

        public string Weight { get; set; }

        public string ImageUrl { get; set; }

        public int CategoryId { get; set; }

        public CategoryEntity Category { get; set; }

    }
}
