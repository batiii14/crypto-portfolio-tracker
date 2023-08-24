using Core.DataAccess;
using DataAccess.Abstracts;
using DataAccess.Context;
using Entities.concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes
{
    //: EfEntityRepositoryBase<Coin, CoinAppContext>, ICoinDal
    public class CoinsBoughtDal:EfEntityRepositoryBase<CoinsBought,CoinAppContext>,ICoinsBoughtDal
    {
    }
}
