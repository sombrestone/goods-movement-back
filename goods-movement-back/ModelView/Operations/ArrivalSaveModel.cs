using System;
using System.ComponentModel.DataAnnotations;

namespace goods_movement_back.ModelView.Operations.Arrival
{
    public class ArrivalSaveModel
    {
        [Required]
        public Guid DepartmentId { get; set; }
        [Required]
        public Guid ProductId { get; set; }
        [Required]
        public Guid SupplierId { get; set; }
        [Required]
        public Guid VatId { get; set; }
        [Required]
        public decimal SupplierPrice { get; set; }
        [Required]
        public decimal SupplierVat { get; set; }
        [Required]
        public decimal MarkupPercent { get; set; }
        [Required]
        public decimal MarkupSum { get; set; }
        [Required]
        public decimal VatRetail { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Number { get; set; }
    }
}