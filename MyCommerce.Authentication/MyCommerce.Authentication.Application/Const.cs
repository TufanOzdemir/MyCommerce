namespace MyCommerce.Authentication.Application
{
    public struct Consts
    {
        public const string ApplicationLevelClaimType = "ApplicationLevel";
        public const string UserLevelClaimType = "UserLevel";
        public const string SecurityLevelClaimType = "SecurityLevel";
    }
    public enum SecurityLevel
    {
        Application = 0,
        UserAndApplication = 1
    }
}