using System.Collections.Generic;
using System.Threading.Tasks;

namespace ZZB.Search.OutInterface
{
    public interface ISearchService
    {
        string Url { get; }

        string Name { get; }

        List<Search> Search(string keyWord, int index);

    }
}
