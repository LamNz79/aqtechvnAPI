using System;
using System.Collections.Generic;

namespace AQapiDev.Models;

public partial class YkienDanhGium
{
    public long Id { get; set; }

    public string? HoTen { get; set; }

    public string? ChucVu { get; set; }

    public int? MucDanhGia { get; set; }

    public string? NoiDung { get; set; }

    public DateTime? Ngay { get; set; }

    public bool? IsHienThiTrangChu { get; set; }

    public string? DonVi { get; set; }

    public string? TomTat { get; set; }

    public string? TomTatTa { get; set; }

    public string? NoiDungTa { get; set; }
}
