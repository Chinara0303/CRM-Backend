using Domain.Common;
using Org.BouncyCastle.Asn1.Ocsp;
using Repository.Repositories.İnterfaces;
using Services.DTOs.Search;
using Services.Services.İnterfaces;

namespace Services.Services
{
    public class SearchService<T> : ISearchService<T> where T : CommonPerson
    {
        private readonly IRepository<T> _repo;
        public SearchService(IRepository<T> repo)
        {
            _repo = repo;
        }
        public async Task<IEnumerable<SearchResultDto>> SearchAsync(string keyword)
        {
            var results = await _repo.GetAllAsync(x => x.FullName.Trim().ToLower().Contains(keyword.Trim().ToLower()));
            List<SearchResultDto> result = new List<SearchResultDto>();
            foreach (var item in results)
            {
                SearchResultDto resultsDto = new()
                {
                    Name = item.FullName
                };
                result.Add(resultsDto);
            }
          
            return result;
        }
      
    }
}
