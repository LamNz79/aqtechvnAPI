//using AQapiDev.Models;
//using Microsoft.AspNetCore.Mvc;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace AQapiDev.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class TaiKhoanController : ControllerBase
//    {
//        // GET: api/<TaiKhoanController>
//        [HttpGet]
//        public ActionResult<List<WebTaiKhoanDatum>> Get()
//        {
//            List<WebTaiKhoanDatum> resultList = new List<WebTaiKhoanDatum>();
//            using (var context = new MyDBContext())
//            {
//                var query = (from tk in context.WebTaiKhoanData
//                             select new WebTaiKhoanDatum
//                             {
//                                 Id = tk.Id,
//                                 Username = tk.Username,
//                                 Password = tk.Password,
//                                 HoTen = tk.HoTen,
//                                 GioiTinh = tk.GioiTinh,
//                                 DiaChi = tk.DiaChi,
//                                 SoDienThoai = tk.SoDienThoai,
//                                 Email = tk.Email,
//                                 IsAdmin = tk.IsAdmin,
//                                 CreatedTime = tk.CreatedTime,
//                                 CreatedBy = tk.CreatedBy,
//                             }).ToList();
//                resultList = (List<WebTaiKhoanDatum>)query.Select(item => new WebTaiKhoanDatum
//                {
//                    Id = item.Id,
//                    Username = item.Username,
//                    Password = item.Password,
//                    HoTen = item.HoTen,
//                    GioiTinh = item.GioiTinh,
//                    DiaChi = item.DiaChi,
//                    SoDienThoai = item.SoDienThoai,
//                    Email = item.Email,
//                    IsAdmin = item.IsAdmin,
//                    CreatedTime = item.CreatedTime,
//                    CreatedBy = item.CreatedBy,
//                }).ToList();
//            }
//            return resultList;
//        }

//        // GET api/<TaiKhoanController>/5
//        [HttpGet("{id}")]
//        public ActionResult<List<WebTaiKhoanDatum>> Get(int id)
//        {
//            try
//            {
//                List<WebTaiKhoanDatum> resultList = new List<WebTaiKhoanDatum>();
//                using (var context = new MyDBContext())
//                {
//                    var query = (from tk in context.WebTaiKhoanData
//                                 where tk.Id == id
//                                 select new WebTaiKhoanDatum
//                                 {
//                                     Id = tk.Id,
//                                     Username = tk.Username,
//                                     Password = tk.Password,
//                                     HoTen = tk.HoTen,
//                                     GioiTinh = tk.GioiTinh,
//                                     DiaChi = tk.DiaChi,
//                                     SoDienThoai = tk.SoDienThoai,
//                                     Email = tk.Email,
//                                     IsAdmin = tk.IsAdmin,
//                                     CreatedTime = tk.CreatedTime,
//                                     CreatedBy = tk.CreatedBy,
//                                 }).ToList();
//                    resultList = (List<WebTaiKhoanDatum>)query.Select(item => new WebTaiKhoanDatum
//                    {
//                        Id = item.Id,
//                        Username = item.Username,
//                        Password = item.Password,
//                        HoTen = item.HoTen,
//                        GioiTinh = item.GioiTinh,
//                        DiaChi = item.DiaChi,
//                        SoDienThoai = item.SoDienThoai,
//                        Email = item.Email,
//                        IsAdmin = item.IsAdmin,
//                        CreatedTime = item.CreatedTime,
//                        CreatedBy = item.CreatedBy,
//                    }).ToList();
//                    return resultList;
//                }
//            }
//            catch (Exception ex)
//            {
//                return BadRequest($"ERROR: {ex}");
//            }
//        }

//        // POST api/<TaiKhoanController>
//        [HttpPost]
//        public IActionResult Post([FromBody] WebTaiKhoanDatum InputData)
//        {
//            try
//            {
//                using (var context = new MyDBContext())
//                {
//                    var existing = context.WebDoiTacData.Find(InputData.Id);

//                    WebTaiKhoanDatum newData = new WebTaiKhoanDatum()
//                    {
//                        Id = IdGenerator.NewUID,
//                        Username = InputData.Username,
//                        Password = InputData.Password,
//                        HoTen = InputData.HoTen,
//                        GioiTinh = InputData.GioiTinh,
//                        DiaChi = InputData.DiaChi,
//                        SoDienThoai = InputData.SoDienThoai,
//                        Email = InputData.Email,
//                        IsAdmin = InputData.IsAdmin,
//                        CreatedTime = DateTime.Now,
//                        CreatedBy = InputData.CreatedBy,

//                    };
//                    context.WebTaiKhoanData.Add(newData);
//                    context.SaveChanges();

//                    return Ok(newData);
//                }
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);

//            }
//        }

//        // PUT api/<TaiKhoanController>/5
//        [HttpPut("{id}")]
//        public IActionResult Put(long id, [FromBody] WebTaiKhoanDatum InputData)
//        {
//            try
//            {
//                using (var context = new MyDBContext())
//                {
//                    var existing = context.WebTaiKhoanData.Find(id);
//                    if (existing == null)
//                    {
//                        return NotFound();
//                    }

//                    existing.Username = InputData.Username;
//                    existing.Password = InputData.Password;
//                    existing.HoTen = InputData.HoTen;
//                    existing.GioiTinh = InputData.GioiTinh;
//                    existing.DiaChi = InputData.DiaChi;
//                    existing.SoDienThoai = InputData.SoDienThoai;
//                    existing.Email = InputData.Email;
//                    existing.IsAdmin = InputData.IsAdmin;
//                    existing.CreatedBy = InputData.CreatedBy;

//                    context.WebTaiKhoanData.Update(existing);
//                    context.SaveChanges();

//                    return Ok(existing);
//                }
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);

//            }
//        }

//        // DELETE api/<TaiKhoanController>/5
//        [HttpDelete("{id}")]
//        public IActionResult Delete(long id)
//        {
//            try
//            {
//                using (var context = new MyDBContext())
//                {
//                    var dataBinhLuan = context.WebBinhLuanData
//                            .Where(x => x.Iduser == id).ToList();

//                    var data = context.WebTaiKhoanData.Find(id);

//                    if (data == null)
//                    {
//                        return Ok("data not exist");
//                    }
//                    foreach (WebBinhLuanDatum item in dataBinhLuan)
//                    {
//                        context.Remove(item);
//                    }
//                    context.Remove(data);
//                    context.SaveChanges();
//                    return Ok("data deleted");
//                }
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);
//            }
//        }
//    }
//}