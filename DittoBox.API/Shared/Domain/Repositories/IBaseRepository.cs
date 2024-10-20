namespace DittoBox.API.Shared.Domain.Repositories {
	public interface IBaseRepository<T> where T : class {
		Task<T> GetById(Guid id);
		Task<IEnumerable<T>> GetAll();
		Task Add(T entity);
		Task Update(T entity);
		Task Delete(T entity);

	}
}