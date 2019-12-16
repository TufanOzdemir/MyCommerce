namespace MyCommerce.Basket.API.Configuration
{
    public class AuthenticationConfig : BaseConfig
    {
        public string Secret { get; set; }
        public override string ConfigSection { get => "Authentication"; }
    }
}