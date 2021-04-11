using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CarFindeks:IEntity
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int FindeksScore { get; set; }

    }
}
