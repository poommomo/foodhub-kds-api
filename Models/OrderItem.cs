using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodHub.Models
{
    public class OrderItem
    {
        public long Id { get; set; }
        public long OrderInformationId { get; set; }
        [ForeignKey("OrderInformationId")]
        public OrderInformation OrderInformation { get; set; }
        public long MenuId { get; set; }
        [ForeignKey("MenuId")]
        public Menu Menu { get; set; }
        public long OrderStatusId { get; set; }
        [ForeignKey("OrderStatusId")]
        public OrderStatus OrderStatus { get; set; }
    }
}