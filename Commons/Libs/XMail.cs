using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Web;
using System.Web.Configuration;
using Commons.Libs;

namespace Commons.Libs
{
    public class XMail
    {
        public static string SMTPServer = WebConfigurationManager.AppSettings["SMTPServer"].ToString();
        public static int Port = Int32.Parse(WebConfigurationManager.AppSettings["Port"].ToString());
        public static string CredentialUserName = WebConfigurationManager.AppSettings["CredentialUserName"].ToString();
        public static string CredentialPassword = WebConfigurationManager.AppSettings["CredentialPassword"].ToString();
        public static string EnableSsl = "False";
        public static bool ssl = false;
        public static string from = "vnZdeal@gmail.com";

        public static void Send(String to, String subject, String body)
        {

            //Send(from, to, subject, body);
            String cc = "";
            String bcc = "";
            String attachments = "";
            Thread email = new Thread(delegate ()
            {
                SendAsyncEmail(from, to, cc, bcc, subject, body, attachments);
            });
            email.IsBackground = true;
            email.Start();
        }

        /// <summary>
        /// Gửi email đơn giản thông qua tài khoản gmail
        /// </summary>
        /// <param name="from">Email người gửi</param>
        /// <param name="to">Email người nhận</param>
        /// <param name="subject">Tiêu đề mail</param>
        /// <param name="body">Nội dung mail</param>
        public static void Send(String from, String to, String subject, String body)
        {
            String cc = "";
            String bcc = "";
            String attachments = "";

            Thread email = new Thread(delegate ()
            {
                SendAsyncEmail(from, to, cc, bcc, subject, body, attachments);
            });
            email.IsBackground = true;
            email.Start();
        }

        /// <summary>
        /// Gửi email thông qua tài khoản gmail
        /// </summary>
        /// <param name="from">Email người gửi</param>
        /// <param name="to">Email người nhận</param>
        /// <param name="cc">Danh sách email những người cùng nhận phân cách bởi dấu phẩy</param>
        /// <param name="bcc">Danh sách email những người cùng nhận phân cách bởi dấu phẩy</param>
        /// <param name="subject">Tiêu đề mail</param>
        /// <param name="body">Nội dung mail</param>
        /// <param name="attachments">Danh sách file định kèm phân cách bởi phẩy hoặc chấm phẩy</param>
        /// 

        public static void Sends(String from, String to, String cc, String bcc, String subject, String body, String attachments)
        {

            if (EnableSsl == "0" || EnableSsl == "true" || EnableSsl == "True" || EnableSsl == "TRUE")
            {
                ssl = true;
            }
            else
            {
                ssl = false;
            }

            var message = new MailMessage();
            message.IsBodyHtml = true;
            message.From = new MailAddress(from);
            message.To.Add(new MailAddress(to));
            message.Subject = subject;
            message.Body = body;

            message.ReplyToList.Add(from);
            if (cc.Length > 0)
            {
                message.CC.Add(cc);
            }
            if (bcc.Length > 0)
            {
                message.Bcc.Add(bcc);
            }
            if (attachments.Length > 0)
            {
                String[] fileNames = attachments.Split(';', ',');
                foreach (var fileName in fileNames)
                {
                    message.Attachments.Add(new Attachment(fileName));
                }
            }

            // Kết nối GMail
            var client = new SmtpClient(SMTPServer, Port)
            {
                Credentials = new NetworkCredential(CredentialUserName, CredentialPassword),
                EnableSsl = ssl
            };
            // Gởi mail
            client.Send(message);
        }

        public static void Send(String from, String to, String cc, String bcc, String subject, String body, String attachments)
        {

            Thread email = new Thread(delegate ()
            {
                SendAsyncEmail(from, to, cc, bcc, subject, body, attachments);
            });
            email.IsBackground = true;
            email.Start();
        }


        private static void SendAsyncEmail(String from, String to, String CC, String BCC, String subject, String body, String attachments)
        {
            try
            {
                if (EnableSsl == "0" || EnableSsl == "true" || EnableSsl == "True" || EnableSsl == "TRUE")
                {
                    ssl = true;
                }
                else
                {
                    ssl = false;
                }

                MailMessage message = new MailMessage();
                message.From = new MailAddress(from);
                message.Subject = subject;
                message.Body = body;
                message.IsBodyHtml = true;
                message.ReplyToList.Add(from);


                if (to != null)
                {
                    String[] toes = to.Split(';', ',', ' ');
                    foreach (var t in toes)
                    {
                        message.To.Add(new MailAddress(t));
                    }


                }

                if (CC.Length > 0)
                {
                    String[] CCs = CC.Split(';', ',', ' ');
                    foreach (string c in CCs)
                    {
                        message.CC.Add(new MailAddress(c));
                    }
                }

                if (BCC.Length > 0)
                {
                    String[] BCCs = BCC.Split(';', ',', ' ');
                    foreach (string b in BCCs)
                    {
                        message.Bcc.Add(new MailAddress(b));
                    }
                }

                if (attachments.Length > 0)
                {
                    String[] fileNames = attachments.Split(';', ',');
                    foreach (var fileName in fileNames)
                    {
                        message.Attachments.Add(new Attachment(fileName));
                    }
                }

                var client = new SmtpClient(SMTPServer, Port)
                {
                    Credentials = new NetworkCredential(CredentialUserName, CredentialPassword),
                    EnableSsl = ssl
                };

                client.Send(message);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


    }
}