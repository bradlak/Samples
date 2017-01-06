using EFCoreTest.Data.Interfaces;
using System.Collections.Generic;
using System.Linq;
using EFCoreTest.Data.Entities;
using EFCoreTest.Data.QueryExtensions;

namespace EFCoreTest.Data.Repositories
{
    public class OwnersRepository : BaseRepository<OwnersContext>, IRepository<Owner>
    {
        public bool Create(Owner owner)
        {
            return  this.Add<Owner>(owner);
        }

        public void DeleteAll()
        {
            this.RemoveAll<Owner>();
        }

        public Owner GetById(int id, bool withIncludes)
        {
            return withIncludes ? this.Get<Owner>(z => z.Id == id).BuildOwner().SingleOrDefault() : this.GetSingle<Owner>(z => z.Id == id);
        }

        public IEnumerable<Owner> GetCollection(bool withIncludes)
        {
            return withIncludes ? this.Get<Owner>().BuildOwner().ToList() : this.Get<Owner>().ToList();
        }
    }
}