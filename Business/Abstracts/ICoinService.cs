using Entities.concretes;

namespace Business.Abstracts
{
    public interface ICoinService
    {
         void Add(Coin entity);

        IList<Coin> GetAllCoin();
    }
}
