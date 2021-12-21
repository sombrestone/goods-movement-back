using System;
using System.ComponentModel.DataAnnotations;

namespace goods_movement_back.ModelView.Operations.Arrival
{
    public class MoveSaveModel
    {
        [Required]
        public Guid FromDepId { get; set; }
        [Required]
        public Guid ToDepId { get; set; }
        [Required]
        public Guid ConsignmentId { get; set; }
        [Required]
        public int Number { get; set; }
    }
}