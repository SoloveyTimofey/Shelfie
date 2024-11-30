using MediatR;
using Shelfie.Application.Common.Interfaces;
using Shelfie.Domain.Entities;

namespace Shelfie.Application.Operations.InventoryItem.Queries
{
    public class GetAllInventoryItemsRequestHandler : IRequestHandler<GetAllInventoryItemsRequest, List<Domain.Entities.InventoryItem>>
    {
        private readonly IRepository _repository;
        public GetAllInventoryItemsRequestHandler(IRepository repository)
        {
            _repository = repository;
        }
        public Task<List<Domain.Entities.InventoryItem>> Handle(GetAllInventoryItemsRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(
                _repository.GetAll<Domain.Entities.InventoryItem>().ToList()
            );
        }
    }

    public class GetAllInventoryItemsRequest : IRequest<List<Domain.Entities.InventoryItem>> { }

}
