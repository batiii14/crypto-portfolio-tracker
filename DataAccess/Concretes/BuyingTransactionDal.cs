using Core.DataAccess;
using DataAccess.Abstracts;
using DataAccess.Context;
using Entities.concretes;

namespace DataAccess.Concretes
{
    public class BuyingTransactionDal: EfEntityRepositoryBase<BuyingTransaction, CoinAppContext>,IBuyingTransactionDal
    {
    }
}
