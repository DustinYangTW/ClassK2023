using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MyModel_CodeFirst.Models
{
    public class Book
    {
        //1.1.4 設計ReBook類別的各屬性，包括名稱、資料類型及其相關的驗證規則及顯示名稱(DisplayName)
        [Key]
        public long GId { get; set; }

        [Display(Name = "主旨")]
        [Required(ErrorMessage = "必填")]
        [StringLength(30, ErrorMessage = "主旨不可大於30個字")]
        public string Title { get; set; }

        [Display(Name = "內容")]
        [Required(ErrorMessage = "必填")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "圖片")]
        public byte[] Photo { get; set; }

        [StringLength(10)]
        [HiddenInput]
        public string ImageType { get; set; }

        [Display(Name = "留言人姓名")]
        [Required(ErrorMessage = "必填")]
        [StringLength(20, ErrorMessage = "姓名不可大於20個字")]
        public string Author { get; set; }

        //3.2.4 在Book.cs與ReBook.cs的Model中加入TimeStamp的顯示格式
        [Display(Name = "留言時間")]
        [DisplayFormat(DataFormatString ="{0:yyyy/MM/dd hh:mm}")]
        public DateTime TimeStamp { get; set; }

        //1.1.5 撰寫兩個類別間的關聯屬性做為未來資料表之間的關聯
        public List<ReBook> ReBooks { get; set; }
    }
}
