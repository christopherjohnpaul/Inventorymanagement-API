using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace ModelLayer.Utility
{
    public class EmailUtility
    {
        public EmailUtility()
        {
        }
        public static void SendMail(string toAddress, string subject, string body, Stream attachment = null, string attachmentName = null)
        {

            try
            {
                using (MailMessage mail = new())
                {
                    ConfigHelper _configHelper = new ConfigHelper();
                    string sendersAddress = _configHelper.Root.GetSection("AdminEmail:UserName").Value;
                    ////Specify The password of gmial account u are using to sent mail(pw of sender@gmail.com)
                    string sendersPassword = _configHelper.Root.GetSection("AdminEmail:Password").Value;
                    mail.From = new MailAddress(sendersAddress);
                    mail.To.Add(toAddress);
                    mail.CC.Add(sendersAddress);
                    mail.Subject = subject;
                    mail.Body = body;
                    mail.IsBodyHtml = true;

                    if (attachment != null)
                    {
                        Attachment att = new Attachment(attachment, new ContentType(MediaTypeNames.Application.Octet));

                        att.ContentDisposition.FileName = attachmentName;
                        att.ContentDisposition.Size = attachment.Length;

                        mail.Attachments.Add(att);
                    }
                    // mail.Attachments.Add(new Attachment("C:\\file.zip"));

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new NetworkCredential(sendersAddress, sendersPassword);
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

    }
}

