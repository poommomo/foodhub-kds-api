using System;
using System.Collections.Generic;

namespace FoodHub.Models
{
    public class DisplayOrder
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime OrderDateTime { get; set; }
        public bool IsFinished { get; set; }
        public Location Location { get; set; }        
        public List<DisplayMenu> Menus { get; set; }
    }

    public class DisplayMenu
    {
        public long Id { get; set; }
        public string Name { get; set; }    
        public int Quantity { get; set; }
    }

}