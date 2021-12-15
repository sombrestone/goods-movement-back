using System;

namespace goods_movement_back.Model
{
    public class Consignment
    {
        public Guid Id { get; set; }
        
        public decimal SupplierPrice { get; set; }
        public decimal SupplierVat { get; set; }
        
        public decimal MarkupPercent { get; set; }
        public decimal MarkupSum { get; set; }
        
        public decimal VatRetail { get; set; }
        public decimal Price { get; set; }
        
        public Guid VATId { get; set; }
        public virtual VAT VAT { get; set; }
        
        public Guid SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
        
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}