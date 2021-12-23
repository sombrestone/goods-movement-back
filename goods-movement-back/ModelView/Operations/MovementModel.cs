using System;
using System.Collections.Generic;

namespace goods_movement_back.ModelView.Operations.Arrival
{
    public class MovementModel
    {
        public Guid DepartmentId { get; set; }
        public string DepartmentName{ get; set; }
        public IEnumerable<ProductMovementModel> Products { get; set; }
    }

    public class ProductMovementModel
    {
        public string ProductName{ get; set; }
        public Guid ProductId{ get; set; }
        public string UnitName { get; set; }
        public IEnumerable<ConsignmentMovementModel> Consignments { get; set; }
    }

    public class ConsignmentMovementModel
    {
        public Guid ConsignmentId { get; set; }
        public string DocNumber { get; set; }
        public IEnumerable<MovesModel> Moves { get; set; }
        public decimal Price { get; set; }
        
        public int EndRemainder { get; set; }
    }

    public class MovesModel
    {
        public Guid DocId { get; set; }
        public string DocTypeName{get; set; }
        
        public DateTime Date { get; set; }
        public int Number { get; set; }
        public string DocNumber { get; set; }
    }
}