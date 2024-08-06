using System;
using System.Collections.Generic;

namespace AQapiDev.Models;

public partial class Banner
{
    public long Id { get; set; }

    public int Stt { get; set; }

    public string TieuDe { get; set; } = null!;

    public string? TomTat { get; set; }

    public string? NoiDung { get; set; }

    public string? TieuDeTa { get; set; }

    public string? TomTatTa { get; set; }

    public string? NoiDungTa { get; set; }

    public string HinhAnh { get; set; } = null!;

    public string HinhAnhCon { get; set; } = null!;

    public string Link { get; set; } = null!;
}
