using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Database;
using WebApplication.Intefaces;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [Route("homes/{homeID}/homeusers")]
    //[ApiController]
    public class UserController : ControllerBase
    {

        private  IUserDB userDB;


        public UserController(ApplicationContext context)
        {
            userDB = new UserDB(context);
        }

        [HttpGet]
        [Route("getuserbylogin")]
        public async Task<MobileResult> GetUserModelbyLogin(string username,string password)
        {
            return await userDB.GetUserModelbyLogin(username,password);         
        }


        [HttpPost]
        [Route("delete")]
        public async  Task<MobileResult> DeleteUserModel([FromBody] UserModel userModel)
        {
            var result = await userDB.DeleteUserModel(userModel);


            return result;
        }

        [HttpPost]
        [Route("update")]
        public async Task<MobileResult> UpdateUserModel([FromBody]UserModel newUserModel)
        {

            MobileResult mobileResult = new MobileResult();
            if (ModelState.IsValid)
            {

                mobileResult = await userDB.UpdateUserModel(newUserModel);
            }
            else
            {
                var errors = "";
                foreach (var error in ModelState.Values)
                    errors += " " + error.Errors.First().ErrorMessage.ToString();
                mobileResult.Message = errors;
                mobileResult.Result = false;
            }

            return mobileResult;

        }


        [HttpPost]
        [Route("insert")]
        public async  Task<MobileResult>  AddUserModel([FromBody]UserModel userModel)
        {

            MobileResult mobileResult = new MobileResult();
            if (ModelState.IsValid)
            {

                mobileResult= await userDB.AddUserModel(userModel);
            }
            else
            {
                var errors = "";
                foreach (var error in ModelState.Values)
                    errors += " " + error.Errors.First().ErrorMessage.ToString();
                mobileResult.Message = errors;
                mobileResult.Result = false;
            }

            return mobileResult;
        }


    }
}