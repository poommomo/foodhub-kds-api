using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodHub.Models
{
    public class OrderInformation
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double TotalPrice { get; set; }
        public DateTime OrderDateTime { get; set; }
        public DateTime FinishDateTime { get; set; }
        public bool IsFinished { get; set; }
        public string Table { get; set; }        
    }
}

/**
* Id
* Number
* TotalPrice
* *Pos*
* OrderDateTime
* FinishDateTime
* IsFinished
* *Table*
* *[Menu]*
*/