using System;
using System.Collections.Generic;

namespace AQapi.Models;

public partial class DoiTac
{
    public long Id { get; set; }

    public int? Stt { get; set; }

    public string TieuDe { get; set; } = null!;

    public string? TomTat { get; set; }

    public string NoiDung { get; set; } = null!;

    public string HinhAnh { get; set; } = null!;

    public string? Link { get; set; }

    public bool? IsType { get; set; }

    public bool? IsHienThi { get; set; }

    public string? EmailNhanTin { get; set; }
}
