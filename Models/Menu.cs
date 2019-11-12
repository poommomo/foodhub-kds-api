using System.ComponentModel.DataAnnotations.Schema;

namespace FoodHub.Models
{
    public class Menu
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public long OrderStatusId { get; set; }
        [ForeignKey("OrderStatusId")]
        public OrderStatus OrderStatus { get; set; } = null;
    }
}