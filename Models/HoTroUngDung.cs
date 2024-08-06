using System;
using System.Collections.Generic;

namespace AQapiDev.Models;

public partial class HoTroUngDung
{
    public long Id { get; set; }

    public int Stt { get; set; }

    public string LoaiUngDung { get; set; } = null!;

    public string Ten { get; set; } = null!;

    public string Code { get; set; } = null!;

    public bool? IsHienThi { get; set; }
}
