using System;
using System.Collections.Generic;

namespace MyWebAPI.Models;

public partial class Book
{
    public long GId { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public byte[]? Photo { get; set; }

    public string? ImageType { get; set; }

    public string Author { get; set; } = null!;

    public DateTime TimeStamp { get; set; }

    public virtual ICollection<Department> Department { get; set; } = new List<Department>();
}
