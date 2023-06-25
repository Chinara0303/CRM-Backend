using Domain.Common;
using Services.DTOs.Search;

namespace Services.Services.İnterfaces
{
    public interface ISearchService<T> where T : BaseEntity
    {
        //IEnumerable<T> SearchAsync(SearchRequestDto model);
        Task<IEnumerable<SearchResultDto>> SearchAsync(string keyword);
    }
}
