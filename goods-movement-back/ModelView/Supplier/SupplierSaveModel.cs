using System.ComponentModel.DataAnnotations;

namespace goods_movement_back.ModelView.Supplier
{
    public class SupplierSaveModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string UNP { get; set; }
    }
}