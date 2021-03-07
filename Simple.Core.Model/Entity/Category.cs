﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Core.Model.Entity
{
   public class Category:EntityBase
   {
       public int ParentId { get; set; } = 0;
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
