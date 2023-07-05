using CRMApp.Helpers;
using Repository.Repositories.İnterfaces;

namespace Repository.Repositories
{
    public class PaginateRepository<T> : IPaginateRepository<T> where T : class
    {
        public Paginate<T> PaginatedData<T>(IEnumerable<T> data, int skip, int take)
        {
            var totalItems = data.Count();
            var totalPages = (int)Math.Ceiling(totalItems / (double)take);

            var paginatedData = data
                .Skip((skip - 1) * take)
                .Take(take)
                .ToList();

            return new Paginate<T>(paginatedData, skip, totalPages);
        }
    }
}
