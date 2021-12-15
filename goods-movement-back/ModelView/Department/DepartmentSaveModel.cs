using System;
using System.ComponentModel.DataAnnotations;

namespace goods_movement_back.ModelView.Department
{
    public class DepartmentSaveModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public Guid ShopId { get; set; }
    }
}