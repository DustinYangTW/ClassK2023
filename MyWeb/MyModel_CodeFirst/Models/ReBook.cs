using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyModel_CodeFirst.Models
{
    public class ReBook
    {
        [Key]
        public long KId { get; set; }
        [Display(Name = "內容")]
        [Required(ErrorMessage = "必填")]
        [DataType(DataType.MultilineText)] //可以變成多行文字方塊
        public string? Description { get; set; }

        [Display(Name = "留言人姓名")]
        [Required(ErrorMessage = "必填")]
        [StringLength(20, ErrorMessage = "姓名不可大於20個字")]
        public string? Author { get; set; }

        [Display(Name = "留言時間")]
        public DateTime TimeStamp { get; set; }

        //沒有這樣做會導致關聯拉不上

        [ForeignKey("Book")]
        [Required]
        public long GId { get; set; }
        public virtual Book? Book { get; set; }
    }
}
