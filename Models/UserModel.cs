using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication.Models
{
    public class UserModel
    {
        [Key]
        public string UserID { get; set; }
        [Required(ErrorMessage = "Kullanıcı adı boş olamaz")]
        [MinLength(5,ErrorMessage = "Kullanıcı adı en az 5 harfli olabilir.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Kullanıcı parolası boş olamaz")]
        public string UserPassword { get; set; }
        [Required(ErrorMessage ="Kullanıcı tam adı boş olamaz")]
        public string UserFullName { get; set; }
        public string UserPhotoURL { get; set; }

        //ForeignKey
        public string UserHomeRefID { get; set; }
        [ForeignKey("UserHomeRefID")]
        public HomeModel UserHomeModel { get; set; }

    }
}
