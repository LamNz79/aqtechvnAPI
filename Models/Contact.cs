using System;
using System.Collections.Generic;

namespace AQapi.Models;

public partial class Contact
{
    public long Id { get; set; }

    public string HoTenNguoiGui { get; set; } = null!;

    public int? GioiTinh { get; set; }

    public string? SoDienThoai { get; set; }

    public string? Email { get; set; }

    public string? DonViCongTac { get; set; }

    public string? NoiDung { get; set; }

    public DateTime? NgayGui { get; set; }
}
