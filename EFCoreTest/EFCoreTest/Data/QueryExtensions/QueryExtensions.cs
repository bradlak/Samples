using EFCoreTest.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EFCoreTest.Data.QueryExtensions
{
    public static class QueryExtensions
    {
        public static IQueryable<Owner> BuildOwner(this IQueryable<Owner> query)
        {
            return query.Include(z => z.Cars);
        }

        public static IQueryable<Car> BuildCar(this IQueryable<Car> query)
        {
            return query.Include(z => z.Owner);
        }
    }
}