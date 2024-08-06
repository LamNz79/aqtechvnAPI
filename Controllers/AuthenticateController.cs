using AQapiDev.Models;
using AQapiDev.Models.CustomModels;
using AQapiDev.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AQapiDev.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {

        // GET: api/<AuthenticateController>
        [HttpGet]
        public List<UserStateModel> Get()
        {
            using (var context = new MyDBContext())
            {
                List<UserStateModel> resultList = new List<UserStateModel>();
                var query = (from lg in context.LogOns
                             select new UserStateModel
                             {
                                 Id = lg.Id,
                                 UserName = lg.UserName,
                                 Active = lg.Active,
                             }).ToList();
                resultList = query.Select(item => new UserStateModel
                {
                    Id = item.Id,
                    UserName = item.UserName,
                    Active = item.Active,
                }).ToList();
                return resultList;
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] LogOn InputData)
        {
            try
            {
                using (var context = new MyDBContext())
                {
                    LogOn newData = new LogOn()
                    {
                        Id = IdGenerator.NewUID,
                        UserName = InputData.UserName,
                        Password = PasswordGenerator.HashPassword(InputData.Password),
                        Active = InputData.Active,
                    };
                    context.LogOns.Add(newData);
                    context.SaveChanges();

                    return Ok(newData);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<AuthenticateController>
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            using (var context = new MyDBContext())
            {
                var user = context.LogOns.FirstOrDefault(u => u.UserName == model.Username);
                if (user == null)
                    return BadRequest("Invalid username");
                if (!PasswordGenerator.VerifyPassword(model.Password, user.Password))
                    return BadRequest("Invalid password");
                if (user.Active == false)
                    return BadRequest(user);
                LoginModel temp = new LoginModel();
                temp.Id = user.Id;
                temp.Username = user.UserName;
                temp.Password = null;
                //HttpContext.Session.SetString("Username", temp.Username);
                try
                {
                    HttpContext.Session.SetString("Username", temp.Username);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error setting session: {ex.Message}");
                }
                HttpContext.Session.SetString("UserId", temp.Id.ToString());
                Console.WriteLine(HttpContext.Session.GetString("Username"));

                // Return OK if credentials are valid
                return Ok(temp);
            }
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPasswordRequest([FromBody] LoginWithEmailModel data)
        {
            using (var context = new MyDBContext())
            {
                // Check verification code user input with verification code in database
                var user = context.LogOns.FirstOrDefault(u => u.UserName == data.Username);
                if (user == null)
                    return BadRequest("Invalid username");
                string verifyCode = PasswordGenerator.GenerateVerificationCode();
                PasswordGenerator.SendVerificationPaaword(data.Email, verifyCode);
                //user.VerificationCode = PasswordGenerator.HashPassword(verifyCode);
                user.VerificationCode = verifyCode;

                await context.SaveChangesAsync();
                // Return user ID in the response
                return Ok(new { Message = "We are send code to your email", UserId = user.Id });
            }
        }

        // PUT api/authenticate/changepassword
        [HttpPost("changepassword")]
        public IActionResult ChangePassword([FromBody] changePasswordModel model)
        {

            using (var context = new MyDBContext())
            {
                string name = "admin";
                var user = context.LogOns.FirstOrDefault(u => u.UserName == name);

                if (!PasswordGenerator.VerifyPassword(model.OldPass, user.Password))
                {
                    return new OkObjectResult(new
                    {
                        code = 500,
                        mess = "Incorrect current password"
                    });
                }
                if (user.Active == false)
                {
                    return new OkObjectResult(new
                    {
                        code = 500,
                        mess = "User is not active"
                    });
                }
                user.Password = PasswordGenerator.HashPassword(model.Password);
                model.Password = PasswordGenerator.HashPassword(model.Password);
                model.OldPass = PasswordGenerator.HashPassword(model.OldPass);
                context.SaveChanges();


                return new OkObjectResult(new
                {
                    code = 200,
                    mess = "password updated"
                });
            }
        }


        [HttpPut("submitCode")]
        public IActionResult submitCode([FromBody] UserAndVerificationCodeModel data)
        {
            using (var context = new MyDBContext())
            {
                var user = context.LogOns.FirstOrDefault(u => u.UserName == data.Username);

                if (user == null || user.UserName != data.Username)
                    return BadRequest("Invalid username");
                if (!PasswordGenerator.VerifyPassword(data.Code, user.VerificationCode))
                    return BadRequest("Incorrect current password");
                if (user.Active == false)
                    return BadRequest(user);
                user.Password = PasswordGenerator.HashPassword(data.newPassword);
                data.newPassword = PasswordGenerator.HashPassword(data.newPassword);

                context.SaveChanges();

                return Ok(data);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            try
            {
                using (var context = new MyDBContext())
                {
                    var data = context.LogOns.Find(id);
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
    }
}