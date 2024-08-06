using AQapiDev.Models;
using AQapiDev.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AQapiDev.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YkienDanhGiaController : ControllerBase
    {
        private readonly IAuthService _auth;
        public YkienDanhGiaController(IAuthService auth)
        {
            this._auth = auth;
        }
        // GET: api/<YkienDanhGiumController>
        [HttpGet]
        public ActionResult<List<YkienDanhGium>> Get()
        {

            List<YkienDanhGium> resultList = new List<YkienDanhGium>();
            using (var context = new MyDBContext())
            {
                var query = (from yk in context.YkienDanhGia
                             select new YkienDanhGium
                             {
                                 Id = yk.Id,
                                 HoTen = yk.HoTen,
                                 ChucVu = yk.ChucVu,
                                 MucDanhGia = yk.MucDanhGia,
                                 NoiDung = yk.NoiDung,
                                 Ngay = yk.Ngay,
                                 IsHienThiTrangChu = yk.IsHienThiTrangChu,
                                 DonVi = yk.DonVi,
                                 TomTat = yk.TomTat,
                                 TomTatTa = yk.TomTatTa,
                                 NoiDungTa = yk.NoiDungTa

                             }).ToList();
                resultList = query.Select(item => new YkienDanhGium
                {
                    Id = item.Id,
                    HoTen = item.HoTen,
                    ChucVu = item.ChucVu,
                    MucDanhGia = item.MucDanhGia,
                    NoiDung = item.NoiDung,
                    Ngay = item.Ngay,
                    IsHienThiTrangChu = item.IsHienThiTrangChu,
                    DonVi = item.DonVi,
                    TomTat = item.TomTat,
                    TomTatTa = item.TomTatTa,
                    NoiDungTa = item.NoiDungTa
                }).ToList();
                return resultList;
            }
        }

        // GET: api/<YkienDanhGiumController>
        [HttpGet("filter")]
        public ActionResult<List<YkienDanhGium>> GetByFilter()
        {
            List<YkienDanhGium> resultList = new List<YkienDanhGium>();
            using (var context = new MyDBContext())
            {
                var query = (from yk in context.YkienDanhGia
                             where yk.IsHienThiTrangChu == true
                             select new YkienDanhGium
                             {
                                 Id = yk.Id,
                                 HoTen = yk.HoTen,
                                 ChucVu = yk.ChucVu,
                                 MucDanhGia = yk.MucDanhGia,
                                 NoiDung = yk.NoiDung,
                                 Ngay = yk.Ngay,
                                 IsHienThiTrangChu = yk.IsHienThiTrangChu,
                                 DonVi = yk.DonVi,
                                 TomTat = yk.TomTat,
                                 TomTatTa = yk.TomTatTa,
                                 NoiDungTa = yk.NoiDungTa

                             }).ToList();
                resultList = query.Select(item => new YkienDanhGium
                {
                    Id = item.Id,
                    HoTen = item.HoTen,
                    ChucVu = item.ChucVu,
                    MucDanhGia = item.MucDanhGia,
                    NoiDung = item.NoiDung,
                    Ngay = item.Ngay,
                    IsHienThiTrangChu = item.IsHienThiTrangChu,
                    DonVi = item.DonVi,
                    TomTat = item.TomTat,
                    TomTatTa = item.TomTatTa,
                    NoiDungTa = item.NoiDungTa

                }).ToList();
                return resultList;
            }
        }

        // GET api/<YkienDanhGiumController>/5
        [HttpGet("{id}")]
        public ActionResult<List<YkienDanhGium>> Get(long id)
        {
            List<YkienDanhGium> resultList = new List<YkienDanhGium>();
            using (var context = new MyDBContext())
            {
                var query = (from yk in context.YkienDanhGia
                             where yk.Id == id
                             select new YkienDanhGium
                             {
                                 Id = yk.Id,
                                 HoTen = yk.HoTen,
                                 ChucVu = yk.ChucVu,
                                 MucDanhGia = yk.MucDanhGia,
                                 NoiDung = yk.NoiDung,
                                 Ngay = yk.Ngay,
                                 IsHienThiTrangChu = yk.IsHienThiTrangChu,
                                 DonVi = yk.DonVi,
                                 TomTat = yk.TomTat,
                                 TomTatTa = yk.TomTatTa,
                                 NoiDungTa = yk.NoiDungTa

                             }).ToList();
                resultList = query.Select(item => new YkienDanhGium
                {
                    Id = item.Id,
                    HoTen = item.HoTen,
                    ChucVu = item.ChucVu,
                    MucDanhGia = item.MucDanhGia,
                    NoiDung = item.NoiDung,
                    Ngay = item.Ngay,
                    IsHienThiTrangChu = item.IsHienThiTrangChu,
                    DonVi = item.DonVi,
                    TomTat = item.TomTat,
                    TomTatTa = item.TomTatTa,
                    NoiDungTa = item.NoiDungTa

                }).ToList();
                return resultList;
            }
        }

        // POST api/<YkienDanhGiumController>
        [HttpPost]
        public IActionResult Post([FromBody] YkienDanhGium inputData)
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
                        YkienDanhGium newData = new YkienDanhGium()
                        {
                            Id = IdGenerator.NewUID,
                            HoTen = inputData.HoTen,
                            ChucVu = inputData.ChucVu,
                            MucDanhGia = inputData.MucDanhGia,
                            NoiDung = inputData.NoiDung,
                            Ngay = DateTime.Now,
                            IsHienThiTrangChu = inputData.IsHienThiTrangChu,
                            DonVi = inputData.DonVi,
                            TomTat = inputData.TomTat,
                            TomTatTa = inputData.TomTatTa,
                            NoiDungTa = inputData.NoiDungTa
                        };
                        context.YkienDanhGia.Add(newData);
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




        // PUT api/<YkienDanhGiumController>/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] YkienDanhGium inputData)
        {
            if (_auth.ValidateAdmin(this))
            {
                try
                {
                    using (var context = new MyDBContext())
                    {
                        var existing = context.YkienDanhGia.Find(id);

                        if (existing == null)
                        {
                            return NotFound();
                        }

                        // Update other properties
                        existing.HoTen = inputData.HoTen;
                        existing.ChucVu = inputData.ChucVu;
                        existing.MucDanhGia = inputData.MucDanhGia;
                        existing.NoiDung = inputData.NoiDung;
                        existing.IsHienThiTrangChu = inputData.IsHienThiTrangChu;
                        existing.DonVi = inputData.DonVi;
                        existing.TomTat = inputData.TomTat;
                        existing.TomTatTa = inputData.TomTatTa;
                        existing.NoiDungTa = inputData.NoiDungTa;
                        context.YkienDanhGia.Update(existing);
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

        // DELETE api/<YkienDanhGiumController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            if (_auth.ValidateAdmin(this))
            {
                try
                {
                    using (var context = new MyDBContext())
                    {
                        var data = context.YkienDanhGia.Find(id);
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