//using AQapiDev.Models;
//using Microsoft.AspNetCore.Mvc;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace AQapiDev.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class SanPhamController : ControllerBase
//    {
//        // GET: api/<SanPhamController>
//        [HttpGet]
//        public List<WebSanPhamDatum> Get()
//        {
//            List<WebSanPhamDatum> resultList = new List<WebSanPhamDatum>();
//            using (var context = new MyDBContext())
//            {
//                var query = (from hd in context.WebSanPhamData
//                             select new WebSanPhamDatum
//                             {
//                                 Id = hd.Id,
//                                 HinhDaiDien = hd.HinhDaiDien,
//                                 TenDanhMuc = hd.TenDanhMuc,
//                                 IsNoiBat = hd.IsNoiBat,
//                                 IsHienThi = hd.IsHienThi,
//                                 NoiDung = hd.NoiDung,
//                                 CreatedTime = hd.CreatedTime,
//                                 CreatedBy = hd.CreatedBy,
//                             }).ToList();
//                resultList = (List<WebSanPhamDatum>)query.Select(item => new WebSanPhamDatum
//                {
//                    Id = item.Id,
//                    IsHienThi = item.IsHienThi,
//                    HinhDaiDien = item.HinhDaiDien,
//                    TenDanhMuc = item.TenDanhMuc,
//                    IsNoiBat = item.IsNoiBat,
//                    NoiDung = item.NoiDung,
//                    CreatedTime = item.CreatedTime,
//                    CreatedBy = item.CreatedBy,
//                }).ToList();
//            }
//            return resultList;
//        }

//        // GET api/<SanPhamController>/5
//        [HttpGet("{id}")]
//        public ActionResult<List<WebSanPhamDatum>> Get(long id)
//        {
//            try
//            {
//                List<WebSanPhamDatum> resultList = new List<WebSanPhamDatum>();
//                using (var context = new MyDBContext())
//                {
//                    var query = (from hd in context.WebSanPhamData
//                                 where hd.Id == id
//                                 select new WebSanPhamDatum
//                                 {
//                                     Id = hd.Id,
//                                     HinhDaiDien = hd.HinhDaiDien,
//                                     TenDanhMuc = hd.TenDanhMuc,
//                                     IsNoiBat = hd.IsNoiBat,
//                                     IsHienThi = hd.IsHienThi,
//                                     NoiDung = hd.NoiDung,
//                                     CreatedTime = hd.CreatedTime,
//                                     CreatedBy = hd.CreatedBy,

//                                 }).ToList();
//                    resultList = (List<WebSanPhamDatum>)query.Select(item => new WebSanPhamDatum
//                    {
//                        Id = item.Id,
//                        HinhDaiDien = item.HinhDaiDien,
//                        TenDanhMuc = item.TenDanhMuc,
//                        IsHienThi = item.IsHienThi,
//                        IsNoiBat = item.IsNoiBat,
//                        NoiDung = item.NoiDung,
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

//        // POST api/<SanPhamController>
//        [HttpPost]
//        public IActionResult Post([FromBody] WebSanPhamDatum InputData)
//        {
//            try
//            {
//                using (var context = new MyDBContext())
//                {
//                    var existing = context.WebSanPhamData.Find(InputData.Id);

//                    WebSanPhamDatum newData = new WebSanPhamDatum()
//                    {
//                        Id = IdGenerator.NewUID,
//                        HinhDaiDien = InputData.HinhDaiDien,
//                        TenDanhMuc = InputData.TenDanhMuc,
//                        IsHienThi = InputData.IsHienThi,
//                        IsNoiBat = InputData.IsNoiBat,
//                        NoiDung = InputData.NoiDung,
//                        CreatedTime = DateTime.Now,
//                        CreatedBy = InputData.CreatedBy,

//                    };
//                    context.WebSanPhamData.Add(newData);
//                    context.SaveChanges();

//                    return Ok(newData);
//                }
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);

//            }
//        }

//        // PUT api/<SanPhamController>/5
//        [HttpPut("{id}")]
//        public IActionResult Put(long id, [FromBody] WebSanPhamDatum InputData)
//        {
//            try
//            {
//                using (var context = new MyDBContext())
//                {
//                    var existing = context.WebSanPhamData.Find(id);
//                    if (existing == null)
//                    {
//                        return NotFound();
//                    }

//                    existing.HinhDaiDien = InputData.HinhDaiDien;
//                    existing.TenDanhMuc = InputData.TenDanhMuc;
//                    existing.IsHienThi = InputData.IsHienThi;
//                    existing.IsNoiBat = InputData.IsNoiBat;
//                    existing.NoiDung = InputData.NoiDung;
//                    existing.CreatedBy = InputData.CreatedBy;

//                    context.WebSanPhamData.Update(existing);
//                    context.SaveChanges();

//                    return Ok(existing);
//                }
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);

//            }
//        }

//        // DELETE api/<SanPhamController>/5
//        [HttpDelete("{id}")]
//        public IActionResult Delete(long id)
//        {
//            try
//            {
//                using (var context = new MyDBContext())
//                {
//                    var data = context.WebSanPhamData.Find(id);
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