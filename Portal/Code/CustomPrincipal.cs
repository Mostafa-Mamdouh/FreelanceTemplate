using System.Collections.Generic;
using System.Security.Principal;

namespace Web
{
    interface IUserPrincipal : IPrincipal
    {
        int UserId { get; set; }
        string Name { get; set; }
        string Email { get; set; }
    }

    public class UserPrincipal : IUserPrincipal
    {
        public bool IsInRole(string role)
        {
            return true;
        }

        public IIdentity Identity { get; private set; }

        public UserPrincipal(string email)
        {
            Identity = new GenericIdentity(email);
        }

        public UserPrincipal(UserPrincipalSerializeModel serializeModel)
        {
            Identity = new GenericIdentity(serializeModel.Name);
            UserId = serializeModel.UserId;
            Name = serializeModel.Name;
            Email = serializeModel.Email;
			Type = serializeModel.Type;
            IsAdmin = serializeModel.IsAdmin;
        }

        public int Type { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
    }

    public class UserPrincipalSerializeModel
    {
        public int Type { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }


    }
}