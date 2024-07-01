using AQapi.Models;
using AQapi.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AQapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingController : ControllerBase
    {
        private readonly IAuthService _auth;
        public SettingController(IAuthService auth)
        {
            this._auth = auth;
        }
        // GET: api/<SettingController>
        [HttpGet]
        public List<Setting> Get()
        {

            List<Setting> resultList = new List<Setting>();
            using (var context = new MyDBContext())
            {
                var query = (from tl in context.Settings
                             select new Setting
                             {
                                 Id = tl.Id,
                                 Stt = tl.Stt,
                                 KyHieu = tl.KyHieu,
                                 TieuDe = tl.TieuDe,
                                 TomTat = tl.TomTat,
                                 TieuDeTa = tl.TieuDeTa,
                                 TomTatTa = tl.TomTatTa,
                                 IsHienThi = tl.IsHienThi,
                                 NoiDung = tl.NoiDung,
                                 NoiDungTa = tl.NoiDungTa
                             }).OrderBy(f => f.Stt).ToList();
                resultList = query.Select(item => new Setting
                {
                    Id = item.Id,
                    KyHieu = item.KyHieu,
                    Stt = item.Stt,
                    TieuDe = item.TieuDe,
                    TomTat = item.TomTat,
                    TieuDeTa = item.TieuDeTa,
                    TomTatTa = item.TomTatTa,
                    IsHienThi = item.IsHienThi,
                    NoiDung = item.NoiDung,
                    NoiDungTa = item.NoiDungTa
                }).OrderBy(f => f.Stt).ToList();
                return resultList;
            }
        }
        [HttpGet("kyhieu")]
        public List<Setting> GetByKyHieu(string kyHieu)
        {
            List<Setting> resultList = new List<Setting>();
            using (var context = new MyDBContext())
            {
                var query = (from tl in context.Settings
                             where tl.KyHieu.Contains(kyHieu)
                             select new Setting
                             {
                                 Id = tl.Id,
                                 Stt = tl.Stt,
                                 KyHieu = tl.KyHieu,
                                 TieuDe = tl.TieuDe,
                                 TomTat = tl.TomTat,
                                 TieuDeTa = tl.TieuDeTa,
                                 TomTatTa = tl.TomTatTa,
                                 IsHienThi = tl.IsHienThi,
                                 NoiDung = tl.NoiDung,
                                 NoiDungTa = tl.NoiDungTa
                             }).OrderBy(f => f.Stt).ToList();
                resultList = query.Select(item => new Setting
                {
                    Id = item.Id,
                    KyHieu = item.KyHieu,
                    Stt = item.Stt,
                    TieuDe = item.TieuDe,
                    TomTat = item.TomTat,
                    TieuDeTa = item.TieuDeTa,
                    TomTatTa = item.TomTatTa,
                    IsHienThi = item.IsHienThi,
                    NoiDung = item.NoiDung,
                    NoiDungTa = item.NoiDungTa
                }).OrderBy(f => f.Stt).ToList();
                return resultList;
            }
        }

        // POST api/<SettingController>
        [HttpPost]
        public IActionResult Post([FromBody] Setting inputData)
        {
            if (_auth.ValidateAdmin(this))
            {
                try
                {
                    using (var context = new MyDBContext())
                    {
                        Setting newData = new Setting()
                        {
                            Id = IdGenerator.NewUID,
                            KyHieu = inputData.KyHieu,
                            Stt = inputData.Stt,
                            TieuDe = inputData.TieuDe,
                            TomTat = inputData.TomTat,
                            TieuDeTa = inputData.TieuDeTa,
                            TomTatTa = inputData.TomTatTa,
                            IsHienThi = inputData.IsHienThi,
                            NoiDung = inputData.NoiDung,
                            NoiDungTa = inputData.NoiDungTa
                        };
                        context.Settings.Add(newData);
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

        // PUT api/<SettingController>/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Setting inputData)
        {
            if (_auth.ValidateAdmin(this))
            {
                try
                {
                    using (var context = new MyDBContext())
                    {
                        var existing = context.Settings.Find(id);
                        if (existing == null)
                        {
                            return Ok("data not exist");
                        }
                        existing.Stt = inputData.Stt;
                        existing.KyHieu = inputData.KyHieu;
                        existing.Stt = inputData.Stt;
                        existing.TieuDe = inputData.TieuDe;
                        existing.TomTat = inputData.TomTat;
                        existing.TieuDeTa = inputData.TieuDeTa;
                        existing.TomTatTa = inputData.TomTatTa;
                        existing.IsHienThi = inputData.IsHienThi;
                        existing.NoiDung = inputData.NoiDung;
                        existing.NoiDungTa = inputData.NoiDungTa;
                        context.Settings.Update(existing);
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

        // DELETE api/<SettingController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            if (_auth.ValidateAdmin(this))
            {
                try
                {
                    using (var context = new MyDBContext())
                    {
                        var data = context.Settings.Find(id);
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