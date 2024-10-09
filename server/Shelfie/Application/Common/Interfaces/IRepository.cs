using Microsoft.AspNetCore.JsonPatch;
using Shelfie.Domain.Entities;

namespace Shelfie.Application.Common.Interfaces
{
	public interface IRepository
	{
		IQueryable<T> GetAll<T>() where T : BaseEntity;
		long Create<T>(T entityToCreate) where T : BaseEntity;
		void Delete<T>(long id) where T : BaseEntity;
		void Update<T>(long id, JsonPatchDocument<T> entityToUpdate) where T : BaseEntity;
	}
}
