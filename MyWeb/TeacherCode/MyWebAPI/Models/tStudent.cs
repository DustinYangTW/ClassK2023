using System;
using System.Collections.Generic;

namespace MyWebAPI.Models;

public partial class tStudent
{
    public string fStuId { get; set; } = null!;

    public string fName { get; set; } = null!;

    public string? fEmail { get; set; }

    public int? fScore { get; set; }

    public string DeptID { get; set; } = null!;

    public virtual Department Dept { get; set; } = null!;
}
