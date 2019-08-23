using System;

namespace Library.Web.Controllers
{
    internal class LoginControlAttribute : Attribute
    {
        public string Roles { get; set; }
    }
}