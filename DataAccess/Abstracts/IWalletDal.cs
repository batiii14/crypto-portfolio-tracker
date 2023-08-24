using Core.DataAccess;
using Entities.concretes;

namespace DataAccess.Abstracts
{
    public interface IWalletDal : IEntityRepository<Wallet>
    {
        Wallet GetWalletWithUser();
        Wallet GetWalletWithUserId(int id);
        Boolean IsWalletExist(int id);
    }
}
