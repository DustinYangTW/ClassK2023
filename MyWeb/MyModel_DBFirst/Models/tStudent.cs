using System;
using System.Collections.Generic;

namespace MyModel_DBFirst.Models;

public partial class tStudent
{
    public string fStuId { get; set; } 

    public string fName { get; set; } 

    public string? fEmail { get; set; }

    public int? fScore { get; set; }
}
