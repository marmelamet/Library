using Library.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace Library.Web.InfraStructure
{
    public class LibraryPrinciple: IPrincipal
    {
        public LibraryPrinciple(IIdentity _identity, Kullanicilar _userData)
        {
            Identity = _identity;
            userData = _userData;
        }
        public Kullanicilar userData { get; set; }
        public IIdentity Identity
        {
            get; private set;
        }

        public bool IsInRole(string role)
        {
            List<string> roller = role.Split(',').ToList();
            return role.Contains(userData.Roller.rolAdi);
        }
    }
}