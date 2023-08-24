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
            using (CoinAppContext context = new CoinAppContext())
            {
                return context.Wallets.Include(wallet => wallet.User).Include(wallet => wallet.CoinList).Single();

            }
        }

        public Wallet GetWalletWithUserId(int id)
        {
            using (CoinAppContext context = new CoinAppContext())
            {
                return context.Wallets.Include(w => w.User).Include(w => w.CoinList).FirstOrDefault(w => w.UserId == id);

            }
        }

        public bool IsWalletExist(int id)
        {
            using (CoinAppContext context = new CoinAppContext())
            {
                try
                {

                    Wallet wallet = context.Wallets.Where(w => w.WalletId == id).Single();
                    return true;
                }
                catch (Exception e)
                {

                    throw new Exception("You do not have wallet! Please create a wallet");
                }
            }
        }
    }
}
