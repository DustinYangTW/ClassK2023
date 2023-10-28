using System.ComponentModel.DataAnnotations;

namespace MyModel_DBFirst.Models
{
    //5.2.2 在Models資料夾中新增Department Class，內容如下
    public class Department
    {
        [Key]
        [Display(Name = "科系代碼")]
        [Required(ErrorMessage = "必填")]
        [RegularExpression("[0-9]{2}")]
        public string DeptID { get; set; }

        [Display(Name = "科系名稱")]
        [Required(ErrorMessage = "必填")]
        [StringLength(30, ErrorMessage = "科系名稱最多30個字")]
        public string DeptName { get; set; }

        //1對多的關聯
        public List<tStudent> tStudents { get; set; }
    }
}
