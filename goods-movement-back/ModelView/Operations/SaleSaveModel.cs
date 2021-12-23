using System;
using System.ComponentModel.DataAnnotations;

namespace goods_movement_back.ModelView.Operations.Arrival
{
    public class SaleSaveModel
    {
        [Required]
        public Guid ConsignmentId { get; set; }
        [Required]
        public Guid DepartmentId { get; set; }
        [Required]
        public int Number { get; set; }
    }
}