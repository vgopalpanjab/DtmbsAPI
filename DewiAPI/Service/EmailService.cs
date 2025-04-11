using System.Net.Mail;
using System.Net;
using DewiAPI.Models;

namespace DewiAPI.Service
{
    public class EmailService : IEmailService
    {
        public bool SendEmail(Contact email)
        {
                try
                {
                    var fromAddress = new MailAddress("dtmpvtltdbs@gmail.com", "Dtmbs");
                    var toAddress = new MailAddress(email.EmailId,email.Name);
                    MailMessage usermessage = new MailMessage(fromAddress, toAddress)
                    {
                        Subject = "Conformation mail",
                        Body = "Hi " + email.Name + "<br><br>Thanks for your infomation we will reach you soon<br><br>Regards<br><br> DTM Pvt. Ltd.",
                        IsBodyHtml = true
                    };
                    MailMessage adminmessage = new MailMessage(fromAddress, fromAddress)
                    {
                        Subject = email.Subject,
                        Body = "Hi Admin,<br><br><b>User Name: </b>"+email.Name+"<br><b>User Email Id: </b>" + email.EmailId+"<br><b>User Phone Number: </b>"+email.PhoneNumber+"<br><b>User Message: </b>"+email.Message,
                        IsBodyHtml = true
                    };
                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        Timeout = 2000000,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential("dtmpvtltdbs@gmail.com", "cjnofjqgwbglgwnm")
                    };

                    smtp.Send(adminmessage);
                    smtp.Send(usermessage);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            
        }
    }
}
