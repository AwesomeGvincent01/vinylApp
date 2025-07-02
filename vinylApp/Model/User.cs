using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vinylApp.Model
{
    public class User
    {
        public int UserID { get; }
        public string Username { get; }
        public string Password { get; }
        public string Role { get; }

        public User(int id, string uname, string pword, string role)
        {
            UserID = id;
            Username = uname;
            Password = pword;
            Role = role;
        }
    }

}