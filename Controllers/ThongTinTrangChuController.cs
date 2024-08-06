using AQapiDev.Models;
using AQapiDev.Models.CustomModels;
using AQapiDev.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AQapiDev.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThongTinTrangChuController : ControllerBase
    {
        private readonly IAuthService _auth;
        private readonly IThongTinTrangChuService _thongTinTrangChu;
        public ThongTinTrangChuController(IAuthService auth, IThongTinTrangChuService thongTinTrangChu)
        {
            this._auth = auth;
            this._thongTinTrangChu = thongTinTrangChu;
        }
        // GET api/<ThongTinTrangChuController>
        [HttpGet]
        public List<ThongTinTrangChu> Get()
        {
            List<ThongTinTrangChu> resultList = new List<ThongTinTrangChu>();
            using (var context = new MyDBContext())
            {
                var query = (from tl in context.ThongTinTrangChus
                             where tl.IsHienThiTrangChu == true
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
                             }).OrderBy(f => f.KyHieu)
                             .ThenBy(f => f.Stt)
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
                }).OrderBy(f => f.KyHieu)
                             .ThenBy(f => f.Stt)
                    .ToList();
                return resultList;
            }
        }

        // GET api/<ThongTinTrangChuController>/{kyHieu}
        [HttpGet("kyHieu/{kyHieu}")]
        public List<ThongTinTrangChu> GetByKyHieu(string kyHieu)
        {
            List<ThongTinTrangChu> resultList = new List<ThongTinTrangChu>();
            using (var context = new MyDBContext())
            {
                var user = HttpContext.Session.GetString("Username");
                if (user != null)
                {
                    return this._thongTinTrangChu.QueryThongTinTCAdmin(context, kyHieu);

                }
                return this._thongTinTrangChu.QueryThongTinTCAdmin(context, kyHieu);

            }
        }

        // GET api/<ThongTinTrangChuController>/{kyHieu}
        [HttpGet("{id}")]
        public List<ThongTinTrangChu> GetById(long id)
        {
            List<ThongTinTrangChu> resultList = new List<ThongTinTrangChu>();
            using (var context = new MyDBContext())
            {
                var query = (from tl in context.ThongTinTrangChus
                             where tl.Id == id
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

        // POST api/<ThongTinTrangChuController>
        [HttpPost]
        public IActionResult Post([FromBody] ThongTinTrangChu inputData)
        {
            if (_auth.ValidateAdmin(this))
            {
                try
                {
                    using (var context = new MyDBContext())
                    {
                        var existing = context.ThongTinTrangChus.Find(inputData.Id);
                        if (existing != null)
                        {
                            return Ok("data exist");
                        }
                        ThongTinTrangChu newData = new ThongTinTrangChu()
                        {
                            Id = IdGenerator.NewUID,
                            Stt = inputData.Stt,
                            TieuDe = inputData.TieuDe,
                            KyHieu = inputData.KyHieu,
                            TomTat = inputData.TomTat,
                            NoiDung = inputData.NoiDung,
                            TieuDeTa = inputData.TieuDeTa,
                            TomTatTa = inputData.TomTatTa,
                            NoiDungTa = inputData.NoiDungTa,
                            IsHienThi = inputData.IsHienThi,
                            HinhAnh = inputData.HinhAnh,
                            MacDinh = inputData.MacDinh,
                            Ma = inputData.Ma,
                            IsHienThiTrangChu = inputData.IsHienThiTrangChu,
                            Link = inputData.Link,
                            Nhom = inputData.Nhom
                        };
                        context.ThongTinTrangChus.Add(newData);
                        context.SaveChanges();

                        return Ok(newData);
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return Unauthorized("User is not authenticated.");

        }

        /// <summary>
        /// POST: api/<ThongTinTrangChu>
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        [HttpPost("SoLuongVaNoiDung")]
        public List<ThongTinTrangChu> GetTheoSoLuongKhongKemNoiDung([FromBody] FilterByMaVaSoLuongVaNoiDungModel inputData)
        {
            List<ThongTinTrangChu> resultList = new List<ThongTinTrangChu>();

            using (var context = new MyDBContext())
            {
                if (!inputData.isNoiDung)
                {
                    var queryInner = (from tl in context.ThongTinTrangChus
                                      where tl.Ma == inputData.Ma
                                      select new ThongTinTrangChu
                                      {
                                          Id = tl.Id,
                                          Stt = tl.Stt,
                                          TieuDe = tl.TieuDe,
                                          KyHieu = tl.KyHieu,
                                          TomTat = tl.TomTat,
                                          TieuDeTa = tl.TieuDeTa,
                                          TomTatTa = tl.TomTatTa,
                                          IsHienThi = tl.IsHienThi,
                                          HinhAnh = tl.HinhAnh,
                                          MacDinh = tl.MacDinh,
                                          Ma = tl.Ma,
                                          Link = tl.Link,
                                          Nhom = tl.Nhom
                                      }).OrderBy(f => f.Stt)
                            .ToList();
                    resultList = queryInner.Select(item => new ThongTinTrangChu
                    {
                        Id = item.Id,
                        Stt = item.Stt,
                        TieuDe = item.TieuDe,
                        KyHieu = item.KyHieu,
                        TomTat = item.TomTat,
                        TieuDeTa = item.TieuDeTa,
                        TomTatTa = item.TomTatTa,
                        IsHienThi = item.IsHienThi,
                        HinhAnh = item.HinhAnh,
                        MacDinh = item.MacDinh,
                        Ma = item.Ma,
                        Link = item.Link,
                        Nhom = item.Nhom
                    }).OrderBy(f => f.Stt)
                        .ToList();

                    resultList = queryInner.Take(inputData.SoLuong).ToList();

                    return resultList;
                }
                var query = (from tl in context.ThongTinTrangChus
                             where tl.Ma == inputData.Ma
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
                                 Link = tl.Link,
                                 Nhom = tl.Nhom
                             }).OrderBy(f => f.Stt)
                            .ToList();
                resultList = query.Select(item => new ThongTinTrangChu
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
                    Link = item.Link,
                    Nhom = item.Nhom
                }).OrderBy(f => f.Stt)
                    .ToList();

                resultList = query.Take(inputData.SoLuong).ToList();

                return resultList;
            }
        }

        /// <summary>
        /// POST: api/<ThongTinTrangChu>
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>

        [HttpPost("filterByKyHieu")]
        public List<ThongTinTrangChu> GetSoLuongNoiDungByFilter([FromBody] FilterByKyHieu inputData)
        {
            List<ThongTinTrangChu> resultList = new List<ThongTinTrangChu>();

            using (var context = new MyDBContext())
            {
                var kyHieux = inputData.kyHieu;
                if (!inputData.isNoiDung)
                {
                    var queryInner = (from tl in context.ThongTinTrangChus
                                      where kyHieux.Contains(tl.KyHieu)
                                      where tl.IsHienThiTrangChu == true
                                      select new ThongTinTrangChu
                                      {
                                          Id = tl.Id,
                                          Stt = tl.Stt,
                                          TieuDe = tl.TieuDe,
                                          KyHieu = tl.KyHieu,
                                          TomTat = tl.TomTat,
                                          TieuDeTa = tl.TieuDeTa,
                                          TomTatTa = tl.TomTatTa,
                                          IsHienThi = tl.IsHienThi,
                                          HinhAnh = tl.HinhAnh,
                                          MacDinh = tl.MacDinh,
                                          Ma = tl.Ma,
                                          IsHienThiTrangChu = tl.IsHienThiTrangChu,
                                          Link = tl.Link,
                                          Nhom = tl.Nhom
                                      }).OrderBy(f => f.Stt)
                            .ToList();
                    resultList = queryInner.Select(item => new ThongTinTrangChu
                    {
                        Id = item.Id,
                        Stt = item.Stt,
                        TieuDe = item.TieuDe,
                        KyHieu = item.KyHieu,
                        TomTat = item.TomTat,
                        TieuDeTa = item.TieuDeTa,
                        TomTatTa = item.TomTatTa,
                        IsHienThi = item.IsHienThi,
                        HinhAnh = item.HinhAnh,
                        MacDinh = item.MacDinh,
                        Ma = item.Ma,
                        IsHienThiTrangChu = item.IsHienThiTrangChu,
                        Link = item.Link,
                        Nhom = item.Nhom
                    }).OrderBy(f => f.KyHieu)
                    .ThenBy(f => f.Stt)
                        .ToList();

                    return resultList;
                }
                var query = (from tl in context.ThongTinTrangChus
                             where kyHieux.Contains(tl.KyHieu)
                             where tl.IsHienThiTrangChu == true
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
                             }).OrderBy(f => f.KyHieu)
                    .ThenBy(f => f.Stt)
                            .ToList();
                resultList = query.Select(item => new ThongTinTrangChu
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
                    Link = item.Link,
                    IsHienThiTrangChu = item.IsHienThiTrangChu,
                    Nhom = item.Nhom
                }).OrderBy(f => f.Stt)
                    .ToList();

                return resultList;
            }
        }

        // PUT api/<ThongTinTrangChuController>/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] ThongTinTrangChu inputData)
        {
            if (_auth.ValidateAdmin(this))
            {
                try
                {
                    using (var context = new MyDBContext())
                    {
                        var existing = context.ThongTinTrangChus.Find(id);
                        if (existing == null)
                        {
                            return NotFound();
                        }
                        existing.Stt = inputData.Stt;
                        existing.TieuDe = inputData.TieuDe;
                        existing.KyHieu = inputData.KyHieu;
                        existing.TomTat = inputData.TomTat;
                        existing.NoiDung = inputData.NoiDung;
                        existing.TieuDeTa = inputData.TieuDeTa;
                        existing.TomTatTa = inputData.TomTatTa;
                        existing.NoiDungTa = inputData.NoiDungTa;
                        existing.IsHienThi = inputData.IsHienThi;
                        existing.HinhAnh = inputData.HinhAnh;
                        existing.MacDinh = inputData.MacDinh;
                        existing.Ma = inputData.Ma;
                        existing.IsHienThiTrangChu = inputData.IsHienThiTrangChu;
                        existing.Link = inputData.Link;
                        existing.Nhom = inputData.Nhom;
                        context.ThongTinTrangChus.Update(existing);
                        context.SaveChanges();

                        return Ok(existing);
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return Unauthorized("User is not authenticated.");

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            if (_auth.ValidateAdmin(this))
            {
                try
                {
                    using (var context = new MyDBContext())
                    {
                        var data = context.ThongTinTrangChus.Find(id);
                        if (data == null)
                        {
                            return Ok("data not exist");
                        }
                        context.Remove(data);
                        context.SaveChanges();
                        return Ok(data);
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return Unauthorized("User is not authenticated.");

        }
    }
}