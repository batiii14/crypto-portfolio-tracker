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
            using(CoinAppContext context = new CoinAppContext())
            {
                return context.Users.Include(p=>p.Wallet).ToList();
            }
        }

        public User GetWithWallet(int id)
        {
            using (CoinAppContext context = new CoinAppContext())
            {
                return context.Users.Include(p => p.Wallet).Where(p=>p.UserId==id).Single();
            }

        }
    }
}
