using AQapi.Models;
using AQapi.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AQapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LichSuPhatTrienController : ControllerBase
    {
        private readonly IAuthService _auth;
        public LichSuPhatTrienController(IAuthService auth)
        {
            this._auth = auth;
        }
        // GET: api/<LichSuPhatTrienController>
        [HttpGet]
        public List<LichSuPhatTrien> Get()
        {
            using (var context = new MyDBContext())
            {
                List<LichSuPhatTrien> resultList = new List<LichSuPhatTrien>();
                var query = (from bn in context.LichSuPhatTriens
                             select new LichSuPhatTrien
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
                                 Link = bn.Link,
                             }).ToList();
                resultList = (List<LichSuPhatTrien>)query.Select(item => new LichSuPhatTrien
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
                    Link = item.Link,
                }).ToList();
                return resultList;
            }
        }

        //// GET api/<LichSuPhatTrienController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<LichSuPhatTrienController>
        [HttpPost]
        public IActionResult Post([FromBody] LichSuPhatTrien inputData)
        {
            if (_auth.ValidateAdmin(this))
            {
                try
                {
                    using (var context = new MyDBContext())
                    {
                        LichSuPhatTrien newData = new LichSuPhatTrien()
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
                            Link = inputData.Link,
                        };
                        context.LichSuPhatTriens.Add(newData);
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

        // PUT api/<LichSuPhatTrienController>/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] LichSuPhatTrien inputData)
        {
            if (_auth.ValidateAdmin(this))
            {
                try
                {
                    using (var context = new MyDBContext())
                    {
                        var lichSuPhatTrien = context.LichSuPhatTriens.Find(id);
                        if (lichSuPhatTrien == null)
                        {
                            return Ok("data not exist");
                        }
                        lichSuPhatTrien.Stt = inputData.Stt;
                        lichSuPhatTrien.TieuDe = inputData.TieuDe;
                        lichSuPhatTrien.TomTat = inputData.TomTat;
                        lichSuPhatTrien.NoiDung = inputData.NoiDung;
                        lichSuPhatTrien.TieuDeTa = inputData.TieuDeTa;
                        lichSuPhatTrien.TomTatTa = inputData.TomTatTa;
                        lichSuPhatTrien.NoiDungTa = inputData.NoiDungTa;
                        lichSuPhatTrien.HinhAnh = inputData.HinhAnh;
                        lichSuPhatTrien.Link = inputData.Link;
                        context.SaveChanges();
                        return Ok(lichSuPhatTrien);
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return Unauthorized("User is not authenticated.");

        }

        // DELETE api/<LichSuPhatTrienController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_auth.ValidateAdmin(this))
            {
                try
                {
                    using (var context = new MyDBContext())
                    {
                        var lichSuPhatTrien = context.LichSuPhatTriens.Find(id);
                        if (lichSuPhatTrien == null)
                        {
                            return Ok("data don't exist");
                        }
                        context.Remove(lichSuPhatTrien);
                        context.SaveChanges();
                        return Ok(lichSuPhatTrien);
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