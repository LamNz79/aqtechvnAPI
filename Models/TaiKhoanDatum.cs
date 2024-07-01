using System;
using System.Collections.Generic;

namespace AQapi.Models;

public partial class TaiKhoanDatum
{
    public long Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string HoTen { get; set; } = null!;

    public bool GioiTinh { get; set; }

    public string? DiaChi { get; set; }

    public string? SoDienThoai { get; set; }

    public string? Email { get; set; }

    public bool IsAdmin { get; set; }
}
