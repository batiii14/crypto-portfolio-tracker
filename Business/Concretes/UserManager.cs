using Business.Abstracts;
using Business.Dtos.requests.userRequests;
using Business.Dtos.responses.userResponses;
using Business.Dtos.responses.walletResponses;
using DataAccess.Abstracts;
using Entities.concretes;

namespace Business.Concretes
{
    public class UserManager : IUserService
    {
       private IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void AddUser(CreateUserRequest request)
        {
            User user = new User
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Password = request.Password,
                UserName = request.UserName,

                
            };
            _userDal.Add(user);

        }

        public void delete(DeleteUserRequest deleteUserRequest)
        {
            User user = _userDal.Get(p => p.UserId == deleteUserRequest.UserId);
            _userDal.Delete(user);
        }

        public List<GetAllUserResponse> GetAll()
        {
            List<User> users= _userDal.GetAllWithWallet().ToList();
            
            GetWalletWithUserResponse getWalletWithUserResponse=new GetWalletWithUserResponse();
            
            List<GetAllUserResponse> getAllUserResponses = new List<GetAllUserResponse>();
            foreach (User user in users)
            {
                
                GetAllUserResponse getAllUserResponse = new GetAllUserResponse();
                getAllUserResponse.UserId = user.UserId;
                getAllUserResponse.Email = user.Email;
                getAllUserResponse.FirstName = user.FirstName;
                getAllUserResponse.LastName = user.LastName;
                getAllUserResponse.UserName= user.UserName;
                getAllUserResponse.Password= user.Password;
                if (user.Wallet != null)
                {
                    getWalletWithUserResponse.WalletId = user.Wallet.WalletId;
                    getWalletWithUserResponse.UserId = user.UserId;
                    getWalletWithUserResponse.CoinList = user.Wallet.CoinList;
                    getAllUserResponse.Wallet = getWalletWithUserResponse;

                }
                else
                {
                    getAllUserResponse.Wallet = null;

                }

                getAllUserResponses.Add(getAllUserResponse);

            }

            return  getAllUserResponses;
        }

        public GetUserByIdResponse GetById(int id)
        {
            User user = _userDal.GetWithWallet(id);
            GetUserByIdResponse getUserByIdResponse = new GetUserByIdResponse
            {
                UserId = user.UserId,
                UserLastName = user.LastName,
                UserName = user.UserName,
                Wallet=user.Wallet
                

            };

            return getUserByIdResponse;
        }

        public void update(UpdateUserRequest updateUserRequest)
        {
            User user = _userDal.Get(p => p.UserId == updateUserRequest.UserId);
            user.UserName = updateUserRequest.UserName;
            _userDal.Update(user);
        }
    }
}
