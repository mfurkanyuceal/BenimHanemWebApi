using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication
{
    public interface IProductDB
    {


        Task<ProductModel> GetHomeProductModelbyId(string id);


        Task<MobileResult> DeleteHomeProductModel( ProductModel productModel);


        Task<MobileResult> UpdateHomeProductModel(ProductModel newModel);


        Task<MobileResult> AddHomeProductModel(ProductModel model);

        Task SaveAsnyc();



    }
}
