using Entities.concretes;

namespace Business.Dtos.responses.userResponses
{
    public class GetUserByIdResponse
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserLastName { get; set; }
        public Wallet Wallet { get; set; }

    }
}
