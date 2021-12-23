using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace goods_movement_back.ModelView.Operations.Arrival
{
    public class BalanceGetModel
    {
        public IEnumerable<Guid> DepIds { get; set; }
        [Required]
        public Guid ShopId{ get; set; }
    }
}