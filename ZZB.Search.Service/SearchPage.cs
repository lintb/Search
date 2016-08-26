using System.Collections.Generic;
using ZZB.Search.Interface;
using ZZB.Search.Model;

namespace ZZB.Search.Service
{
    public class SearchPage : ISearchPage
    {
        private int _curPage;

        public SearchPage(SearchEngineViewModel[] models)
        {
            _curPage = 0;
        }

        public List<OutInterface.Search> GetSearchListByPage(string keyword, int page)
        {
            return null;
        }
    }
}