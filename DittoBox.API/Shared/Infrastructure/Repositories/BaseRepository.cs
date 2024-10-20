
namespace DittoBox.API.Shared.Domain.Repositories {
	public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
	{
		public Task Add(T entity)
		{
			throw new NotImplementedException();
		}

		public Task Delete(T entity)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<T>> GetAll()
		{
			throw new NotImplementedException();
		}

		public Task<T> GetById(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task Update(T entity)
		{
			throw new NotImplementedException();
		}
	}
}