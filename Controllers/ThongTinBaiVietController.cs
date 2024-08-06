using AQapiDev.Models;
using AQapiDev.Models.CustomModels;
using AQapiDev.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AQapiDev.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThongTinBaiVietController : ControllerBase
    {
        private readonly IAuthService _auth;
        public ThongTinBaiVietController(IAuthService auth)
        {
            this._auth = auth;
        }
        // GET: api/<ThongTinBaiViet>
        [HttpGet]
        public List<ThongTinBaiViet> Get()
        {
            List<ThongTinBaiViet> resultList = new List<ThongTinBaiViet>();
            using (var context = new MyDBContext())
            {
                var query = (from tl in context.ThongTinBaiViets
                             select new ThongTinBaiViet
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
                                 NgayDang = tl.NgayDang,
                                 LoaiBaiViet = tl.LoaiBaiViet
                             }).OrderBy(f => f.NgayDang)
                                .ThenBy(f => f.Stt)
                                .ToList();
                resultList = query.Select(item => new ThongTinBaiViet
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
                    NgayDang = item.NgayDang,
                    LoaiBaiViet = item.LoaiBaiViet
                }).OrderBy(f => f.NgayDang)
                    .ThenBy(f => f.Stt)
                    .ToList();
                return resultList;
            }
        }

        // GET api/<ThongTinTrangChuController>/{kyHieu}
        [HttpGet("{id}")]
        public List<ThongTinBaiViet> GetByID(long id)
        {
            List<ThongTinBaiViet> resultList = new List<ThongTinBaiViet>();
            using (var context = new MyDBContext())
            {
                var query = (from tl in context.ThongTinBaiViets
                             where tl.Id == id
                             select new ThongTinBaiViet
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
                                 NgayDang = tl.NgayDang,
                                 LoaiBaiViet = tl.LoaiBaiViet
                             }).OrderBy(f => f.NgayDang)
                                .ThenBy(f => f.Stt)
                                .ToList();
                resultList = query.Select(item => new ThongTinBaiViet
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
                    NgayDang = item.NgayDang,
                    LoaiBaiViet = item.LoaiBaiViet
                }).OrderBy(f => f.NgayDang)
                    .ThenBy(f => f.Stt)
                    .ToList();
                return resultList;
            }
        }

        // GET: api/<ThongTinBaiViet>
        [HttpPost("SoLuongVaNoiDung")]
        public List<ThongTinBaiViet> GetTheoSoLuongKhongKemNoiDung([FromBody] FilterBySoLuongVaNoiDungModel inputData)
        {

            List<ThongTinBaiViet> resultList = new List<ThongTinBaiViet>();

            using (var context = new MyDBContext())
            {
                if (!inputData.isNoiDung)
                {
                    var queryInner = (from tl in context.ThongTinBaiViets
                                      where tl.IsHienThi == true
                                      select new ThongTinBaiViet
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
                                          NgayDang = tl.NgayDang,
                                          LoaiBaiViet = tl.LoaiBaiViet
                                      }).OrderByDescending(f => f.NgayDang)
                                .ThenBy(f => f.Stt)
                            .ToList();
                    resultList = queryInner.Select(item => new ThongTinBaiViet
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
                        NgayDang = item.NgayDang,
                        LoaiBaiViet = item.LoaiBaiViet
                    }).OrderByDescending(f => f.NgayDang)
                                    .ThenBy(f => f.Stt)
                        .ToList();

                    resultList = queryInner.Take(inputData.SoLuong).ToList();

                    return resultList;
                }
                var query = (from tl in context.ThongTinBaiViets
                             where tl.IsHienThi == true
                             select new ThongTinBaiViet
                             {
                                 Id = tl.Id,
                                 Stt = tl.Stt,
                                 TieuDe = tl.TieuDe,
                                 KyHieu = tl.KyHieu,
                                 TomTat = tl.TomTat,
                                 TieuDeTa = tl.TieuDeTa,
                                 NoiDung = tl.NoiDung,
                                 TomTatTa = tl.TomTatTa,
                                 IsHienThi = tl.IsHienThi,
                                 NoiDungTa = tl.NoiDungTa,
                                 HinhAnh = tl.HinhAnh,
                                 MacDinh = tl.MacDinh,
                                 NgayDang = tl.NgayDang,
                                 LoaiBaiViet = tl.LoaiBaiViet
                             }).OrderByDescending(f => f.NgayDang)
                            .ThenBy(f => f.Stt)
                            .ToList();
                resultList = query.Select(item => new ThongTinBaiViet
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
                    NgayDang = item.NgayDang,
                    LoaiBaiViet = item.LoaiBaiViet
                }).OrderByDescending(f => f.NgayDang)
                    .ThenBy(f => f.Stt)
                    .ToList();

                resultList = query.Take(inputData.SoLuong).ToList();

                return resultList;
            }
        }

        // POST api/<ThongTinBaiViet>
        [HttpPost]
        public IActionResult Post([FromBody] ThongTinBaiViet inputData)
        {
            if (_auth.ValidateAdmin(this))
            {
                try
                {
                    using (var context = new MyDBContext())
                    {
                        var existing = context.ThongTinBaiViets.Find(inputData.Id);
                        if (existing != null)
                        {
                            return Ok("data exist");
                        }
                        ThongTinBaiViet newData = new ThongTinBaiViet()
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
                            NgayDang = DateTime.Now,
                            LoaiBaiViet = inputData.LoaiBaiViet
                        };
                        context.ThongTinBaiViets.Add(newData);
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

        // PUT api/<ThongTinBaiViet>/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] ThongTinBaiViet inputData)
        {
            if (_auth.ValidateAdmin(this))
            {
                try
                {
                    using (var context = new MyDBContext())
                    {
                        var existing = context.ThongTinBaiViets.Find(id);

                        if (existing == null)
                        {
                            return NotFound();
                        }

                        // Update other properties
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
                        existing.LoaiBaiViet = inputData.LoaiBaiViet;

                        context.ThongTinBaiViets.Update(existing);
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

        // DELETE api/<ThongTinBaiViet>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            if (_auth.ValidateAdmin(this))
            {
                try
                {
                    using (var context = new MyDBContext())
                    {
                        var data = context.ThongTinBaiViets.Find(id);
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