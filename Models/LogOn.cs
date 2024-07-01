using System;
using System.Collections.Generic;

namespace AQapi.Models;

public partial class LogOn
{
    public long Id { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? RePass { get; set; }

    public bool? Active { get; set; }

    public string? VerificationCode { get; set; }
}
