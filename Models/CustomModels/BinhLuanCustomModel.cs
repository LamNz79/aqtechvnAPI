namespace AQapi.Models.CustomModels
{
    public class BinhLuanCustomModel
    {
        public long Id { get; set; }
        public long? IdsanPham { get; set; }
        public string? TenDanhMuc { get; set; } = null!;
        public long? IdbaiViet { get; set; }
        public string? TieuDeBaiViet { get; set; } = null!;
        public long Iduser { get; set; }
        public string? Username { get; set; } = null!;

        public string NoiDung { get; set; } = null!;
        public string NoiDungTraLoi { get; set; } = null!;

        public DateTime NgayTraLoi { get; set; }

        public string UserTraLoi { get; set; } = null!;
    }
}