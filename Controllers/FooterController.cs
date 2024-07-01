using AQapi.Models;
using AQapi.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AQapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooterController : ControllerBase
    {
        private readonly IAuthService _auth;
        public FooterController(IAuthService auth)
        {
            this._auth = auth;
        }
        // GET: api/<FooterController>
        [HttpGet]
        public List<Footer> Get()
        {
            List<Footer> resultList = new List<Footer>();
            using (var context = new MyDBContext())
            {
                var query = (from ft in context.Footers
                             select new Footer
                             {
                                 Id = ft.Id,
                                 Stt = ft.Stt,
                                 Groups = ft.Groups,
                                 NoiDung = ft.NoiDung,
                                 NoiDungTa = ft.NoiDungTa,
                                 Link = ft.Link,
                                 HinhAnh = ft.HinhAnh,
                                 HienThi = ft.HienThi,
                                 Email = ft.Email,
                             }).OrderBy(f => f.Groups)
                                .ThenBy(f => f.Stt)
                                .ToList();
                resultList = (List<Footer>)query.Select(item => new Footer
                {
                    Id = item.Id,
                    Stt = item.Stt,
                    Groups = item.Groups,
                    NoiDung = item.NoiDung,
                    NoiDungTa = item.NoiDungTa,
                    Link = item.Link,
                    HinhAnh = item.HinhAnh,
                    HienThi = item.HienThi,
                    Email = item.Email,
                }).OrderBy(f => f.Groups)
                .ThenBy(f => f.Stt)
                .ToList();
            }
            return resultList;
        }

        // POST api/<FooterController>
        [HttpPost]
        public IActionResult Post([FromBody] Footer inputData)
        {
            if (_auth.ValidateAdmin(this))
            {
                try
                {
                    using (var context = new MyDBContext())
                    {
                        var existing = context.Footers.Find(inputData.Id);

                        Footer newData = new Footer()
                        {
                            Id = IdGenerator.NewUID,
                            Stt = inputData.Stt,
                            Groups = inputData.Groups,
                            NoiDung = inputData.NoiDung,
                            NoiDungTa = inputData.NoiDungTa,
                            Link = inputData.Link,
                            HinhAnh = inputData.HinhAnh,
                            HienThi = inputData.HienThi,
                            Email = inputData.Email,
                        };

                        context.Footers.Add(newData);
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

        // PUT api/<FooterController>/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Footer inputData)
        {
            if (_auth.ValidateAdmin(this))
            {
                try
                {
                    using (var context = new MyDBContext())
                    {
                        var footer = context.Footers.Find(id);
                        if (footer == null)
                        {
                            return Ok("data not exist");
                        }
                        footer.Stt = inputData.Stt;
                        footer.Groups = inputData.Groups;
                        footer.NoiDung = inputData.NoiDung;
                        footer.NoiDungTa = inputData.NoiDungTa;
                        footer.Link = inputData.Link;
                        footer.HinhAnh = inputData.HinhAnh;
                        footer.HienThi = inputData.HienThi;
                        footer.Email = inputData.Email;
                        context.SaveChanges();
                        return Ok(footer);
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return Unauthorized("User is not authenticated.");

        }

        // DELETE api/<FooterController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            if (_auth.ValidateAdmin(this))
            {
                try
                {
                    using (var context = new MyDBContext())
                    {
                        var footer = context.Footers.Find(id);
                        if (footer == null)
                        {
                            return Ok("data not exist");
                        }
                        context.Remove(footer);
                        context.SaveChanges();
                        return Ok(footer);
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