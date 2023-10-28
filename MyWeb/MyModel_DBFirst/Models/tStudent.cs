using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyModel_DBFirst.Models;

public partial class tStudent
{
    [Display(Name ="學號")]
    [Key]
    [Required(ErrorMessage ="必填")]
    [RegularExpression("112[0-9][3]",ErrorMessage ="學號格式不正確")]
    public string fStuId { get; set; }

    [Display(Name = "學生姓名")]
    [Required(ErrorMessage = "必填")]
    [StringLength(30,ErrorMessage ="最多30個字")]
    public string fName { get; set; }

    [Display(Name = "E-Mail")]
    [EmailAddress(ErrorMessage ="E-Mail格式錯誤")]
    public string fEmail { get; set; }

    [Display(Name = "成績")]
    [Range(0,100,ErrorMessage ="請填0~100的數字")]
    public int? fScore { get; set; }
}
