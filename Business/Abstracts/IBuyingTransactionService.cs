using Entities.concretes;

namespace Business.Abstracts
{
    public interface IBuyingTransactionService
    {
        List<BuyingTransaction> GetAll();
        void AddBuyingTransaction(BuyingTransaction buyingTransaction);
        BuyingTransaction GetById(int id);
        void Update(int id, double quantity);
        void Delete(int id);
        List<BuyingTransaction> GetAllForSpecificUser(int id);
    }
}
