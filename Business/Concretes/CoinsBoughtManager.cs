using Business.Abstracts;
using DataAccess.Abstracts;
using Entities.concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class CoinsBoughtManager : ICoinsBoughtService
    {
        ICoinsBoughtDal _coinsBoughtDal;

        public CoinsBoughtManager(ICoinsBoughtDal coinsBoughtDal)
        {
            _coinsBoughtDal = coinsBoughtDal;   
                
        }

        public void Add(CoinsBought coinsBought)
        {
            _coinsBoughtDal.Add(coinsBought);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<CoinsBought> GetAll()
        {
            throw new NotImplementedException();
        }

        public CoinsBought GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, double quantity)
        {
            CoinsBought coinsBought = _coinsBoughtDal.Get(p=>p.Id == id);
            coinsBought.quantity += quantity;
            _coinsBoughtDal.Update(coinsBought);
        }
    }
}
