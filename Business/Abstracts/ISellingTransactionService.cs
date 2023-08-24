using Business.Dtos.requests.userRequests;
using Business.Dtos.responses.userResponses;
using Entities.concretes;

namespace Business.Abstracts
{
    public interface ISellingTransactionService 
    {
        List<SellingTransaction> GetAll();
        void AddSellingTransaction(SellingTransaction sellingTransaction);
        SellingTransaction GetById(int id);
        void Update(int id,double quantity );
        void Delete(int id);
    }
}
