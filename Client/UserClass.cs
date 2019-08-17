using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class User
    {
        public string id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string DateOfB { get; set; }
    }
    public class logininfo
    {
        public string username { get; set; }
        public string password { get; set; }
        public string access { get; set; }
    }
}
