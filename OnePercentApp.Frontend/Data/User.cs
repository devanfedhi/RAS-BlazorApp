using System;
using System.Collections.Generic;

namespace OnePercentApp.Frontend.Data;

public partial class User
{
    public int UserId { get; set; }

    public string UserEmail { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string UserPassword { get; set; } = null!;

    public int RoleId { get; set; }

    public virtual ICollection<Log> Logs { get; set; } = new List<Log>();

    public virtual Role Role { get; set; } = null!;
}
