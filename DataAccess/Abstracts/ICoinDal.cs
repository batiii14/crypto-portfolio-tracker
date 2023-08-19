using Core.DataAccess;
using Entities.concretes;

namespace DataAccess.Abstracts
{
    public interface ICoinDal : IEntityRepository<Coin>
    {
    }
}
