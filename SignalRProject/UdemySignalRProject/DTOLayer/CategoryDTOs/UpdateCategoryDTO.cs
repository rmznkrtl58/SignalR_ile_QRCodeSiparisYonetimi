﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.CategoryDTOs
{
    public class UpdateCategoryDTO
    {
     
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
