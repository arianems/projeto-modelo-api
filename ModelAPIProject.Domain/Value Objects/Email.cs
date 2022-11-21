using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace TokenAPI.Domain.Value_Objects
{
    public class Email
    {
        public string Address { get; set; } = null!;

        protected Email()
        {

        }

        public Email(string address)
        {
            if(string.IsNullOrEmpty(address) || address.Length < 5)
            {
                throw new Exception("Email inválido.");
            }

           
            if(!MailAddress.TryCreate(address, out var emailValidator))
            {
                throw new Exception("Email inválido.");
            }

            Address = address.Trim().ToLower();
        }
    }
}
