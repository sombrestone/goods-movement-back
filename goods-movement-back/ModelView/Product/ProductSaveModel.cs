using System;
using System.ComponentModel.DataAnnotations;

namespace goods_movement_back.ModelView
{
    public class ProductSaveModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public Guid UnitId { get; set; }
    }
}