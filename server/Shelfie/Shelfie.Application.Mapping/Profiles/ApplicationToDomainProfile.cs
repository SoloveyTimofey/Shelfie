using AutoMapper;
using Shelfie.Application.Operations.InventoryItem.Handlers;
using Shelfie.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shelfie.Application.Mapping.Profiles
{
    public class ApplicationToDomainProfile : Profile
    {
        public ApplicationToDomainProfile()
        {
            CreateMap<CreateInventoryItemCommand, InventoryItem>();
            CreateMap<DeleteInventoryItemCommand, InventoryItem>();
        }
    }
}
