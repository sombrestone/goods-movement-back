using System;

namespace goods_movement_back.Model
{
    public class Balance
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        
        public Guid DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        
        public Guid ConsignmentId { get; set; }
        public virtual Consignment Consignment { get; set; }
        
        public Guid DocId { get; set; }
        public virtual Doc Doc { get; set; }
    }
}