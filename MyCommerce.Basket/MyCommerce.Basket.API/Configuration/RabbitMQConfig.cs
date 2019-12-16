using System;

namespace MyCommerce.Basket.API.Configuration
{
    public class RabbitMQConfig : BaseConfig
    {
        public Uri Host { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public override string ConfigSection { get => "RabbitMQ"; }
    }
}
