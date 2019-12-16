namespace MyCommerce.Basket.API.Configuration
{
    public interface IConfigResolver
    {
        T Resolve<T>() where T : BaseConfig, new();
    }
}