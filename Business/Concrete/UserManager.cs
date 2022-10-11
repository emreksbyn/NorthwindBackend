using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Result;
using DataAccess.Abstract;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            this._userDal = userDal;
        }
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult();
        }

        public IDataResult<User> GetByMail(string email)
        {
            var user = _userDal.Get(u => u.Email == email);
            if (user == null)
                return null;
            return new SuccessDataResult<User>(user);
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            var operationClaims = _userDal.GetClaims(user);
            return new SuccessDataResult<List<OperationClaim>>(operationClaims);
        }
    }
}
