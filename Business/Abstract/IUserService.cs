using Core.Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);
        //TODO : Add operasyonuna Result dondur.
        void Add(User user);
        User GetByMail(string email);
    }
}
