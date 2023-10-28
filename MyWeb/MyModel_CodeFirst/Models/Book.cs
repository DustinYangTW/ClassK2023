using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MyModel_CodeFirst.Models
{
    public class Book
    {
        [Key]
        public long GId { get; set; }
        [Display(Name ="主旨")]
        [Required(ErrorMessage ="必填")]
        [StringLength(30,ErrorMessage ="主旨不可大於30字")]
        public string? Title { get; set; }
        [Display(Name = "內容")]
        [Required(ErrorMessage = "必填")]
        [DataType(DataType.MultilineText)] //可以變成多行文字方塊
        public string? Description { get; set; }
        [Display(Name = "圖片")]
        public byte[]? Photo { get; set; }
        //存放照片Type
        [Display(Name = "照片類型")]
        [StringLength(10, ErrorMessage = "照片類型錯誤")]
        [HiddenInput] //表單是隱藏欄位
        public string? ImageType { get; set; }

        [Display(Name = "留言人姓名")]
        [Required(ErrorMessage = "必填")]
        [StringLength(20, ErrorMessage = "姓名不可大於20個字")]
        public string? Author { get; set; }

        [Display(Name = "留言時間")]
        public DateTime TimeStamp { get; set; }

        public List<ReBook>? ReBooks { get; set;}
    }
}
