using System;
using System.ComponentModel.DataAnnotations;

namespace goods_movement_back.ModelView.VAT
{
    public class VatUpdateModel: VatSaveModel
    {
        [Required]
        public Guid Id { get; set; }
    }
}