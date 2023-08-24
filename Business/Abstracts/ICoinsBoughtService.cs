using Entities.concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface ICoinsBoughtService
    {
        void Add(CoinsBought coinsBought);
        List<CoinsBought> GetAll();
        CoinsBought GetById(int id);
        void Update(int id, double quantity);
        void Delete(int id);
    }
}
