using CRMApp.Helpers;
using Microsoft.AspNetCore.Identity;

namespace Repository.Repositories.İnterfaces
{
    public interface IPaginateRepository<T> where T : class
    {
        Paginate<T> PaginatedData<T>(IEnumerable<T> data, int skip, int take);

    }
}
