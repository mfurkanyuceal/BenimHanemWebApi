using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Intefaces;
using WebApplication.Models;
using WebApplication.Security;

namespace WebApplication.Database
{
    public class HomeDB:IHomeDB
    {

        private readonly ApplicationContext _context;

        public HomeDB(ApplicationContext context)
        {
            _context = context;

        }



        public async Task<MobileResult> GetAllHomeProducts(string id)
        {
            var mobileResult = new MobileResult();
            try
            {

                var homeProducts = await _context.ProductModels.Where<ProductModel>(u => u.ProductHomeRefID == id).ToListAsync();

                mobileResult.Data = homeProducts;
                mobileResult.Message = "Başarılı";
                mobileResult.Result = true;
            }
            catch (Exception e)
            {
                mobileResult.Data = null;
                mobileResult.Message = e.Message;
                mobileResult.Result = false;
            }

            return mobileResult;

        }

        public async Task<MobileResult> GetAllHomeUsers(string id)
        {
            var mobileResult = new MobileResult();

            try
            {

                var userList = await _context.UserModels.Where<UserModel>(u => u.UserHomeRefID == id).ToListAsync();

                mobileResult.Data = userList;
                mobileResult.Message = "Başarılı";
                mobileResult.Result = true;

            }
            catch (Exception e)
            {
                mobileResult.Data = null;
                mobileResult.Message = e.Message;
                mobileResult.Result = false;
            }

            return mobileResult;
        }



        public async Task<HomeModel> GetHomeModelbyHomeName(string homename)
        {
 
            var homeModel = await _context.HomeModels.FirstOrDefaultAsync<HomeModel>(home => (home.HomeName.Trim().ToLower() == homename.Trim().ToLower()));

            return homeModel;
        }


        public async  Task<MobileResult> DeleteHomeModel(HomeModel homeModel)
        {
            var mobileResult = new MobileResult();

            try
            {
                 _context.HomeModels.Remove(homeModel);

                await SaveAsync();
                mobileResult.Message = "Başarılı";
                mobileResult.Result = true;

            }
            catch (Exception e)
            {
                mobileResult.Data = null;
                mobileResult.Message = e.Message;
                mobileResult.Result = false;
            }

            return mobileResult;
        }

        public async Task<MobileResult> UpdateHomeModel(HomeModel newModel)
        {

            var mobileResult = new MobileResult();

            try
            {

                var model = await _context.HomeModels.FirstAsync(a => a.HomeID == newModel.HomeID);


                mySecurity locker = new mySecurity();
                string salt = locker.HashCreate();
                string encryptKey = locker.HashCreate(newModel.HomePassword, salt);

                newModel.HomePassword = encryptKey;

                model = newModel;

                await SaveAsync();

                mobileResult.Data = null;
                mobileResult.Message = "Başarılı";
                mobileResult.Result = true;

            }
            catch (Exception e)
            {
                mobileResult.Data = null;
                mobileResult.Message = e.Message;
                mobileResult.Result = false;
            }

            return mobileResult;

        }


        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }




        public async Task<MobileResult> AddHomeModel(HomeModel model)
        {

            var mobileResult = new MobileResult();

            try
            {
                
                mySecurity locker = new mySecurity();
                string salt = locker.HashCreate();
                string encryptKey = locker.HashCreate(model.HomePassword, salt);

                model.HomePassword = encryptKey;

                await _context.HomeModels.AddAsync(model);
                await SaveAsync();

                mobileResult.Data = null;
                mobileResult.Message = "Başarılı";
                mobileResult.Result = true;

            }
            catch (Exception e)
            {
                mobileResult.Data = null;
                mobileResult.Message = e.Message;
                mobileResult.Result = false;
            }

            return mobileResult;
        }



        public async Task<MobileResult> GetHomeModelbyLogin(string homename, string homepassword)
        {
            var mobileResult = new MobileResult();
            try
            {
                var homeModel = await GetHomeModelbyHomeName(homename);


                mySecurity locker = new mySecurity();
                string getEncryptKey = homepassword.Split('æ')[0];
                string getSalt = homepassword.Split('æ')[1];

                var result = locker.ValidateHash(homeModel.HomePassword, getSalt, getEncryptKey);

                if (result)
                {
                    mobileResult.Message = "Başarılı";
                    mobileResult.Result = true;
                    mobileResult.Data = homeModel;
                }
                else
                {
                    mobileResult.Message = "Parola Hatalı";
                    mobileResult.Result = false;
                    mobileResult.Data = null;
                }

            }
            catch (Exception e)
            {
                mobileResult.Message = e.Message;
                mobileResult.Result = false;
                mobileResult.Data = null;
            }

            return mobileResult;

        }




    }

}

