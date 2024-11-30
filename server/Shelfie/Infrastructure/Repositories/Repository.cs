using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shelfie.Application.Common.Interfaces;
using Shelfie.Domain.Entities;
using Shelfie.Infrastructure.Data.DbContexts;

namespace Shelfie.Infrastructure.Repositories
{
    internal class Repository : IRepository
    {
        private readonly ShelfieDbContext _context;
        private readonly IMapper _mapper;
        public Repository(ShelfieDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public long Create<T>(T entityToCreate) where T : BaseEntity
        {
            _context.Set<T>().Add(entityToCreate);
            
            return entityToCreate.Id;
        }

        public void Remove<T>(T entity) where T : BaseEntity
        {
            _context.Set<T>().Remove(entity);
        }

        public IQueryable<T> GetAll<T>() where T : BaseEntity
        {
            return _context.Set<T>();
        }

        public void Update<T>(T entityToUpdate) where T : BaseEntity
        {
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
