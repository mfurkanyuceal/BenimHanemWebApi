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
    public class UserDB:IUserDB
    {

        private readonly ApplicationContext _context;

        public UserDB(ApplicationContext context)
        {
            _context = context;
        }


        public async Task<bool> isExistUsername(string username)
        {
            var user = await _context.UserModels.FirstOrDefaultAsync<UserModel>(u => u.UserName == username);
            if (user!=null)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }



        public async Task<UserModel> GetHomeUserModelbyUserName(string username)
        {

            UserModel user = await _context.UserModels.FirstOrDefaultAsync<UserModel>(u => u.UserName == username);

            return user;


        }


        public async Task<MobileResult> DeleteUserModel(UserModel userModel)
        {
            var mobileResult = new MobileResult();
            try
            {
                 _context.UserModels.Remove(userModel);
                await SaveAsync();

                mobileResult.Message = "Başarılı";
                mobileResult.Result = true;

            }
            catch (Exception e)
            {
                mobileResult.Message =e.Message;
                mobileResult.Result = false;
            }

            return mobileResult;
        }

        public async Task<MobileResult> UpdateUserModel(UserModel newModel)
        {

            var mobileResult = new MobileResult();

            try
            {

                UserModel model = await _context.UserModels.FindAsync(newModel.UserID);

                if (model.UserName==newModel.UserName)
                {
                    model = newModel;

                    mySecurity locker = new mySecurity();
                    string salt = locker.HashCreate();
                    string encryptKey = locker.HashCreate(model.UserPassword, salt);

                    model.UserPassword = encryptKey;

                    await SaveAsync();

                    mobileResult.Data = null;
                    mobileResult.Result = true;
                    mobileResult.Message = "Başarılı";

                    return mobileResult;
                }
                else
                {
                    if (await isExistUsername(newModel.UserName))
                    {
                        mobileResult.Data = null;
                        mobileResult.Result = false;
                        mobileResult.Message = "Aynı kullanıcı adı mevcut";
                        return mobileResult;
                    }
                    else
                    {
                        model = newModel;

                        mySecurity locker = new mySecurity();
                        string salt = locker.HashCreate();
                        string encryptKey = locker.HashCreate(model.UserPassword, salt);

                        model.UserPassword = encryptKey;

                        await SaveAsync();

                        mobileResult.Data = null;
                        mobileResult.Result = true;
                        mobileResult.Message = "Başarılı";

                        return mobileResult;

                    }
                }


            }
            catch (Exception e)
            {
                mobileResult.Data = null;
                mobileResult.Result = false;
                mobileResult.Message = e.Message;
                return mobileResult;
            }



        }

        public async Task SaveAsync (){

            await _context.SaveChangesAsync();

        }


        public async Task<MobileResult> GetUserModelbyLogin(string username, string password)
        {
            var mobileResult = new MobileResult();
            try
            {
                var user = await GetHomeUserModelbyUserName(username);


                mySecurity locker = new mySecurity();
                string getEncryptKey = user.UserPassword.Split('æ')[0];
                string getSalt = user.UserPassword.Split('æ')[1];

                var result = locker.ValidateHash(password, getSalt, getEncryptKey);

                if (result)
                {
                    mobileResult.Message = "Başarılı";
                    mobileResult.Result = true;
                    mobileResult.Data = user;
                }
                else
                {
                    mobileResult.Message = "Parola Hatalı";
                    mobileResult.Result = false;
                    mobileResult.Data = null;
                }

            } catch (Exception e)
            {
                mobileResult.Message = e.Message;
                mobileResult.Result = false;
                mobileResult.Data = null;
            }

            return mobileResult;

        }

        public async Task<MobileResult> AddUserModel(UserModel userModel)
        {
            MobileResult result = new MobileResult();

            if (await isExistUsername(userModel.UserName))
            {
                result.Result = false;
                result.Message = "Böyle bir kullanıcı adı mevcut";
                return result;
            }
            else
            {
                await _context.UserModels.AddAsync(userModel);
                await SaveAsync();
                result.Result = true;
                result.Message = "Başarılı";
                return result;
            }
        }

    }
}
