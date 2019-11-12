using System.ComponentModel.DataAnnotations.Schema;

namespace FoodHub.Models
{
    public class Pos
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long LocationId { get; set; }
        [ForeignKey("LocationId")]
        public Location Location { get; set; }
    }
}