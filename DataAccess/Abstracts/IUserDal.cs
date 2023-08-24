using Core.DataAccess;
using Entities.concretes;

namespace DataAccess.Abstracts
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<User> GetAllWithWallet();
        User GetWithWallet(int id);
        Boolean IsUserExist(int id);
    }
}
