using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyModel_DBFirst.Models;

public partial class tStudent
{
    [Display(Name ="學號")]
    [Key]
    [Required(ErrorMessage ="必填")]
    [RegularExpression("112[0-9]{3}",ErrorMessage ="學號格式錯誤")]
    public string fStuId { get; set; }

    [Display(Name = "學生姓名")]
    [Required(ErrorMessage = "必填")]
    [StringLength(30,ErrorMessage ="最多30個字")]
    public string fName { get; set; }

    [Display(Name = "E-Mail")]
    [EmailAddress(ErrorMessage = "E-Mail格式錯誤")]
    public string? fEmail { get; set; }

    [Display(Name = "成績")]
    [Range(0,100,ErrorMessage ="請填0~100的數字")]
    public int? fScore { get; set; }


    //5.1.2 在tStudent Class中增加一個屬性 public string DeptID { get; set; }
    [Display(Name = "科系")]
    //5.2.3 修改tStudent Class以建立與Department的關聯，內容如下
    [ForeignKey("Department")]   //把DeptID建立成Foreign Key
    public string DeptID { get; set; }


    //建立與Department的關聯
    public virtual Department Department { get; set; }
}
