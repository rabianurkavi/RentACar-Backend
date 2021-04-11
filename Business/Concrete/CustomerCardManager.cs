using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerCardManager: ICustomerCardService
    {
        private ICustomerCardDal _customerCardDal;

        public CustomerCardManager(ICustomerCardDal customerCardDal)
        {
            _customerCardDal = customerCardDal;
        }

        public IDataResult<List<CustomerCard>> GetAll()
        {
            return new SuccessDataResult<List<CustomerCard>>(_customerCardDal.GetAll());
        }

        public IDataResult<List<CustomerCard>> GetByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<CustomerCard>>(
                _customerCardDal.GetAll(c => c.CustomerId == customerId));
        }

        public IResult Add(CustomerCard customerCard)
        {
            _customerCardDal.Add(customerCard);
            return new SuccessResult();
        }

        public IResult Delete(CustomerCard customerCard)
        {
            _customerCardDal.Delete(customerCard);
            return new SuccessResult();
        }

        public IResult Update(CustomerCard customerCard)
        {
            _customerCardDal.Update(customerCard);
            return new SuccessResult();
        }
    }
}

