using Business.Dtos.requests.userRequests;
using Business.Dtos.responses.userResponses;

namespace Business.Abstracts
{
    public interface IUserService 
    {
        List<GetAllUserResponse> GetAll();
        void AddUser(CreateUserRequest request);
        GetUserByIdResponse GetById(int id);
        void update(UpdateUserRequest updateUserRequest);
        void delete(DeleteUserRequest deleteUserRequest);
    }
}
