using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class HomeModel
    {

        [Key]
        public string HomeID { get; set; }
        [Required(ErrorMessage ="Hane ismi boş olamaz")]
        [MinLength(4,ErrorMessage ="Hane ismi 4 karakterden küçük olamaz!")]
        public string HomeName { get; set; }

        [Required(ErrorMessage = "Hane parolası boş olamaz")]
        public string HomePassword { get; set; }
        public string HomeAddress { get; set; }
        public ICollection<ProductModel> shoppingList { get; set; }
        public ICollection<UserModel> userList { get; set; }

    }
}
