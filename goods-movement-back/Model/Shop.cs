using System;
using System.Collections.Generic;

namespace goods_movement_back.Model
{
    public class Shop
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public virtual IEnumerable<Department> Departments { get; set; }
    }
}