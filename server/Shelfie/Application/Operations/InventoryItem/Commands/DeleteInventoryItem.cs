using MediatR;
using Shelfie.Application.Common.Interfaces;

namespace Shelfie.Application.Operations.InventoryItem.Handlers
{
    public class DeleteInventoryItemHandler : IRequestHandler<DeleteInventoryItemCommand, long>
    {
        private readonly IRepository _repository;
        public DeleteInventoryItemHandler(IRepository repository)
        {
            _repository = repository;
        }

        public Task<long> Handle(DeleteInventoryItemCommand request, CancellationToken cancellationToken)
        {
            
        }
    }

    public record DeleteInventoryItemCommand : IRequest<long>
    {
        public long Id { get; init; }
    }
}
