using Core.DataAccess;
using DataAccess.Abstracts;
using DataAccess.Context;
using Entities.concretes;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concretes
{
    public class BuyingTransactionDal : EfEntityRepositoryBase<BuyingTransaction, CoinAppContext>, IBuyingTransactionDal
    {

        public List<BuyingTransaction> GetBuyingTransactionWithCoin()
        {
            using (CoinAppContext context = new CoinAppContext())
            {
                return context.BuyingTransactions.Include(b=>b.coinBought).ToList();

            }

        }
    }
}
