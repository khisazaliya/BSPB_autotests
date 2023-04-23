using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSPB_autotests.Models
{
    public class UserData
    {
        public UserData(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public UserData()
        {

        }
        public string Username { get; set; }

        public string Password { get; set; }
    }
}