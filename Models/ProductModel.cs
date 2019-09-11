using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication.Models
{
    public class ProductModel
    {


        [Key]
        public string ProductID { get; set; }
        [Required(ErrorMessage ="Ürün adı boş olamaz")]
        [MinLength(3,ErrorMessage ="En az {1} karakter olmalıdır.")]
        public string ProductName { get; set; }
        public string ProductFromWhere { get; set; }

        [Required(ErrorMessage = "Ürün miktarı boş olamaz")]
        public int ProductAmount { get; set; }
        [Required(ErrorMessage = "Ürün ölçü birimi boş olamaz")]
        public string ProductAmountType { get; set; }
        public int ProductPrice { get; set; }

        public string addedByUserName { get; set; }
        public string deletedByUserName { get; set; }
        public string updatedByUserName { get; set; }
        public string takenByUserName { get; set; }


        public bool isDeleted { get; set; }
        public bool isTaken { get; set; }
        public bool isUpdated { get; set; }


        //ForeignKey
        public string ProductHomeRefID { get; set; }
        [ForeignKey("ProductHomeRefID")]
        public HomeModel ProductHomeModel { get; set; }

    }
}
