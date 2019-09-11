using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Database
{
    public class ProductDB:IProductDB
    {

        private readonly ApplicationContext _context;

        public ProductDB(ApplicationContext context)
        {
            _context = context;
        }
        





        public async Task<ProductModel> GetHomeProductModelbyId(string id)
        {
            try
            {
                ProductModel model = await _context.ProductModels.FindAsync(id);

                return model;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }



        public  async Task<MobileResult> DeleteHomeProductModel(ProductModel productModel)
        {
            var mobileResult = new MobileResult();

            try
            {

                 _context.ProductModels.Remove(productModel);

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

        public async Task<MobileResult> UpdateHomeProductModel(ProductModel newModel)
        {
            var mobileResult = new MobileResult();
            try
            {

                var model = await _context.ProductModels.FirstAsync(a => a.ProductID == newModel.ProductID);

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

        public async Task<MobileResult> AddHomeProductModel(ProductModel model)
        {

            var mobileResult = new MobileResult();
            try
            {
                await _context.ProductModels.AddAsync(model);
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


    }
}
