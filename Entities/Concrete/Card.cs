using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Card:IEntity
    {
        public int CardId { get; set; }
        public string FullName { get; set; }
        public string CardNumber { get; set; }
        public string Cvv { get; set; }
    }
}
