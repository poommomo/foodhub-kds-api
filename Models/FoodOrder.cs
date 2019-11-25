using System;
using System.Collections.Generic;

namespace FoodHub.Models
{
    public class FoodOrder
    {
        public string Name { get; set; }
        public long LocationId { get; set; }
        public double TotalPrice { get; set; }
        public List<OrderMenu> MenuList  { get; set; }
    }
}

namespace FoodHub.Models
{
    public class OrderMenu 
    {
        public long MenuId { get; set; }
        public int Quantity { get; set; }
    }

}