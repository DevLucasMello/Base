using Core.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Communication
{
    public class EmailService
    {

        public enum Types
        {
            Test = 1
        }

        public static void Send(string name, string email, Types type, List<KeyValuePair<string, string>> fields)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(WebConfigHelper.Get("Email.From"), WebConfigHelper.Get("Email.Name"));
            mail.IsBodyHtml = false;
            mail.To.Add(new MailAddress(email, name));

            Load(mail, type, fields);

            SmtpClient smtp = new SmtpClient();
            smtp.Send(mail);
        }

        public static bool Send(string email, string subject, string body)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(WebConfigHelper.Get("Email.From"), WebConfigHelper.Get("Email.Name"));
            mail.IsBodyHtml = false;
            mail.Subject = subject;
            mail.Body = body;
            mail.To.Add(new MailAddress(email));

            try
            {
                SmtpClient smtp = new SmtpClient();
                smtp.Send(mail);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static void Load(MailMessage mail, Types type, List<KeyValuePair<string, string>> fields)
        {
            string path = WebConfigHelper.Get("Basic.PhysicalPath") + WebConfigHelper.Get("Email.Folder") + type.ToString() + ".html";
            if (File.Exists(path))
            {
                StreamReader reader = new StreamReader(path);
                var subject = reader.ReadLine();
                var body = reader.ReadToEnd();
                foreach (var field in fields)
                {
                    body = body.Replace("[" + field.Key.ToUpper() + "]", field.Value);
                    subject = subject.Replace("[" + field.Key.ToUpper() + "]", field.Value);
                }
                mail.IsBodyHtml = true;
                mail.Subject = subject;
                mail.Body = body;

                reader.Close();
            }
            else
            {
                throw new Exception("File not exists");
            }
        }

    }
}
