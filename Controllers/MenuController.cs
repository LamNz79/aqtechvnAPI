using AQapi.Models;
using AQapi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AQapi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IAuthService _auth;
        public MenuController(IAuthService auth)
        {
            this._auth = auth;
        }
        //// GET: api/<MenuController>
        //[HttpGet]
        //public List<Menu> Get()
        //{
        //    List<Menu> resultList = new List<Menu>();
        //    using (var context = new MyDBContext())
        //    {
        //        var query = (from menu in context.Menus
        //                     select new Menu
        //                     {
        //                         Id = menu.Id,
        //                         Stt = menu.Stt,
        //                         TieuDe = menu.TieuDe,
        //                         TenMenu = menu.TenMenu,
        //                         TenMenuTa = menu.TenMenuTa,
        //                         HienThi = menu.HienThi,
        //                         Link = menu.Link,
        //                         IdCha = menu.IdCha,
        //                     }).OrderByDescending(f => f.Stt).ToList();
        //        resultList = query.Select(item => new Menu
        //        {
        //            Id = item.Id,
        //            Stt = item.Stt,
        //            TieuDe = item.TieuDe,
        //            TenMenu = item.TenMenu,
        //            TenMenuTa = item.TenMenuTa,
        //            HienThi = item.HienThi,
        //            Link = item.Link,
        //            IdCha = item.IdCha,

        //        }).OrderByDescending(f => f.Stt).ToList();
        //        return resultList;
        //    }
        //}
        [HttpGet]
        public IEnumerable<dynamic> Get()
        {
            using (var context = new MyDBContext())
            {
                var menuItems = context.Menus.ToList();
                return BuildMenuTree(menuItems, null);
            }
        }

        private IEnumerable<dynamic> BuildMenuTree(List<Menu> menuItems, long? parentId)
        {
            var menus = new List<dynamic>();

            foreach (var menu in menuItems.Where(m => m.IdCha == parentId).OrderByDescending(m => m.Stt))
            {
                dynamic menuItem = new ExpandoObject();
                menuItem.id = menu.Id;
                menuItem.stt = menu.Stt;
                menuItem.menu = menu.TenMenu;
                menuItem.menu_ta = menu.TenMenuTa;
                menuItem.url = menu.Link;
                menuItem.isHienThi = menu.HienThi;
                menuItem.isAdmin = menu.IsAdmin;
                menuItem.menu_con = BuildMenuTree(menuItems, menu.Id);

                menus.Add(menuItem);
            }

            return menus;
        }

        // POST api/<MenuController>
        [HttpPost]
        public IActionResult Post([FromBody] Menu inputData)
        {
            if (_auth.ValidateAdmin(this))
            {
                try
                {
                    using (var context = new MyDBContext())
                    {
                        var existing = context.ThongTinTrangChus.Find(inputData.Id);
                        if (existing != null)
                        {
                            return Ok("data exist");
                        }
                        Menu newData = new Menu()
                        {
                            Id = IdGenerator.NewUID,
                            Stt = inputData.Stt,
                            TieuDe = inputData.TieuDe,
                            TenMenu = inputData.TenMenu,
                            TenMenuTa = inputData.TenMenuTa,
                            HienThi = inputData.HienThi,
                            Link = inputData.Link,
                            IdCha = inputData.IdCha,
                            IsAdmin = inputData.IsAdmin

                        };
                        context.Menus.Add(newData);
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

        // PUT api/<MenuController>/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Menu inputData)
        {
            if (_auth.ValidateAdmin(this))
            {
                try
                {
                    using (var context = new MyDBContext())
                    {
                        var existing = context.Menus.Find(id);
                        if (existing == null)
                        {
                            return NotFound();
                        }
                        existing.Stt = inputData.Stt;
                        existing.TieuDe = inputData.TieuDe;
                        existing.TenMenu = inputData.TenMenu;
                        existing.TenMenuTa = inputData.TenMenuTa;
                        existing.HienThi = inputData.HienThi;
                        existing.Link = inputData.Link;
                        existing.IdCha = inputData.IdCha;
                        existing.IsAdmin = inputData.IsAdmin;

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

        // DELETE api/<MenuController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            if (_auth.ValidateAdmin(this))
            {
                try
                {
                    using (var context = new MyDBContext())
                    {
                        var data = context.Menus.Find(id);
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