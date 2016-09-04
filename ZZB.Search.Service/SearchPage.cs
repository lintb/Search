using System;
using System.Collections.Generic;
using ZZB.Search.Interface;
using ZZB.Search.Model;

namespace ZZB.Search.Service
{
    public class SearchPage : ISearchPage
    {
        //private int _curPage;

        private readonly SearchEngineViewModel[] _models;

        public SearchPage(SearchEngineViewModel[] models)
        {
            _models = models;
        }

        public void GetSearchListByPage(string keyword, int page, Action<OutInterface.Search> callback)
        {
            if (_models != null)
            {
                foreach (SearchEngineViewModel model in _models)
                {
                    model.SearchService.Search(keyword, page, callback);
                }
            }
        }
    }
}