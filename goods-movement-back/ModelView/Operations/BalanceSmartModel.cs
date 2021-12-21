using System;

namespace goods_movement_back.ModelView.Operations.Arrival
{
    public class BalanceSmartModel
    {
        public Guid ProductId { get; set; }
        public Guid ConsignmentId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Number { get; set; }
        
    }
}