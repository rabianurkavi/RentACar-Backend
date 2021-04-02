using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICardService
    {
        IDataResult<List<Card>> GetAll();
        IResult Add(Card card);
        IResult Delete(Card card);
        IResult Update(Card card);
        IDataResult<Card> GetById(int id);
        IDataResult<List<Card>> GetByCardNumber(string cardNumber);
        IResult IsCardExist(Card card);
    }
}
