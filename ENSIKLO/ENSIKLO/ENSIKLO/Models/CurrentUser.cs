using System;
using System.Collections.Generic;
using System.Text;

namespace ENSIKLO.Models
{
    public class CurrentUser
    {
        public static string Token { get; set; }
        public static Int64 Id { get; set; }
        public static string Email { get; set; }
        public static string Username { get; set; }
        public static string Role { get; set; }
    }
}
