using AQapiDev.Models;
using AQapiDev.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AQapiDev.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiaiThuongController : ControllerBase
    {
        private readonly IAuthService _auth;
        public GiaiThuongController(IAuthService auth)
        {
            this._auth = auth;
        }
        // GET: api/<GiaiThuongsController>
        [HttpGet]
        public List<GiaiThuong> Get()
        {
            List<GiaiThuong> resultList = new List<GiaiThuong>();
            using (var context = new MyDBContext())
            {
                var query = (from tl in context.GiaiThuongs
                             where tl.IsHienThi == true
                             select new GiaiThuong
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
                                 Link = tl.Link
                             }).OrderBy(f => f.KyHieu)
                             .ThenBy(f => f.Stt)
                            .ToList();
                resultList = (List<GiaiThuong>)query.Select(item => new GiaiThuong
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
                    Link = item.Link
                }).OrderBy(f => f.KyHieu)
                             .ThenBy(f => f.Stt)
                    .ToList();
                return resultList;
            }
        }

        // GET api/<GiaiThuongController>/{kyHieu}
        [HttpGet("kyHieu/{kyHieu}")]
        public List<GiaiThuong> GetByKyHieu(string kyHieu)
        {
            List<GiaiThuong> resultList = new List<GiaiThuong>();
            using (var context = new MyDBContext())
            {
                var query = (from tl in context.GiaiThuongs
                             where tl.KyHieu.Contains(kyHieu)
                             select new GiaiThuong
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

                                 Link = tl.Link
                             }).OrderBy(f => f.Stt)
                            .ToList();
                resultList = (List<GiaiThuong>)query.Select(item => new GiaiThuong
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

                    Link = item.Link
                }).OrderBy(f => f.Stt)
                            .ToList();
                return resultList;
            }
        }

        // POST api/<GiaiThuongController>
        [HttpPost]
        public IActionResult Post([FromBody] GiaiThuong inputData)
        {
            if (_auth.ValidateAdmin(this))
            {
                try
                {
                    using (var context = new MyDBContext())
                    {
                        var existing = context.GiaiThuongs.Find(inputData.Id);
                        if (existing != null)
                        {
                            return Ok("data exist");
                        }
                        GiaiThuong newData = new GiaiThuong()
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
                            Link = inputData.Link
                        };
                        context.GiaiThuongs.Add(newData);
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

        // PUT api/<GiaiThuongController>/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] GiaiThuong inputData)
        {
            if (_auth.ValidateAdmin(this))
            {
                try
                {
                    using (var context = new MyDBContext())
                    {
                        var existing = context.GiaiThuongs.Find(id);
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

                        existing.Link = inputData.Link;
                        context.GiaiThuongs.Update(existing);
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
                        var data = context.GiaiThuongs.Find(id);
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
