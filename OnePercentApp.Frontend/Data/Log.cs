using System;
using System.Collections.Generic;

namespace OnePercentApp.Frontend.Data;

public partial class Log
{
    public int LogId { get; set; }

    public DateOnly LogDate { get; set; }

    public string LogTitle { get; set; } = null!;

    public string LogDescription { get; set; } = null!;

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
}
