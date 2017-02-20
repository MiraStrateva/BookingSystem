using Moq;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BookingSystem.Services.Tests.Mocks
{
    public class QueryableDbSetMock
    {
        public static IDbSet<T> GetQueryableMockDbSet<T>(IEnumerable<T> sourceList) where T : class
        {
            return GetQueryableMockDbSetFromArray(sourceList.ToArray());
        }

        public static IDbSet<T> GetQueryableMockDbSetFromArray<T>(params T[] sourceList) where T : class
        {
            var quearyable = sourceList.AsQueryable();
            var dbSet = new Mock<DbSet<T>>();

            dbSet.As<IQueryable<T>>()
                .Setup(m => m.Provider)
                .Returns(quearyable.Provider);
            dbSet.As<IQueryable<T>>()
                .Setup(m => m.Expression)
                .Returns(quearyable.Expression);
            dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(quearyable.ElementType);
            dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(quearyable.GetEnumerator());

            return dbSet.Object;
        }
    }
}
