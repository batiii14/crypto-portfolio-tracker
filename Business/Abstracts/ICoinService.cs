using Business.Dtos.requests.coinRequests;
using Entities.concretes;

namespace Business.Abstracts
{
    public interface ICoinService
    {
        // void Add(Coin entity);
         void Add(AddCoinRequest addCoinRequest);
        void Update(int id, double value);
        void Delete(int id);
        IList<Coin> GetAllCoin();
    }
}
