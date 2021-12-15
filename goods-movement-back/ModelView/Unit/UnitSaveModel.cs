using System.ComponentModel.DataAnnotations;

namespace goods_movement_back.ModelView.Unit
{
    public class UnitSaveModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string ShortName { get; set; }
    }
}