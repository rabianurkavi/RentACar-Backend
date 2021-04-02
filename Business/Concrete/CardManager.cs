using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CardManager : ICardService
    {
        ICardDal _cardDal;
        public CardManager(ICardDal cardDal)
        {
            _cardDal = cardDal;
        }
        public IResult Add(Card card)
        {
            _cardDal.Add(card);
           return new SuccessResult(Messages.CardAdded);
        }

        public IResult Delete(Card card)
        {
            _cardDal.Delete(card);
            return new SuccessResult(Messages.CardDeleted);
        }

        public IDataResult<List<Card>> GetAll()
        {
            return new SuccessDataResult<List<Card>>(_cardDal.GetAll(),Messages.CardsListed);
        }

        public IDataResult<List<Card>> GetByCardNumber(string cardNumber)
        {
            return new SuccessDataResult<List<Card>>(_cardDal.GetAll(p => p.CardNumber == cardNumber));
        }

        public IDataResult<Card> GetById(int id)
        {
            return new SuccessDataResult<Card>(_cardDal.Get(c => c.CardId == id));
        }

        public IResult IsCardExist(Card card)
        {
            var result = _cardDal.Get(c => c.FullName == card.FullName && c.CardNumber == card.CardNumber && c.Cvv == card.Cvv);
            if (result == null)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        public IResult Update(Card card)
        {
            _cardDal.Update(card);
            return new SuccessResult(Messages.CardUpdated);
        }
    }
}
