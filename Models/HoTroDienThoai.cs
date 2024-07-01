using System;
using System.Collections.Generic;

namespace AQapi.Models;

public partial class HoTroDienThoai
{
    public long Id { get; set; }

    public int Stt { get; set; }

    public string Ten { get; set; } = null!;

    public string SoDienThoai { get; set; } = null!;

    public bool? IsHienThi { get; set; }
}
