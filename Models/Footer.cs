using System;
using System.Collections.Generic;

namespace AQapi.Models;

public partial class Footer
{
    public long Id { get; set; }

    public int Stt { get; set; }

    public int Groups { get; set; }

    public string? NoiDung { get; set; }

    public string? NoiDungTa { get; set; }

    public string? Link { get; set; }

    public string? HinhAnh { get; set; }

    public bool? HienThi { get; set; }

    public string? Email { get; set; }
}
