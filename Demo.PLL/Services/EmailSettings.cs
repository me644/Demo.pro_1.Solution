using Demo.DAL.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Demo.PLL.Services
{
    public class EmailSettings
    {

        public void Send_Email(Email email)
        {
            var client = new SmtpClient("stmp@gmail.com", 587);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("mk0645408@gmail.com", "urxhcimabvqqfkic");

            client.Send("mk0645408@gmail.com", email.to, email.subject, email.body);



        }
    }
}
