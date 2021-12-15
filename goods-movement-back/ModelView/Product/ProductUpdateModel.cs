using System;
using System.ComponentModel.DataAnnotations;

namespace goods_movement_back.ModelView
{
    public class ProductUpdateModel: ProductSaveModel
    {
        [Required]
        public Guid Id { get; set; }
    }
}