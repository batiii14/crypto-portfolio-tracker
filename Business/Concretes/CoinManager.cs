using Business.Abstracts;
using Business.Dtos.requests.coinRequests;
using DataAccess.Abstracts;
using Entities.concretes;
using System.Linq.Expressions;

namespace Business.Concretes
{
    public class CoinManager : ICoinService
    {
        private ICoinDal _coinDal;
        private ICoinUpdaterService _coinUpdaterService;

        public CoinManager(ICoinDal coinDal, ICoinUpdaterService coinUpdaterService)
        {
            _coinDal = coinDal;
            _coinUpdaterService = coinUpdaterService;
        }
        public void Add(AddCoinRequest entity)
        {
            Coin coin = new Coin();
            coin.Name = entity.Name;

            coin.Value = _coinUpdaterService.GetCoinValueFromApi(entity.Name).Result;
            foreach (var item in _coinDal.GetList())
            {
                if (item.Name == entity.Name)
                {
                    throw new Exception("Coin is already exist.");
                }

            }
            _coinDal.Add(coin);
        }

        public void Delete(int id)
        {
            Coin coin = _coinDal.Get(p => p.Id == id);
            _coinDal.Delete(coin);
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

        public void Update(int id, double value)
        {
            Coin coin = _coinDal.Get(p => p.Id == id);
            coin.Value = value;
            _coinDal.Update(coin);
        }
    }
}
