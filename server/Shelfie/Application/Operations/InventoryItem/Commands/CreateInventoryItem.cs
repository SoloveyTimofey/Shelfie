using AutoMapper;
using MediatR;
using Shelfie.Application.Common.Interfaces;
using Shelfie.Domain.Entities;
using Shelfie.Domain.Enums;

namespace Shelfie.Application.Operations.InventoryItem.Handlers
{
    public class CreateInventoryItemHandler : IRequestHandler<CreateInventoryItemCommand, long>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        public CreateInventoryItemHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<long> Handle(CreateInventoryItemCommand request, CancellationToken cancellationToken)
        {
            var inventoryItemDomainEntity = _mapper.Map<Domain.Entities.InventoryItem>(request);

            var result = _repository.Create(inventoryItemDomainEntity);

            return Task.FromResult(result);
        }
    }

    public record CreateInventoryItemCommand : IRequest<long>
    {
        public string Name { get; init; } = null!;
        public InventoryItemStatus Status { get; init; }
        public decimal Price { get; init; }
        public Brand Brand { get; init; } = null!;
        public Location Location { get; init; } = null!;
    }
}
