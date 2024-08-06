using AQapiDev.Models;
using AQapiDev.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AQapiDev.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoTroDienThoaiController : ControllerBase
    {
        private readonly IAuthService _auth;
        public HoTroDienThoaiController(IAuthService auth)
        {
            this._auth = auth;
        }
        // GET: api/<HeaderController>
        [HttpGet]
        public List<HoTroDienThoai> Get()
        {
            List<HoTroDienThoai> resultList = new List<HoTroDienThoai>();
            using (var context = new MyDBContext())
            {
                var query = (from hd in context.HoTroDienThoais
                             select new HoTroDienThoai
                             {
                                 Id = hd.Id,
                                 Stt = hd.Stt,
                                 Ten = hd.Ten,
                                 SoDienThoai = hd.SoDienThoai,
                                 IsHienThi = hd.IsHienThi,

                             }).OrderBy(f => f.Stt).ToList();
                resultList = (List<HoTroDienThoai>)query.Select(item => new HoTroDienThoai
                {
                    Id = item.Id,
                    Stt = item.Stt,
                    Ten = item.Ten,
                    SoDienThoai = item.SoDienThoai,
                    IsHienThi = item.IsHienThi,
                }).OrderBy(f => f.Stt).ToList();
            }
            return resultList;
        }
        // GET: api/<HeaderController>
        [HttpGet("FilterIsHienThi")]
        public List<HoTroDienThoai> GetByIsHienThi()
        {
            List<HoTroDienThoai> resultList = new List<HoTroDienThoai>();
            using (var context = new MyDBContext())
            {
                var query = (from hd in context.HoTroDienThoais
                             where hd.IsHienThi == true
                             select new HoTroDienThoai
                             {
                                 Id = hd.Id,
                                 Stt = hd.Stt,
                                 Ten = hd.Ten,
                                 SoDienThoai = hd.SoDienThoai,
                                 IsHienThi = hd.IsHienThi,

                             }).OrderBy(f => f.Stt).ToList();
                resultList = (List<HoTroDienThoai>)query.Select(item => new HoTroDienThoai
                {
                    Id = item.Id,
                    Stt = item.Stt,
                    Ten = item.Ten,
                    SoDienThoai = item.SoDienThoai,
                    IsHienThi = item.IsHienThi,
                }).OrderBy(f => f.Stt).ToList();
            }
            return resultList;
        }
        // POST api/<HoTroDienThoaiController>
        [HttpPost]
        public IActionResult Post([FromBody] HoTroDienThoai inputData)
        {
            if (_auth.ValidateAdmin(this))
            {
                try
                {
                    using (var context = new MyDBContext())
                    {
                        var existing = context.Headers.Find(inputData.Id);

                        HoTroDienThoai newData = new HoTroDienThoai()
                        {
                            Id = IdGenerator.NewUID,
                            Stt = inputData.Stt,
                            Ten = inputData.Ten,
                            SoDienThoai = inputData.SoDienThoai,
                            IsHienThi = inputData.IsHienThi,
                        };

                        context.HoTroDienThoais.Add(newData);
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

        // PUT api/<HoTroDienThoaiController>/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] HoTroDienThoai inputData)
        {
            if (_auth.ValidateAdmin(this))
            {
                try
                {
                    using (var context = new MyDBContext())
                    {
                        var data = context.HoTroDienThoais.Find(id);
                        if (data == null)
                        {
                            return Ok("data not exist");
                        }
                        data.IsHienThi = inputData.IsHienThi;
                        data.Stt = inputData.Stt;
                        data.Ten = inputData.Ten;
                        data.SoDienThoai = inputData.SoDienThoai;

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

        // DELETE api/<HoTroDienThoaiController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            if (_auth.ValidateAdmin(this))
            {
                try
                {
                    using (var context = new MyDBContext())
                    {
                        var header = context.HoTroDienThoais.Find(id);
                        if (header == null)
                        {
                            return Ok("data not exist");
                        }
                        context.Remove(header);
                        context.SaveChanges();
                        return Ok(header);
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
