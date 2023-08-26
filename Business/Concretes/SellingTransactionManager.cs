using Business.Abstracts;
using DataAccess.Abstracts;
using Entities.concretes;

namespace Business.Concretes
{
    public class SellingTransactionManager : ISellingTransactionService
    {
        private ISellingTransactionDal _sellTransactionDal;
        public SellingTransactionManager(ISellingTransactionDal sellTransactionDal)
        {
            _sellTransactionDal = sellTransactionDal;
        }
        public void AddSellingTransaction(SellingTransaction entity)
        {
            _sellTransactionDal.Add(entity);

        }

        public void Delete(int id)
            
        {
            SellingTransaction sl= _sellTransactionDal.Get(p => p.Id == id);
            _sellTransactionDal.Delete(sl);
        }

        public SellingTransaction GetById(int id)
        {
            return _sellTransactionDal.Get(p=>p.Id==id);
        }

        public List<SellingTransaction> GetAll()
        {
            return _sellTransactionDal.GetList().ToList();
        }

        public void Update(int id,double quantity)
        {
            SellingTransaction sl= _sellTransactionDal.Get(p => p.Id == id);
            sl.Quantity = quantity;
            
            _sellTransactionDal.Update(sl);
        }
    }
}
