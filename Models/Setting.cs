using System;
using System.Collections.Generic;

namespace AQapiDev.Models;

public partial class Setting
{
    public long Id { get; set; }

    public string KyHieu { get; set; } = null!;

    public string TieuDe { get; set; } = null!;

    public string? TomTat { get; set; }

    public string? TieuDeTa { get; set; }

    public string? TomTatTa { get; set; }

    public bool? IsHienThi { get; set; }

    public int Stt { get; set; }

    public string? NoiDung { get; set; }

    public string? NoiDungTa { get; set; }
}
