using System.ComponentModel.DataAnnotations;

//4.1.3 設計Login類別的各屬性，包括名稱、資料類型及其相關的驗證規則及顯示名稱(DisplayName)
namespace MyModel_CodeFirst.Models
{
    public class Login
    {
        [Key]
        [Display(Name = "帳號")]
        [Required(ErrorMessage = "請填寫帳號")]
        [StringLength(10, ErrorMessage = "帳號最多10碼")]
        [RegularExpression("[A-Za-z]{3,10}", ErrorMessage = "帳號格式錯誤")]
        public string Account { get; set; }


        [Display(Name = "密碼")]
        [Required(ErrorMessage = "請填寫密碼")]
        [DataType(DataType.Password)]
        [MinLength(4, ErrorMessage = "密碼最少4碼")]
        [MaxLength(12, ErrorMessage = "密碼最多12碼")]
        [StringLength(12)]
        public string Password { get; set; }
    }
}
