using System;

namespace goods_movement_back.ModelView.Worker
{
    public class WorkerModel
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Patronymic { get; set; }
        public Guid RoleId { get; set; }
        public string RoleName { get; set; }
    }
}