using Microsoft.AspNetCore.Mvc;
using System;
using WebApplication.Database;
using WebApplication.Models;
using WebApplication.Intefaces;
using System.Threading.Tasks;
using System.Linq;

namespace WebApplication.Controllers
{
    [Route("homes/{homeid}/homeproducts")]
    //[ApiController]
    public class HomeProductController : ControllerBase
    {


        private  IProductDB productDB;


        public HomeProductController(ApplicationContext context)
        {
            productDB = new ProductDB(context);
        }

        [HttpPost]
        [Route("delete")]
        public async Task<MobileResult> DeleteHomeProductModel([FromBody]ProductModel productModel)
        {
            var mobileResult = await productDB.DeleteHomeProductModel(productModel);


            return mobileResult;
        }


        [HttpPost]
        [Route("update")]
        public async Task<MobileResult> UpdateHomeProductModel([FromBody]ProductModel productModel)
        {
            var mobileResult = new MobileResult();
            if (ModelState.IsValid)
            {

                mobileResult = await productDB.UpdateHomeProductModel(productModel);
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
        public async Task<MobileResult> AddHomeProductModel([FromBody]ProductModel productModel)
        {
            MobileResult result = new MobileResult();
            if (ModelState.IsValid)
            {
                try
                {
                    result.Result = true;
                    await productDB.AddHomeProductModel(productModel);
                    result.Message = "Success";
                }
                catch (Exception ex)
                {
                    result.Result = false;
                    result.Message = ex.Message;
                }
            }
            else
            {
                var errors = "";
                foreach (var error in ModelState.Values)
                    errors += " " + error.Errors.First().ErrorMessage.ToString();
                result.Message = errors;
                result.Result = false;
            }

            return result;


        }



    }
}