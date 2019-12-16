using MassTransit;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MyCommerce.Product.Application.Events
{
    public class AddToBasketEvent : INotification
    {
        public Guid TransactionId { get; set; }
        public Guid CustomerGuid { get; set; }
        public int ProductId { get; set; }
    }

    public class AddToBasketEventHandler : INotificationHandler<AddToBasketEvent>
    {
        private readonly IBusControl _busControl;
        public AddToBasketEventHandler(IBusControl busControl)
        {
            _busControl = busControl;
        }

        public Task Handle(AddToBasketEvent notification, CancellationToken cancellationToken)
        {
            return _busControl.Publish(new AddToBasketEvent { CustomerGuid = notification.CustomerGuid, ProductId = notification.ProductId, TransactionId = Guid.NewGuid() });
        }
    }
}