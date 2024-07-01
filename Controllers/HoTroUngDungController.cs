using AQapi.Models;
using AQapi.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AQapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoTroUngDungController : ControllerBase
    {
        private readonly IAuthService _auth;
        public HoTroUngDungController(IAuthService auth)
        {
            this._auth = auth;
        }
        // GET: api/<HoTroUngDungController>
        [HttpGet]
        public List<HoTroUngDung> Get()
        {
            List<HoTroUngDung> resultList = new List<HoTroUngDung>();
            using (var context = new MyDBContext())
            {
                var query = (from hd in context.HoTroUngDungs
                             select new HoTroUngDung
                             {
                                 Id = hd.Id,
                                 Stt = hd.Stt,
                                 Ten = hd.Ten,
                                 LoaiUngDung = hd.LoaiUngDung,
                                 Code = hd.Code,
                                 IsHienThi = hd.IsHienThi,

                             }).OrderBy(f => f.Stt).ToList();
                resultList = (List<HoTroUngDung>)query.Select(item => new HoTroUngDung
                {
                    Id = item.Id,
                    Stt = item.Stt,
                    Ten = item.Ten,
                    LoaiUngDung = item.LoaiUngDung,
                    Code = item.Code,
                    IsHienThi = item.IsHienThi,
                }).OrderBy(f => f.Stt).ToList();
            }
            return resultList;
        }
        [HttpGet("FilterIsHienThi")]
        public List<HoTroUngDung> GetByIsHienThi()
        {
            List<HoTroUngDung> resultList = new List<HoTroUngDung>();
            using (var context = new MyDBContext())
            {
                var query = (from hd in context.HoTroUngDungs
                             where hd.IsHienThi == true
                             select new HoTroUngDung
                             {
                                 Id = hd.Id,
                                 Stt = hd.Stt,
                                 Ten = hd.Ten,
                                 LoaiUngDung = hd.LoaiUngDung,
                                 Code = hd.Code,
                                 IsHienThi = hd.IsHienThi,

                             }).OrderBy(f => f.Stt).ToList();
                resultList = (List<HoTroUngDung>)query.Select(item => new HoTroUngDung
                {
                    Id = item.Id,
                    Stt = item.Stt,
                    Ten = item.Ten,
                    LoaiUngDung = item.LoaiUngDung,
                    Code = item.Code,
                    IsHienThi = item.IsHienThi,
                }).OrderBy(f => f.Stt).ToList();
            }
            return resultList;
        }


        // POST api/<HoTroUngDungController>
        [HttpPost]
        public IActionResult Post([FromBody] HoTroUngDung inputData)
        {
            if (_auth.ValidateAdmin(this))
            {
                try
                {
                    using (var context = new MyDBContext())
                    {
                        var existing = context.Headers.Find(inputData.Id);

                        HoTroUngDung newData = new HoTroUngDung()
                        {
                            Id = IdGenerator.NewUID,
                            Stt = inputData.Stt,
                            Ten = inputData.Ten,
                            LoaiUngDung = inputData.LoaiUngDung,
                            Code = inputData.Code,
                            IsHienThi = inputData.IsHienThi,
                        };

                        context.HoTroUngDungs.Add(newData);
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

        // PUT api/<HoTroUngDungController>/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] HoTroUngDung inputData)
        {
            if (_auth.ValidateAdmin(this))
            {
                try
                {
                    using (var context = new MyDBContext())
                    {
                        var data = context.HoTroUngDungs.Find(id);
                        if (data == null)
                        {
                            return Ok("data not exist");
                        }
                        data.IsHienThi = inputData.IsHienThi;
                        data.Stt = inputData.Stt;
                        data.Ten = inputData.Ten;
                        data.LoaiUngDung = inputData.LoaiUngDung;
                        data.Code = inputData.Code;
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

        // DELETE api/<HoTroUngDungController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            if (_auth.ValidateAdmin(this))
            {
                try
                {
                    using (var context = new MyDBContext())
                    {
                        var header = context.HoTroUngDungs.Find(id);
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
