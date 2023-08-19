using Core.DataAccess;
using Entities.concretes;

namespace DataAccess.Abstracts
{
    public interface ICoinUpdaterDal:IEntityRepository<CoinUpdater>
    {
        //Task<CoinUpdater> GetCoinUpdaterByNameAsync(string coinName);
        //Task<int> UpdateCoinValueAsync(CoinUpdater coinUpdater);

    }
}
