namespace AQapi.Models;

public partial class Menu
{
    public long Id { get; set; }

    public int Stt { get; set; }

    public string TieuDe { get; set; } = null!;

    public string? TenMenu { get; set; }

    public string? TenMenuTa { get; set; }

    public bool? HienThi { get; set; }

    public string Link { get; set; } = null!;

    public long? IdCha { get; set; }

    public bool? IsAdmin { get; set; }


}
