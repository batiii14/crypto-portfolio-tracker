using Core.DataAccess;
using Entities.concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts
{
    public interface ICoinsBoughtDal : IEntityRepository<CoinsBought>
    {
    }
}
