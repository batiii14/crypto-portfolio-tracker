using Core.DataAccess;
using Entities.concretes;

namespace DataAccess.Abstracts
{
    public interface IBuyingTransactionDal : IEntityRepository<BuyingTransaction>
    {
        List<BuyingTransaction> GetBuyingTransactionWithCoin();

    }
}
