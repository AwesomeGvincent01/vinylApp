using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vinylApp.Model
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

        public User(int userId, string username, string password, bool isAdmin)
        {
            UserID = userId;
            Username = username;
            Password = password;
            IsAdmin = isAdmin;
        }
    }
}