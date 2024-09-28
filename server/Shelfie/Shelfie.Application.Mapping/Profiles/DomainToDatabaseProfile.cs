using AutoMapper;

namespace Shelfie.Application.Mapping.Profiles
{
    public class DomainToDatabaseProfile : Profile
    {
        public DomainToDatabaseProfile()
        {
            CreateMap<Domain.Entities.Brand, Infrastructure.Data.DatabaseModels.BrandModel>();
            CreateMap<Domain.Entities.InventoryItem, Infrastructure.Data.DatabaseModels.InventoryItemModel>();
            CreateMap<Domain.Entities.ItemType, Infrastructure.Data.DatabaseModels.ItemTypeModel>();
            CreateMap<Domain.Entities.Location, Infrastructure.Data.DatabaseModels.LocationModel>();
            CreateMap<Domain.Entities.QuantativeInventoryItem, Infrastructure.Data.DatabaseModels.QuantativeInventoryItemModel>();
            CreateMap<Domain.Entities.ResponsiblePerson, Infrastructure.Data.DatabaseModels.ResponsiblePersonModel>();
            CreateMap<Domain.ValueObjects.ChangeLog, Infrastructure.Data.DatabaseModels.ChangeLogModel>();
        }
    }
}
