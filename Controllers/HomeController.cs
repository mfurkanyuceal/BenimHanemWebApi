using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Database;
using WebApplication.Intefaces;
using WebApplication.Models;
using WebApplication.Security;

namespace WebApplication.Controllers
{
    [Route("homes/")]
    //[ApiController]
    public class HomeController : ControllerBase
    {

        private IHomeDB homeDB;

        public HomeController(ApplicationContext context)
        {
            homeDB = new HomeDB(context);
        }

        [HttpGet()]
        [Route("{homeid}/homeproducts")]
        public async Task<MobileResult> GetAllHomeProducts(string homeid)
        {

            var mobileResult = new MobileResult();

            try
            {
                mobileResult = await homeDB.GetAllHomeProducts(homeid);
            }
            catch (Exception e)
            {
                mobileResult.Data = null;
                mobileResult.Message = e.Message;
                mobileResult.Result = false;
            }
            return mobileResult;


        }

        [HttpGet()]
        [Route("{homeid}/homeusers")]
        public async  Task<MobileResult> GetAllHomeUsers(string homeid)
        {

            var mobileResult = new MobileResult();

            try
            {
                 mobileResult = await homeDB.GetAllHomeUsers(homeid);
            }
            catch (Exception e)
            {
                mobileResult.Data = null;
                mobileResult.Message = e.Message;
                mobileResult.Result = false;
            }
            return mobileResult;
        }



        [HttpPost]
        [Route("delete")]
        public async Task<MobileResult> DeleteHomeModel([FromBody]HomeModel homeModel )
        {

            var mobileResult = new MobileResult();

            try
            {

               mobileResult = await homeDB.DeleteHomeModel(homeModel);

            }
            catch (Exception e)
            {
                mobileResult.Data = null;
                mobileResult.Message = e.Message;
                mobileResult.Result = false;
            }
            return mobileResult;
        }


        [HttpGet]
        [Route("gethomebylogin")]
        public async Task<MobileResult> GetHomeModelbyLogin(string homename, string password)
        {
            var mobileResult = new MobileResult();

            try
            {
                mobileResult = await homeDB.GetHomeModelbyLogin(homename, password);

            }
            catch (Exception e)
            {
                mobileResult.Data = null;
                mobileResult.Message = e.Message;
                mobileResult.Result = false;
            }
            return mobileResult;

        }

        [HttpPost]
        [Route("update")]
        public async Task<MobileResult> UpdateHomeModel([FromBody]HomeModel newModel)
        {
            var mobileResult = new MobileResult();

            try
            {
                mobileResult = await homeDB.UpdateHomeModel(newModel);
            }
            catch (Exception e)
            {
                mobileResult.Data = null;
                mobileResult.Message = e.Message;
                mobileResult.Result = false;
            }
            return mobileResult;

        }

        [HttpPost]
        [Route("insert")]
        public async Task<MobileResult> AddHomeModel([FromBody]HomeModel homeModel)
        {


            var mobileResult = new MobileResult();

            mobileResult.Result = false;
            mobileResult.Message = "İStediğim Yer";
            return mobileResult;

            if (ModelState.IsValid)
            {
                try
                {
                    mobileResult = await homeDB.AddHomeModel(homeModel);
                }
                catch (Exception e)
                {
                    mobileResult.Result = false;
                    mobileResult.Message = e.Message;
                    mobileResult.Data = null;
                    
                }

            }
            else
            {
                var errors = "";
                foreach (var error in ModelState.Values)
                    errors += " " + error.Errors.First().ErrorMessage.ToString();
                mobileResult.Message = errors;
                mobileResult.Result = false;
                mobileResult.Data = null;
            }

            return mobileResult;


        }



    }
}