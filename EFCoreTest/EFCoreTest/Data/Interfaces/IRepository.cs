using EFCoreTest.Data.Entities;
using System.Collections.Generic;

namespace EFCoreTest.Data.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        IEnumerable<TEntity> GetCollection(bool withIncludes);

        TEntity GetById(int id, bool withIncludes);

        bool Create(TEntity owner);

        void DeleteAll();
    }
}
