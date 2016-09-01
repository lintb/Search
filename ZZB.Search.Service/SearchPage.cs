using System;
using System.Collections.Generic;
using ZZB.Search.Interface;
using ZZB.Search.Model;

namespace ZZB.Search.Service
{
    public class SearchPage : ISearchPage
    {
        private int _curPage;

        private SearchEngineViewModel[] _models;

        public SearchPage(SearchEngineViewModel[] models)
        {
            _curPage = 0;
            _models = models;
        }

        public void GetSearchListByPage(string keyword, int page, Action<OutInterface.Search> callback)
        {

        }
    }
}