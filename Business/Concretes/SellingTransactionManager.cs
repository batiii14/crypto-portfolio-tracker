using Business.Abstracts;
using DataAccess.Abstracts;
using Entities.concretes;
using System.Linq.Expressions;

namespace Business.Concretes
{
    public class SellingTransactionManager : ISellingTransactionService
    {
        private ISellingTransactionDal _sellTransactionDal;
        public SellingTransactionManager(ISellingTransactionDal sellTransactionDal)
        {
            _sellTransactionDal = sellTransactionDal;
        }
        public void Add(SellingTransaction entity)
        {
            _sellTransactionDal.Add(entity);

        }

        public void Delete(SellingTransaction entity)
        {
            _sellTransactionDal.Delete(entity);
        }

        public SellingTransaction Get(Expression<Func<SellingTransaction, bool>> filter)
        {
            return _sellTransactionDal.Get(filter);
        }

        public IList<SellingTransaction> GetList(Expression<Func<SellingTransaction, bool>> filter = null)
        {
            return _sellTransactionDal.GetList(filter).ToList();
        }

        public void Update(SellingTransaction entity)
        {
            _sellTransactionDal.Update(entity);
        }
    }
}
