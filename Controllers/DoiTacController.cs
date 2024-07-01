//using AQapi.Models;
//using Microsoft.AspNetCore.Mvc;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace AQapi.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class DoiTacController : ControllerBase
//    {
//        // GET: api/<DoiTacController>
//        [HttpGet("/api/KhachHangVaDoiTac")]
//        public List<WebDoiTacDatum> Get()
//        {
//            List<WebDoiTacDatum> resultList = new List<WebDoiTacDatum>();
//            using (var context = new MyDBContext())
//            {
//                var query = (from hd in context.WebDoiTacData
//                             select new WebDoiTacDatum
//                             {
//                                 Id = hd.Id,
//                                 Loai = hd.Loai,
//                                 TenLoai = hd.TenLoai,
//                                 IsHienThi = hd.IsHienThi,
//                                 DanhMuc = hd.DanhMuc,
//                                 HinhDaiDien = hd.HinhDaiDien,
//                                 NoiDung = hd.NoiDung,
//                                 UrldoiTac = hd.UrldoiTac,
//                                 CreatedTime = hd.CreatedTime,

//                             }).ToList();
//                resultList = (List<WebDoiTacDatum>)query.Select(item => new WebDoiTacDatum
//                {
//                    Id = item.Id,
//                    Loai = item.Loai,
//                    TenLoai = item.TenLoai,
//                    IsHienThi = item.IsHienThi,
//                    DanhMuc = item.DanhMuc,
//                    HinhDaiDien = item.HinhDaiDien,
//                    NoiDung = item.NoiDung,
//                    UrldoiTac = item.UrldoiTac,
//                    CreatedTime = item.CreatedTime,

//                }).ToList();
//            }
//            return resultList;
//        }

//        // GET api/<DoiTacController>/5
//        [HttpGet("{id}")]
//        public ActionResult<List<WebDoiTacDatum>> Get(long id)
//        {
//            try
//            {
//                List<WebDoiTacDatum> resultList = new List<WebDoiTacDatum>();
//                using (var context = new MyDBContext())
//                {
//                    var query = (from hd in context.WebDoiTacData
//                                 where hd.Id == id
//                                 select new WebDoiTacDatum
//                                 {
//                                     Id = hd.Id,
//                                     Loai = hd.Loai,
//                                     TenLoai = hd.TenLoai,
//                                     IsHienThi = hd.IsHienThi,
//                                     DanhMuc = hd.DanhMuc,
//                                     HinhDaiDien = hd.HinhDaiDien,
//                                     NoiDung = hd.NoiDung,
//                                     UrldoiTac = hd.UrldoiTac,
//                                     CreatedTime = hd.CreatedTime,

//                                 }).ToList();
//                    resultList = (List<WebDoiTacDatum>)query.Select(item => new WebDoiTacDatum
//                    {
//                        Id = item.Id,
//                        Loai = item.Loai,
//                        TenLoai = item.TenLoai,
//                        IsHienThi = item.IsHienThi,
//                        DanhMuc = item.DanhMuc,
//                        HinhDaiDien = item.HinhDaiDien,
//                        NoiDung = item.NoiDung,
//                        UrldoiTac = item.UrldoiTac,
//                        CreatedTime = item.CreatedTime,

//                    }).ToList();
//                    return resultList;
//                }
//            }
//            catch (Exception ex)
//            {
//                return BadRequest($"ERROR: {ex}");
//            }
//        }

//        // GET api/<DoiTacController>/5
//        [HttpGet("/api/DoiTac/")]
//        public ActionResult<List<WebDoiTacDatum>> GetByLoaiDoiTac()
//        {
//            try
//            {
//                List<WebDoiTacDatum> resultList = new List<WebDoiTacDatum>();
//                using (var context = new MyDBContext())
//                {
//                    var query = (from hd in context.WebDoiTacData
//                                 where hd.Loai == 1
//                                 select new WebDoiTacDatum
//                                 {
//                                     Id = hd.Id,
//                                     Loai = hd.Loai,
//                                     TenLoai = hd.TenLoai,
//                                     IsHienThi = hd.IsHienThi,
//                                     DanhMuc = hd.DanhMuc,
//                                     HinhDaiDien = hd.HinhDaiDien,
//                                     NoiDung = hd.NoiDung,
//                                     UrldoiTac = hd.UrldoiTac,
//                                     CreatedTime = hd.CreatedTime,

