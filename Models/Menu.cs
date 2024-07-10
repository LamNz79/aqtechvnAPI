using System;
using System.Collections.Generic;

namespace AQapi.Models;

public partial class Menu
{
    public long Id { get; set; }

    public int Stt { get; set; }

    public string TieuDe { get; set; } = null!;

    public string? TenMenu { get; set; }

    public string? TenMenuTa { get; set; }

    public bool? HienThi { get; set; }

    public string Link { get; set; } = null!;

    public long? IdCha { get; set; }

    public bool? IsAdmin { get; set; }

    public virtual Menu? IdChaNavigation { get; set; }

    public virtual ICollection<Menu> InverseIdChaNavigation { get; set; } = new List<Menu>();
}
