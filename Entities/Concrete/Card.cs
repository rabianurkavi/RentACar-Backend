using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Card:IEntity
    {
        public int Id { get; set; }
        public string NameOnTheCard { get; set; }
        public string CardNumber { get; set; }
        public string Cvv { get; set; }
        public string ExpirationDate { get; set; }
        public decimal MoneyInTheCard { get; set; }
    }
}
