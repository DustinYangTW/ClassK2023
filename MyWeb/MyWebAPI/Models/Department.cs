using System;
using System.Collections.Generic;

namespace MyWebAPI.Models;

public partial class Department
{
    public long KId { get; set; }

    public string Description { get; set; } = null!;

    public string Author { get; set; } = null!;

    public DateTime TimeStamp { get; set; }

    public long GId { get; set; }

    public virtual Book GIdNavigation { get; set; } = null!;
}
