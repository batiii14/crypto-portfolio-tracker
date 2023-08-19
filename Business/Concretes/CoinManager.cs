using Business.Abstracts;
using DataAccess.Abstracts;
using Entities.concretes;
using System.Linq.Expressions;

namespace Business.Concretes
{
    public class CoinManager : ICoinService
    {
        private ICoinDal _coinDal;

        public CoinManager(ICoinDal coinDal) {
            _coinDal = coinDal;
        }
        public void Add(Coin entity)
        {
            _coinDal.Add(entity);   
        }

        public void Delete(Coin entity)
        {
            _coinDal.Delete(entity);
        }

        public Coin Get(Expression<Func<Coin, bool>> filter)
        {
            return _coinDal.Get(filter);
        }

        public IList<Coin> GetAllCoin(Expression<Func<Coin, bool>> filter = null)
        {
            return _coinDal.GetList(filter).ToList();
        }

        public IList<Coin> GetAllCoin()
        {
            return _coinDal.GetList().ToList();
        }

        public void Update(Coin entity)
        {
            Coin coin = _coinDal.Get(p=>p.Id==entity.Id);
            coin.Value=entity.Value;
            _coinDal.Update(coin);    
        }
    }
}
