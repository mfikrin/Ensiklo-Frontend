using System;
using System.Collections.Generic;
using System.Text;

namespace ENSIKLO.Models
{
    public class CurrentUser
    {
        public string Token { get; set; }
        public Int64 Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
    }
}
