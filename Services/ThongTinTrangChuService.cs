using AQapi.Models;
namespace AQapi.Services
{
    public interface IThongTinTrangChuService
    {
        List<ThongTinTrangChu> QueryThongTinTCAdmin(MyDBContext context, string kyHieu);
        List<ThongTinTrangChu> QueryThongTinTC(MyDBContext context, string kyHieu);
    }
    public class ThongTinTrangChuService : IThongTinTrangChuService
    {

        public List<ThongTinTrangChu> QueryThongTinTCAdmin(MyDBContext context, string kyHieu)
        {
            List<ThongTinTrangChu> resultList = new List<ThongTinTrangChu>();
            List<ThongTinTrangChu> query = new List<ThongTinTrangChu>();
            query = (from tl in context.ThongTinTrangChus
                     where tl.KyHieu.Contains(kyHieu)
                     select new ThongTinTrangChu
                     {
                         Id = tl.Id,
                         Stt = tl.Stt,
                         TieuDe = tl.TieuDe,
                         KyHieu = tl.KyHieu,
                         TomTat = tl.TomTat,
                         NoiDung = tl.NoiDung,
                         TieuDeTa = tl.TieuDeTa,
                         TomTatTa = tl.TomTatTa,
                         NoiDungTa = tl.NoiDungTa,
                         IsHienThi = tl.IsHienThi,
                         HinhAnh = tl.HinhAnh,
                         MacDinh = tl.MacDinh,
                         Ma = tl.Ma,
                         IsHienThiTrangChu = tl.IsHienThiTrangChu,
                         Link = tl.Link,
                         Nhom = tl.Nhom
                     }).OrderBy(f => f.Stt)
                            .ToList();
            resultList = (List<ThongTinTrangChu>)query.Select(item => new ThongTinTrangChu
            {
                Id = item.Id,
                Stt = item.Stt,
                TieuDe = item.TieuDe,
                KyHieu = item.KyHieu,
                TomTat = item.TomTat,
                NoiDung = item.NoiDung,
                TieuDeTa = item.TieuDeTa,
                TomTatTa = item.TomTatTa,
                NoiDungTa = item.NoiDungTa,
                IsHienThi = item.IsHienThi,
                HinhAnh = item.HinhAnh,
                MacDinh = item.MacDinh,
                Ma = item.Ma,
                IsHienThiTrangChu = item.IsHienThiTrangChu,
                Link = item.Link,
                Nhom = item.Nhom
            }).OrderBy(f => f.Stt)
                        .ToList();
            return resultList;
        }


        public List<ThongTinTrangChu> QueryThongTinTC(MyDBContext context, string kyHieu)
        {
            List<ThongTinTrangChu> resultList = new List<ThongTinTrangChu>();
            List<ThongTinTrangChu> query = new List<ThongTinTrangChu>();
            query = (from tl in context.ThongTinTrangChus
                     where tl.KyHieu.Contains(kyHieu) && tl.IsHienThi == true
                     select new ThongTinTrangChu
                     {
                         Id = tl.Id,
                         Stt = tl.Stt,
                         TieuDe = tl.TieuDe,
                         KyHieu = tl.KyHieu,
                         TomTat = tl.TomTat,
                         NoiDung = tl.NoiDung,
                         TieuDeTa = tl.TieuDeTa,
                         TomTatTa = tl.TomTatTa,
                         NoiDungTa = tl.NoiDungTa,
                         IsHienThi = tl.IsHienThi,
                         HinhAnh = tl.HinhAnh,
                         MacDinh = tl.MacDinh,
                         Ma = tl.Ma,
                         IsHienThiTrangChu = tl.IsHienThiTrangChu,
                         Link = tl.Link,
                         Nhom = tl.Nhom
                     }).OrderBy(f => f.Stt)
                            .ToList();
            resultList = (List<ThongTinTrangChu>)query.Select(item => new ThongTinTrangChu
            {
                Id = item.Id,
                Stt = item.Stt,
                TieuDe = item.TieuDe,
                KyHieu = item.KyHieu,
                TomTat = item.TomTat,
                NoiDung = item.NoiDung,
                TieuDeTa = item.TieuDeTa,
                TomTatTa = item.TomTatTa,
                NoiDungTa = item.NoiDungTa,
                IsHienThi = item.IsHienThi,
                HinhAnh = item.HinhAnh,
                MacDinh = item.MacDinh,
                Ma = item.Ma,
                IsHienThiTrangChu = item.IsHienThiTrangChu,
                Link = item.Link,
                Nhom = item.Nhom
            }).OrderBy(f => f.Stt)
                        .ToList();
            return resultList;
        }
    }
}
