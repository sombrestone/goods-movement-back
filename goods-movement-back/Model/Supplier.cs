using System;
using System.Collections.Generic;

namespace goods_movement_back.Model
{
    public class Supplier
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string UNP { get; set; }

        public virtual IEnumerable<Consignment> Consignments{get;set;}
    }
}