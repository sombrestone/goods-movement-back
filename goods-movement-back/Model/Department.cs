using System;
using System.Collections.Generic;

namespace goods_movement_back.Model
{
    public class Department
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid ShopId { get; set; }
        public virtual Shop Shop{get; set; }
        public virtual IEnumerable<Worker> Workers { get; set; }
    }
}