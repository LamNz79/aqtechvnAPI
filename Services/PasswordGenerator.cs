using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;

namespace AQapiDev.Services
{
    public class PasswordGenerator
    {
        public static string HashPassword(string pwd)
        {
            if (string.IsNullOrEmpty(pwd)) return "";
            SHA256 sha = new SHA256Managed();
            var pwdBuff = Encoding.ASCII.GetBytes(pwd);
            var hashedPwd = sha.TransformFinalBlock(pwdBuff, 0, pwdBuff.Length);
            var hash = new StringBuilder();
            foreach (var b in sha.Hash)
            {
                hash.Append(string.Format("{0:x2}", b));
            }
            sha.Clear();
            return hash.ToString();
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            // Hash input password
            string hashedInput = HashPassword(password);
            // Compare hashed input to stored hash
            if (hashedInput == hashedPassword)
            {
                return true;
            }
            return false;

        }
        public static string GenerateVerificationCode()
        {
            var random = new Random();
            return random.Next(100000, 999999).ToString();
        }
        public static bool SendVerificationPaaword(string email, string code)
        {
            MailMessage mail = new MailMessage();

            mail.From = new MailAddress("automatedaqhub@gmail.com");
            mail.To.Add(email);
            mail.Subject = "AutomatedQA Hub Request Code";
            /*            mail.Body = $"Your verification code is: {code} - AutomatedQA Team";*/

            string htmlBody = @"
<div
        style='justify-content: center; align-items: center; width: 90%;  height: 90%; margin: auto; position: absolute; top: 0; bottom: 0; left: 0; right: 0;'>
        <img src='https://res.cloudinary.com/drhcszyj0/image/upload/v1702707751/Screenshot_2023-12-16_at_13.13.29_aapodx.png'
            style='max-width: 250px; height: auto; text-align: center;' />
        <div style='width: 100%; justify-content: center; align-items: center; border-radius: 10px;'>
            <div style='display: flex; align-items: center;'>
                <h1 style='flex-grow: 1; flex-shrink: 1; text-align: center; margin-top: 10px; font-size: 35px; color: #2c2c2c; margin: 0 auto;'>Reset your AutomatedQA Hub password</h1>
            </div>
            <div style='margin: 10px; font-size: 18px; color: #000000;'>
                <p>Reset your AutomatedQA Hub password</p>
                <p>Greetings " + email + @"</p>
                <p>We've heard that you've lost your AutomatedQA Hub Center password. We are very sorry for that!</p>
                <p>But don't worry! You can use the following code to reset your password:</p>
            </div>
            <div
                style='font-size: 2em; background: #565454; margin: 1em auto; color: #ffffff; text-align: center; padding: 0.5em 1em; border: solid 1px #ffffff; border-radius: 5px; letter-spacing: 0.3em; width: 70%; max-width: 400px;'>
                " + code + @"</div>
            <div style='margin: 10px; font-size: 18px; margin-bottom: 20px;
                color: #555;'>If you do not use this code link within 30 minutes, it will expire.
                <p>Thanks,</p>
                <p>The AutomatedQA Team</p>
            </div>
        </div>
    </div>
            ";

            mail.Body = htmlBody;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.UseDefaultCredentials = true;

            smtp.Credentials = new NetworkCredential("plam84524@gmail.com", "Lamlun@123");
            smtp.EnableSsl = true;

            try
            {
                smtp.Send(mail);
                Console.WriteLine("Email sent!");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to send email: " + ex.Message);
                return false;
            }
        }
    }
}

