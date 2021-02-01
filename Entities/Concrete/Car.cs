using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Car:IEntity
    {
        public int ProductId { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public decimal ModelYear { get; set; }
        public decimal DailyPrica { get; set; }
        public string Description { get; set; }
    }
}
