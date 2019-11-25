using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodHub.Models
{
    public class OrderItem
    {
        public long Id { get; set; }
        public long OrderInformationId { get; set; }
        [ForeignKey("OrderInformationId")]
        public virtual OrderInformation OrderInformation { get; set; }
        public long MenuId { get; set; }
        [ForeignKey("MenuId")]
        public virtual Menu Menu { get; set; }
        public long OrderStatusId { get; set; }
        [ForeignKey("OrderStatusId")]
        public OrderStatus OrderStatus { get; set; }
        public int Quantity {get;set;}
    }
}