using System;
using System.Collections.Generic;

namespace MyWebAPI.Models;

public partial class Department
{
    public string DeptID { get; set; } = null!;

    public string DeptName { get; set; } = null!;

    public virtual ICollection<tStudent> tStudent { get; set; } = new List<tStudent>();
}
