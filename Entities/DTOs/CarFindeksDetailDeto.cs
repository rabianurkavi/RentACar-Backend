using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarFindeksDetailDto:IDto
    {
        public int FindeksId { get; set; }
        public int CarId { get; set; }
        public int FindeksScore { get; set; }
    }
}
