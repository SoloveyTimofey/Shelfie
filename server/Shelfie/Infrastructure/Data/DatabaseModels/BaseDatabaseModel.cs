using Microsoft.EntityFrameworkCore;

namespace Shelfie.Infrastructure.Data.DatabaseModels
{
    public abstract class BaseDatabaseModel
    {
        public long Id { get; set; }
    }
}
