using AQapiDev.Models;
using AQapiDev.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AQapiDev.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannerController : ControllerBase
    {
        private readonly IAuthService _auth;
        public BannerController(IAuthService auth)
        {
            this._auth = auth;
        }
        // GET: api/<BannerController>
        [HttpGet]
        public List<Banner> Get()
        {
            using (var context = new MyDBContext())
            {
                List<Banner> resultList = new List<Banner>();
                var query = (from bn in context.Banners
                             select new Banner
                             {
                                 Id = bn.Id,
                                 Stt = bn.Stt,
                                 TieuDe = bn.TieuDe,
                                 TomTat = bn.TomTat,
                                 NoiDung = bn.NoiDung,
                                 TieuDeTa = bn.TieuDeTa,
                                 TomTatTa = bn.TomTatTa,
                                 NoiDungTa = bn.NoiDungTa,
                                 HinhAnh = bn.HinhAnh,
                                 HinhAnhCon = bn.HinhAnhCon,
                                 Link = bn.Link,
                             }).OrderBy(f => f.Stt).ToList();
                resultList = (List<Banner>)query.Select(item => new Banner
                {
                    Id = item.Id,
                    Stt = item.Stt,
                    TieuDe = item.TieuDe,
                    TomTat = item.TomTat,
                    NoiDung = item.NoiDung,
                    TieuDeTa = item.TieuDeTa,
                    TomTatTa = item.TomTatTa,
                    NoiDungTa = item.NoiDungTa,
                    HinhAnh = item.HinhAnh,
                    HinhAnhCon = item.HinhAnhCon,
                    Link = item.Link,
                }).OrderBy(f => f.Stt).ToList();
                return resultList;
            }
        }

        // POST api/<BannerController>
        [HttpPost]
        public IActionResult Post([FromBody] Banner inputData)
        {
            if (_auth.ValidateAdmin(this))
            {
                try
                {
                    using (var context = new MyDBContext())
                    {
                        Banner newData = new Banner()
                        {
                            Id = IdGenerator.NewUID,
                            Stt = inputData.Stt,
                            TieuDe = inputData.TieuDe,
                            TomTat = inputData.TomTat,
                            NoiDung = inputData.NoiDung,
                            TieuDeTa = inputData.TieuDeTa,
                            TomTatTa = inputData.TomTatTa,
                            NoiDungTa = inputData.NoiDungTa,
                            HinhAnh = inputData.HinhAnh,
                            HinhAnhCon = inputData.HinhAnhCon,
                            Link = inputData.Link,
                        };

                        context.Banners.Add(newData);
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

        // PUT api/<BannerController>/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Banner inputData)
        {
            if (_auth.ValidateAdmin(this))
            {
                try
                {
                    using (var context = new MyDBContext())
                    {
                        var banner = context.Banners.Find(id);
                        if (banner == null)
                        {
                            return Ok("data not exist");
                        }
                        banner.Stt = inputData.Stt;
                        banner.TieuDe = inputData.TieuDe;
                        banner.TomTat = inputData.TomTat;
                        banner.NoiDung = inputData.NoiDung;
                        banner.TieuDeTa = inputData.TieuDeTa;
                        banner.TomTatTa = inputData.TomTatTa;
                        banner.NoiDungTa = inputData.NoiDungTa;
                        banner.HinhAnh = inputData.HinhAnh;
                        banner.HinhAnhCon = inputData.HinhAnhCon;
                        banner.Link = inputData.Link;
                        context.SaveChanges();
                        return Ok(banner);
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return Unauthorized("User is not authenticated.");

        }

        // DELETE api/<BannerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            if (_auth.ValidateAdmin(this))
            {
                try
                {
                    using (var context = new MyDBContext())
                    {
                        var banner = context.Banners.Find(id);
                        if (banner == null)
                        {
                            return Ok("data don't exist");
                        }
                        context.Remove(banner);
                        context.SaveChanges();
                        return Ok(banner);
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