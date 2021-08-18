using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace AnimalWatchersUnited2
{
    public class Login
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        public Login()
        {
            this.Id = Id;
            this.Username = Username;
            this.Password = Password;
            this.Firstname = Firstname;
            this.Surname = Surname;
            this.Email = Email;
        }
    }
}
