using AQapiDev;
using AQapiDev.Models;
using AQapiDev.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AQTechWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThietLapChungController : ControllerBase
    {
        private readonly IAuthService _auth;
        public ThietLapChungController(IAuthService auth)
        {
            this._auth = auth;
        }
        // GET: api/<ThietLapChungController>
        [HttpGet]
        public object Get()
        {
            //List<ThietLapChung> resultList = new List<ThietLapChung>();
            using (var context = new MyDBContext())
            {
                return context.ThietLapChungs.ToList();
                var query = (from tl in context.ThietLapChungs
                             select new ThietLapChung
                             {
                                 Id = tl.Id,
                                 Stt = tl.Stt,
                                 TenWebsite = tl.TenWebsite,
                                 TenWebsiteTa = tl.TenWebsiteTa,
                                 Title = tl.Title,
                                 TitleTa = tl.TitleTa,
                                 HinhAnhLogo = tl.HinhAnhLogo,
                                 Favicon = tl.Favicon,
                                 NgonNgu = tl.NgonNgu,
                                 LinkFacebook = tl.LinkFacebook,
                                 LinkYoutube = tl.LinkYoutube,
                                 SoDienThoai = tl.SoDienThoai,
                                 Fax = tl.Fax,
                                 DiaChi = tl.DiaChi,
                                 DiaChiTa = tl.DiaChiTa,
                                 Email = tl.Email,
                                 DiaChi2 = tl.DiaChi2,
                                 DiaChi2Ta = tl.DiaChi2Ta,
                                 DiaChi3 = tl.DiaChi3,
                                 DiaChi3Ta = tl.DiaChi3Ta,
                             }).ToList();
                //resultList = (List<ThietLapChung>)query.Select(item => new ThietLapChung
                //{
                //    Id = item.Id,
                //    Stt = item.Stt,
                //    TenWebsiteTa = item.TenWebsiteTa,
                //    Title = item.Title,
                //    TitleTa = item.TitleTa,
                //    Favicon = item.Favicon,
                //    TenWebsite = item.TenWebsite,
                //    HinhAnhLogo = item.HinhAnhLogo,
                //    NgonNgu = item.NgonNgu,
                //    LinkFacebook = item.LinkFacebook,
                //    LinkYoutube = item.LinkYoutube,
                //    SoDienThoai = item.SoDienThoai,
                //    Fax = item.Fax,
                //    DiaChi = item.DiaChi,
                //    DiaChiTa = item.DiaChiTa,
                //    Email = item.Email,
                //    DiaChi2 = item.DiaChi2,
                //    DiaChi2Ta = item.DiaChi2Ta,
                //    DiaChi3 = item.DiaChi3,
                //    DiaChi3Ta = item.DiaChi3Ta,
                //}).ToList();
                ////return resultList;
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] ThietLapChung InputData)
        {
            if (_auth.ValidateAdmin(this))
            {
                try
                {
                    using (var context = new MyDBContext())
                    {
                        ThietLapChung newData = new ThietLapChung()
                        {
                            Id = IdGenerator.NewUID,
                            Stt = InputData.Stt,
                            TenWebsiteTa = InputData.TenWebsiteTa,
                            Title = InputData.Title,
                            TitleTa = InputData.TitleTa,
                            Favicon = InputData.Favicon,
                            TenWebsite = InputData.TenWebsite,
                            HinhAnhLogo = InputData.HinhAnhLogo,
                            NgonNgu = InputData.NgonNgu,
                            LinkFacebook = InputData.LinkFacebook,
                            LinkYoutube = InputData.LinkYoutube,
                            SoDienThoai = InputData.SoDienThoai,
                            Fax = InputData.Fax,
                            DiaChi = InputData.DiaChi,
                            DiaChiTa = InputData.DiaChiTa,
                            Email = InputData.Email,
                            DiaChi2 = InputData.DiaChi2,
                            DiaChi2Ta = InputData.DiaChi2Ta,
                            DiaChi3 = InputData.DiaChi3,
                            DiaChi3Ta = InputData.DiaChi3Ta,

                        };
                        context.ThietLapChungs.Add(newData);
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

        [HttpPut("{id}")]
        public ActionResult<List<ThietLapChung>> Put(long id, [FromBody] ThietLapChung InputData)
        {
            if (_auth.ValidateAdmin(this))
            {
                try
                {
                    using (var context = new MyDBContext())
                    {
                        var existing = context.ThietLapChungs.Find(id);
                        if (existing == null)
                        {
                            return Ok("data not exist");
                        }

                        existing.Stt = InputData.Stt;
                        existing.TenWebsiteTa = InputData.TenWebsiteTa;
                        existing.Title = InputData.Title;
                        existing.TitleTa = InputData.TitleTa;
                        existing.Favicon = InputData.Favicon;
                        existing.TenWebsite = InputData.TenWebsite;
                        existing.HinhAnhLogo = InputData.HinhAnhLogo;
                        existing.NgonNgu = InputData.NgonNgu;
                        existing.LinkFacebook = InputData.LinkFacebook;
                        existing.LinkYoutube = InputData.LinkYoutube;
                        existing.SoDienThoai = InputData.SoDienThoai;
                        existing.Fax = InputData.Fax;
                        existing.DiaChi = InputData.DiaChi;
                        existing.DiaChiTa = InputData.DiaChiTa;
                        existing.Email = InputData.Email;
                        existing.DiaChi2 = InputData.DiaChi2;
                        existing.DiaChi2Ta = InputData.DiaChi2Ta;
                        existing.DiaChi3 = InputData.DiaChi3;
                        existing.DiaChi3Ta = InputData.DiaChi3Ta;
                        context.ThietLapChungs.Update(existing);
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

        // DELETE api/<ThietLapChungController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            if (_auth.ValidateAdmin(this))
            {
                try
                {
                    using (var context = new MyDBContext())
                    {
                        var ThietLapChungs = context.ThietLapChungs.Find(id);
                        if (ThietLapChungs == null)
                        {
                            return Ok("data don't exist");
                        }
                        context.Remove(ThietLapChungs);
                        context.SaveChanges();
                        return Ok(ThietLapChungs);
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