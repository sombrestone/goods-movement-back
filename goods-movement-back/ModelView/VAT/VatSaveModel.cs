using System;
using System.ComponentModel.DataAnnotations;

namespace goods_movement_back.ModelView.VAT
{
    public class VatSaveModel
    {
        [Required]
        public decimal Percent { get; set; }
    }
}