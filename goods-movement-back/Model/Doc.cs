using System;

namespace goods_movement_back.Model
{
    public class Doc
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public DateTime Date { get; set; }
        
        public Guid DocTypeId { get; set; }
        public virtual DocType DocType { get; set; }
    }
}