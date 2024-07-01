using AQapi.Models;
using AQapi.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AQapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeaderController : ControllerBase
    {
        private readonly IAuthService _auth;
        public HeaderController(IAuthService auth)
        {
            this._auth = auth;
        }
        // GET: api/<HeaderController>
        [HttpGet]
        public List<Header> Get()
        {
            List<Header> resultList = new List<Header>();
            using (var context = new MyDBContext())
            {
                var query = (from hd in context.Headers
                             select new Header
                             {
                                 Id = hd.Id,
                                 Stt = hd.Stt,
                                 DanhMucCha = hd.DanhMucCha,
                                 DanhMuc = hd.DanhMuc,
                                 DanhMucChaTa = hd.DanhMucChaTa,
                                 DanhMucTa = hd.DanhMucTa,
                                 IsHienThi = hd.IsHienThi,
                                 Link = hd.Link,
                             }).OrderBy(f => f.Stt).ToList();
                resultList = (List<Header>)query.Select(item => new Header
                {
                    Id = item.Id,
                    Stt = item.Stt,
                    DanhMucCha = item.DanhMucCha,
                    DanhMuc = item.DanhMuc,
                    DanhMucChaTa = item.DanhMucChaTa,
                    DanhMucTa = item.DanhMucTa,
                    IsHienThi = item.IsHienThi,
                    Link = item.Link,
                }).OrderBy(f => f.Stt).ToList();
            }
            return resultList;
        }

        // POST api/<HeaderController>
        [HttpPost]
        public IActionResult Post([FromBody] Header inputData)
        {
            if (_auth.ValidateAdmin(this))
            {
                try
                {
                    using (var context = new MyDBContext())
                    {
                        var existing = context.Headers.Find(inputData.Id);

                        Header newData = new Header()
                        {
                            Id = IdGenerator.NewUID,
                            Stt = inputData.Stt,
                            DanhMucCha = inputData.DanhMucCha,
                            DanhMuc = inputData.DanhMuc,
                            DanhMucChaTa = inputData.DanhMucChaTa,
                            DanhMucTa = inputData.DanhMucTa,
                            IsHienThi = inputData.IsHienThi,
                            Link = inputData.Link,
                        };

                        context.Headers.Add(newData);
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

        // PUT api/<HeaderController>/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Header inputData)
        {
            if (_auth.ValidateAdmin(this))
            {
                try
                {
                    using (var context = new MyDBContext())
                    {
                        var header = context.Headers.Find(id);
                        if (header == null)
                        {
                            return Ok("data not exist");
                        }
                        header.IsHienThi = inputData.IsHienThi;
                        header.Stt = inputData.Stt;
                        header.DanhMucCha = inputData.DanhMucCha;
                        header.DanhMuc = inputData.DanhMuc;
                        header.DanhMucChaTa = inputData.DanhMucChaTa;
                        header.DanhMucTa = inputData.DanhMucTa;
                        header.IsHienThi = inputData.IsHienThi;
                        header.Link = inputData.Link;
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

        // DELETE api/<HeaderController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            if (_auth.ValidateAdmin(this))
            {
                try
                {
                    using (var context = new MyDBContext())
                    {
                        var header = context.Headers.Find(id);
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