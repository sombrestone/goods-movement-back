using System;
using System.ComponentModel.DataAnnotations;

namespace goods_movement_back.ModelView.Department
{
    public class DepartmentUpdateModel: DepartmentSaveModel
    {
        [Required]
        public Guid Id { get; set; }
    }
}