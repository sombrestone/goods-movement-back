using System;
using System.ComponentModel.DataAnnotations;

namespace goods_movement_back.ModelView.Supplier
{
    public class SupplierUpdateModel: SupplierSaveModel
    {
        [Required]
        public Guid Id { get; set; }
    }
}