//                                 }).ToList();
//                    resultList = (List<WebDoiTacDatum>)query.Select(item => new WebDoiTacDatum
//                    {
//                        Id = item.Id,
//                        Loai = item.Loai,
//                        TenLoai = item.TenLoai,
//                        IsHienThi = item.IsHienThi,
//                        DanhMuc = item.DanhMuc,
//                        HinhDaiDien = item.HinhDaiDien,
//                        NoiDung = item.NoiDung,
//                        UrldoiTac = item.UrldoiTac,
//                        CreatedTime = item.CreatedTime,

//                    }).ToList();
//                    return resultList;
//                }
//            }
//            catch (Exception ex)
//            {
//                return BadRequest($"ERROR: {ex}");
//            }
//        }

//        [HttpGet("/api/KhachHang/")]
//        public ActionResult<List<WebDoiTacDatum>> GetByLoaiKhachHang()
//        {
//            try
//            {
//                List<WebDoiTacDatum> resultList = new List<WebDoiTacDatum>();
//                using (var context = new MyDBContext())
//                {
//                    var query = (from hd in context.WebDoiTacData
//                                 where hd.Loai == 2
//                                 select new WebDoiTacDatum
//                                 {
//                                     Id = hd.Id,
//                                     Loai = hd.Loai,
//                                     TenLoai = hd.TenLoai,
//                                     IsHienThi = hd.IsHienThi,
//                                     DanhMuc = hd.DanhMuc,
//                                     HinhDaiDien = hd.HinhDaiDien,
//                                     NoiDung = hd.NoiDung,
//                                     UrldoiTac = hd.UrldoiTac,
//                                     CreatedTime = hd.CreatedTime,

//                                 }).ToList();
//                    resultList = (List<WebDoiTacDatum>)query.Select(item => new WebDoiTacDatum
//                    {
//                        Id = item.Id,
//                        Loai = item.Loai,
//                        TenLoai = item.TenLoai,
//                        IsHienThi = item.IsHienThi,
//                        DanhMuc = item.DanhMuc,
//                        HinhDaiDien = item.HinhDaiDien,
//                        NoiDung = item.NoiDung,
//                        UrldoiTac = item.UrldoiTac,
//                        CreatedTime = item.CreatedTime,

//                    }).ToList();
//                    return resultList;
//                }
//            }
//            catch (Exception ex)
//            {
//                return BadRequest($"ERROR: {ex}");
//            }
//        }

//        // POST api/<DoiTacController>
//        [HttpPost]
//        public IActionResult Post([FromBody] WebDoiTacDatum InputData)
//        {
//            try
//            {
//                using (var context = new MyDBContext())
//                {
//                    var existing = context.WebDoiTacData.Find(InputData.Id);
//                    if (existing != null)
//                    {
//                        return Ok("data exist");
//                    }
//                    WebDoiTacDatum newData = new WebDoiTacDatum()
//                    {
//                        Id = IdGenerator.NewUID,
//                        Loai = InputData.Loai,
//                        TenLoai = InputData.TenLoai,
//                        IsHienThi = InputData.IsHienThi,
//                        DanhMuc = InputData.DanhMuc,
//                        HinhDaiDien = InputData.HinhDaiDien,
//                        NoiDung = InputData.NoiDung,
//                        UrldoiTac = InputData.UrldoiTac,
//                        CreatedTime = DateTime.Now,

//                    };
//                    context.WebDoiTacData.Add(newData);
//                    context.SaveChanges();

//                    return Ok(newData);
//                }
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);

//            }
//        }

//        // PUT api/<DoiTacController>/5
//        [HttpPut("{id}")]
//        public IActionResult Put(long id, [FromBody] WebDoiTacDatum InputData)
//        {
//            try
//            {
//                using (var context = new MyDBContext())
//                {
//                    var existing = context.WebDoiTacData.Find(id);
//                    if (existing == null)
//                    {
//                        return NotFound();
//                    }

//                    existing.Loai = InputData.Loai;
//                    existing.TenLoai = InputData.TenLoai;
//                    existing.IsHienThi = InputData.IsHienThi;
//                    existing.DanhMuc = InputData.DanhMuc;
//                    existing.HinhDaiDien = InputData.HinhDaiDien;
//                    existing.NoiDung = InputData.NoiDung;
//                    existing.UrldoiTac = InputData.UrldoiTac;

//                    context.WebDoiTacData.Update(existing);
//                    context.SaveChanges();

//                    return Ok(existing);
//                }
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);

//            }
//        }

//        // DELETE api/<DoiTacController>/5
//        [HttpDelete("{id}")]
//        public IActionResult Delete(long id)
//        {
//            try
//            {
//                using (var context = new MyDBContext())
//                {
//                    var data = context.WebDoiTacData.Find(id);
//                    if (data == null)
//                    {
//                        return Ok("data not exist");
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