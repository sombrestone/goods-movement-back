using System;
using System.ComponentModel.DataAnnotations;

namespace goods_movement_back.ModelView.Unit
{
    public class UnitUpdateModel: UnitSaveModel
    {
        [Required]
        public Guid Id { get; set; }
    }
}