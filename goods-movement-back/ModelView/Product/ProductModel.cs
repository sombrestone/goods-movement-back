using System;

namespace goods_movement_back.ModelView
{
    public class ProductModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UnitName { get; set; }
        public string UnitShortName { get; set; }
        public Guid UnitId { get; set; }
    }
}