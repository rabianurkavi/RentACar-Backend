using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);
        IResult Delete(User user);
        IResult Update(User user);
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetByUserId(int userId);
        IDataResult<User> GetById(int id);
        IResult EditProfil(User user, string password);
        IDataResult<User> GetUserByEmail(string email);
        List<OperationClaim> GetClaims(User user);
        User GetByMail(string email);
    }
}
