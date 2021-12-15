using System;

namespace goods_movement_back.ModelView.Department
{
    public class DepartmentModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid ShopId { get; set; }
        public string ShopName { get; set; }
    }
}