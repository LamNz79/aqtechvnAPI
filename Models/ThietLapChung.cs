using System;
using System.Collections.Generic;

namespace AQapiDev.Models;

public partial class ThietLapChung
{
    public long Id { get; set; }

    public int Stt { get; set; }

    public string TenWebsite { get; set; } = null!;

    public string TenWebsiteTa { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string TitleTa { get; set; } = null!;

    public string? HinhAnhLogo { get; set; }

    public string Favicon { get; set; } = null!;

    public string? NgonNgu { get; set; }

    public string? LinkFacebook { get; set; }

    public string? LinkYoutube { get; set; }

    public string? SoDienThoai { get; set; }

    public string? DiaChi { get; set; }

    public string? DiaChiTa { get; set; }

    public string? Email { get; set; }

    public string? Fax { get; set; }

    public string? DiaChi2 { get; set; }

    public string? DiaChi2Ta { get; set; }
}
