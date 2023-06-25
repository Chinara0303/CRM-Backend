using Domain.Common;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Services.İnterfaces;

namespace CRMApp.Controllers
{
    public class SearchController : Controller 
    {
        private readonly ISearchService<Teacher> _searchService;

        public SearchController(ISearchService<Teacher> searchService)
        {
            _searchService = searchService;
        }

        [HttpGet]
        public async Task<IActionResult> Search(string searchText)
        {
            return Ok(_searchService.SearchAsync(searchText));
        }
    }
}
