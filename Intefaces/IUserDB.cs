using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Intefaces
{
    public interface IUserDB
    {

        Task<List<UserModel>> GetHomeUserModels(string id);
        Task<MobileResult> GetUserModelbyLogin(string username, string password);
        Task<UserModel> GetHomeUserModelbyUserName(string username);
        Task<MobileResult> DeleteUserModel(UserModel userModel);
        Task<MobileResult> UpdateUserModel(UserModel newModel);
        Task SaveAsync();
        Task<bool> isExistUsername(string username);
        Task<MobileResult> AddUserModel(UserModel model);

    }
}
