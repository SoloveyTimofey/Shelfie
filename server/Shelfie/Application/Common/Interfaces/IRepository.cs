using Domain.Entities;
using Microsoft.AspNetCore.JsonPatch;

namespace Application.Common.Interfaces
{
	public interface IRepository
	{
		IQueryable<T> GetAll<T>() where T : BaseEntity;
		long Create<T>(T entityToCreate) where T : BaseEntity;
		void Delete<T>(long id) where T : BaseEntity;
		void Update<T>(long id, JsonPatchDocument<T> entityToUpdate) where T : BaseEntity;
	}
}
