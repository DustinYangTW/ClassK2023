using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyModel_CodeFirst.Models
{
    public class ReBook
    {
        //1.1.4 設計ReBook類別的各屬性，包括名稱、資料類型及其相關的驗證規則及顯示名稱(DisplayName)
        [Key]
        public long RId { get; set; }

        [Display(Name = "回覆內容")]
        [Required(ErrorMessage = "必填")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "回覆人姓名")]
        [Required(ErrorMessage = "必填")]
        [StringLength(10, ErrorMessage = "姓名不可大於10個字")]
        public string Author { get; set; }

        //3.2.4 在Book.cs與ReBook.cs的Model中加入TimeStamp的顯示格式
        [Display(Name = "留言時間")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm}")]
        public DateTime TimeStamp { get; set; }

        //1.1.5 撰寫兩個類別間的關聯屬性做為未來資料表之間的關聯
        [ForeignKey("Book")]
        [Required]
        public long GId { get; set; }

        public virtual Book Book { get; set; }
    }
}
