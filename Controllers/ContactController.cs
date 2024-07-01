using AQapi.Models;
using AQapi.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AQapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IAuthService _auth;
        public ContactController(IAuthService auth)
        {
            this._auth = auth;
        }
        // GET: api/<ContactController>
        [HttpGet]
        public List<Contact> Get()
        {
            List<Contact> resultList = new List<Contact>();
            using (var context = new MyDBContext())
            {
                var query = (from ct in context.Contacts
                             select new Contact
                             {
                                 Id = ct.Id,
                                 HoTenNguoiGui = ct.HoTenNguoiGui,
                                 GioiTinh = ct.GioiTinh,
                                 SoDienThoai = ct.SoDienThoai,
                                 Email = ct.Email,
                                 DonViCongTac = ct.DonViCongTac,
                                 NoiDung = ct.NoiDung,
                                 NgayGui = ct.NgayGui,
                             }).OrderBy(f => f.NgayGui)
                             .ToList();
                resultList = query.Select(item => new Contact
                {
                    Id = item.Id,
                    HoTenNguoiGui = item.HoTenNguoiGui,
                    GioiTinh = item.GioiTinh,
                    SoDienThoai = item.SoDienThoai,
                    Email = item.Email,
                    DonViCongTac = item.DonViCongTac,
                    NoiDung = item.NoiDung,
                    NgayGui = item.NgayGui,
                }).OrderBy(f => f.NgayGui)
                    .ToList();
                return resultList;
            }
        }

        // GET api/<ContactController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<ContactController>
        [HttpPost]
        public IActionResult Post([FromBody] Contact inputData)
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
                        Contact newData = new Contact()
                        {
                            Id = IdGenerator.NewUID,
                            HoTenNguoiGui = inputData.HoTenNguoiGui,
                            GioiTinh = inputData.GioiTinh,
                            SoDienThoai = inputData.SoDienThoai,
                            Email = inputData.Email,
                            DonViCongTac = inputData.DonViCongTac,
                            NoiDung = inputData.NoiDung,
                            NgayGui = DateTime.Now,
                        };
                        context.Contacts.Add(newData);
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

        // PUT api/<ContactController>/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Contact inputData)
        {
            if (_auth.ValidateAdmin(this))
            {
                try
                {
                    using (var context = new MyDBContext())
                    {
                        var existing = context.Contacts.Find(id);
                        if (existing == null)
                        {
                            return NotFound();
                        }
                        existing.HoTenNguoiGui = inputData.HoTenNguoiGui;
                        existing.GioiTinh = inputData.GioiTinh;
                        existing.SoDienThoai = inputData.SoDienThoai;
                        existing.Email = inputData.Email;
                        existing.DonViCongTac = inputData.DonViCongTac;
                        existing.NoiDung = inputData.NoiDung;
                        context.Contacts.Update(existing);
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

        // DELETE api/<ContactController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            if (_auth.ValidateAdmin(this))
            {
                try
                {
                    using (var context = new MyDBContext())
                    {
                        var data = context.Contacts.Find(id);
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