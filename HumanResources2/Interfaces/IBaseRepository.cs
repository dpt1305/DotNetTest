using System;
namespace HumanResources2.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<IEnumerable<T>> Create(T entity);
        Task<IEnumerable<T>> Update(T entity);
        Task<IEnumerable<T>> FindAll();

        Task<IEnumerable<T>> FindOneById(T entity);
        Task<IEnumerable<T>> Delete(T entity);


    }
}

