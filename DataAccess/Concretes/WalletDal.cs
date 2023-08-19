using Core.DataAccess;
using DataAccess.Abstracts;
using DataAccess.Context;
using Entities.concretes;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concretes
{
    public class WalletDal : EfEntityRepositoryBase<Wallet, CoinAppContext>, IWalletDal
    {
        public Wallet GetWalletWithUser()
        {
            using(CoinAppContext context = new CoinAppContext())
            {
                return context.Wallets.Include(p => p.User).Single();
            }
        }

        public Wallet GetWalletWithUserId(int id)
        {
            using (CoinAppContext context = new CoinAppContext())
            {
                return context.Wallets.Include(w => w.User).FirstOrDefault(w => w.UserId == id);

            }
        }
    }
}
