using System;
using System.Collections.Generic;

namespace goods_movement_back.Model
{
    public class Unit
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        
        public virtual IEnumerable<Product> Products { get; set; }
    }
}