using System;
using System.Collections.Generic;

namespace OnePercentApp.Frontend.Data;

public partial class UserAccount
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Password { get; set; }

    public string Role { get; set; } = null!;
}
