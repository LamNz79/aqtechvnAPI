using System;
using System.Collections.Generic;

namespace AQapiDev.Models;

public partial class Header
{
    public long Id { get; set; }

    public int Stt { get; set; }

    public string? DanhMucCha { get; set; }

    public string? DanhMuc { get; set; }

    public string? DanhMucChaTa { get; set; }

    public string? DanhMucTa { get; set; }

    public string? Link { get; set; }

    public bool? IsHienThi { get; set; }
}
