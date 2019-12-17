using MassTransit;
using MediatR;
using MyCommerce.Basket.Application.Commands;
using MyCommerce.Common.Core;
using System.Threading.Tasks;

namespace MyCommerce.Basket.Application.Consumers
{
    public class AddBasketMessageConsumer : IConsumer<AddBasketMessage>
    {
        private readonly IMediator _mediator;

        public AddBasketMessageConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task Consume(ConsumeContext<AddBasketMessage> context)
        {
            var command = new AddToBasketCommand()
            {
                CustomerGuid = context.Message.CustomerGuid,
                Id = context.Message.Id,
                
            };
            return _mediator.Send(command);
        }
    }
}