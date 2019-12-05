using MyCommerce.Authentication.Domain;
using System.Collections.Generic;

namespace MyCommerce.Authentication.Infrastructure.Data
{
    internal class FakeDB
    {
        public static FakeDB Instance = new FakeDB();
        public List<User> Users;

        private FakeDB()
        {
            Users = new List<User>()
            {
                new User
                {
                    Id = 1,
                    Name = "Tufan",
                    Password = "Ab123!",
                    UserName = "tfn",
                    Permissions = new List<UserPermission>()
                    {
                        new UserPermission
                        {
                            PermissionCode = "ProductRead"
                        },
                        new UserPermission
                        {
                            PermissionCode = "KategoriSorgulama"
                        }
                    }
                }
            };
        }
    }
}
