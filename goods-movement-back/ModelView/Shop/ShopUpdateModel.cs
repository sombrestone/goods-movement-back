using System;
using System.ComponentModel.DataAnnotations;

namespace goods_movement_back.ModelView.Shop
{
    public class ShopUpdateModel
    {
        [Required]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}