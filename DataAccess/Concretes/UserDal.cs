using Core.DataAccess;
using DataAccess.Abstracts;
using DataAccess.Context;
using Entities.concretes;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concretes
{
    public class UserDal : EfEntityRepositoryBase<User, CoinAppContext>, IUserDal
    {
        public List<User> GetAllWithWallet()
        {
            using (CoinAppContext context = new CoinAppContext())
            {
                return context.Users.Include(p => p.Wallet).Include(p => p.Wallet.CoinList).ToList();
            }
        }

        public User GetWithWallet(int id)
        {
            using (CoinAppContext context = new CoinAppContext())
            {
                return context.Users.Include(p => p.Wallet).Where(p => p.UserId == id).Include(p => p.Wallet.CoinList).Single();
            }

        }

        public bool IsUserExist(int id)
        {


            try
            {
                using (CoinAppContext context = new CoinAppContext())
                {
                    User user = context.Users.Where(p => p.UserId == id).Single();
                    return true;
                }
            }
            catch (Exception e)
            {

                throw new Exception("User is not exist!");
            }

        }
    }
}
