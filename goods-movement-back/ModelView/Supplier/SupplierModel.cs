using System;

namespace goods_movement_back.ModelView.Supplier
{
    public class SupplierModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string UNP { get; set; }
    }
}