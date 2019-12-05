using System.Collections.Generic;

namespace MyCommerce.Authentication.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public List<UserPermission> Permissions { get; set; }
    }
}