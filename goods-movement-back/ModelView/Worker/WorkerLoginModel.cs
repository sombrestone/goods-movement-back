using System.ComponentModel.DataAnnotations;

namespace goods_movement_back.ModelView.Worker
{
    public class WorkerLoginModel
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
    }
}