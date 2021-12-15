using System;

namespace goods_movement_back.Model
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid UnitId { get; set; }
        
        public virtual Unit Unit { get; set; }
    }
}