using System;
using System.ComponentModel.DataAnnotations;

namespace goods_movement_back.ModelView.Worker
{
    public class WorkerRegistrationModel
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string Patronymic { get; set; }
        public Guid? DepartmentId { get; set; }
    }
}