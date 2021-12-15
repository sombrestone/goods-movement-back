using System.ComponentModel.DataAnnotations;

namespace goods_movement_back.ModelView.Shop
{
    public class ShopSaveModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
    }
}