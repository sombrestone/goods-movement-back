using System;
using System.Collections.Generic;

namespace goods_movement_back.ModelView.Operations.Arrival
{

    public class BalanceModel
    {
        public Guid DepartmentId { get; set; }
        public string DepartmentName{ get; set; }
        public IEnumerable<ProductItem> Products{ get; set; }
    }

    public class ProductItem: BalanceSmartModel
    {
        public Guid SupplierId { get; set; }
        public string SupplierName{ get; set; }
    }
}