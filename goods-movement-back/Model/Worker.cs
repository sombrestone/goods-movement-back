using System;

namespace goods_movement_back.Model
{
    public class Worker
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Patronymic { get; set; }
        
        public Guid DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        
        public Guid RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}