using System.Collections.Generic;
using ZZB.Search.OutInterface;

namespace ZZB.Search.Interface
{
    public interface ISearchEngine
    {
        List<ISearchService> GetSearchEngine();
    }
}