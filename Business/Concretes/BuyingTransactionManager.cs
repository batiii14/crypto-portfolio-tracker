using Business.Abstracts;
using DataAccess.Abstracts;
using Entities.concretes;
using System.Linq.Expressions;

namespace Business.Concretes
{
    public class BuyingTransactionManager : IBuyingTransactionService
    {
        private IBuyingTransactionDal _buyingTransactionDal;
        public BuyingTransactionManager(IBuyingTransactionDal buyingTransactionDal)
        {
            _buyingTransactionDal = buyingTransactionDal;
        }

        public void Add(BuyingTransaction entity)
        {
            _buyingTransactionDal.Add(entity);
        }

        public void Delete(BuyingTransaction entity)
        {
            _buyingTransactionDal.Delete(entity);
        }

        public BuyingTransaction Get(Expression<Func<BuyingTransaction, bool>> filter)
        {
            return _buyingTransactionDal.Get(filter);
        }

        public IList<BuyingTransaction> GetList(Expression<Func<BuyingTransaction, bool>> filter = null)
        {
            return _buyingTransactionDal.GetList(filter).ToList();   
        }

        public void Update(BuyingTransaction entity)
        {
            _buyingTransactionDal.Update(entity);
        }
    }
}
