using System.Security.AccessControl;
using ZZB.Search.OutInterface;

namespace ZZB.Search.Model
{
    public class SearchEngineViewModel
    {
        public SearchEngineViewModel(ISearchService searchService)
        {
            SearchService = searchService;
        }

        public int Index { get; set; } = 0;
        public ISearchService SearchService { get; set; }
        public override string ToString()
        {
            return SearchService == null ? "" : SearchService.Name;
        }
    }
}
