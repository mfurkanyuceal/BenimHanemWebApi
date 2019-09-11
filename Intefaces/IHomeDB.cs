using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Intefaces
{
    public interface IHomeDB
    {

        Task<MobileResult> GetAllHomeProducts(string id);
        Task<MobileResult> GetAllHomeUsers(string id);
        Task<HomeModel> GetHomeModelbyHomeName(string homename);
        Task<MobileResult> GetHomeModelbyLogin(string homename, string homepassword);
        Task<MobileResult> DeleteHomeModel(HomeModel homeModel);
        Task<MobileResult> UpdateHomeModel(HomeModel newModel);
        Task<MobileResult> AddHomeModel(HomeModel model);
        Task SaveAsync();

    }
}
