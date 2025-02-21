using System;
using System.Collections.Generic;

namespace OnePercentApp.Frontend.Data;

public partial class Category
{
    public int CategoryId { get; set; }

    public string CategoryTitle { get; set; } = null!;

    public string CategoryDescription { get; set; } = null!;

    public virtual ICollection<Log> Logs { get; set; } = new List<Log>();
}
