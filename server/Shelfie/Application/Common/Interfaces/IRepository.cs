using Microsoft.AspNetCore.JsonPatch;
using Shelfie.Domain.Entities;

namespace Shelfie.Application.Common.Interfaces
{
	public interface IRepository
	{
		IQueryable<T> GetAll<T>() where T : BaseEntity;
		long Create<T>(T entityToCreate) where T : BaseEntity;
		void Remove<T>(T entity) where T : BaseEntity;
		void Update<T>(long id, T entityToUpdate) where T : BaseEntity;
		void SaveChanges();
	}
}
