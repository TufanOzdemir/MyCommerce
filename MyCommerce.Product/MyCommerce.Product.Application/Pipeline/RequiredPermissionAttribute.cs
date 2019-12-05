using System;

namespace MyCommerce.Product.Application.Pipeline
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public sealed class RequiredPermissionAttribute : Attribute
    {
        public Permission RequiredPermission { get; private set; }
        public RequiredPermissionAttribute(string permissionDescription)
        {

            if (string.IsNullOrWhiteSpace(permissionDescription))
                return;

            RequiredPermission = new Permission(permissionDescription);
        }
    }
}