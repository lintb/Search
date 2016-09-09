using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public Task GetSearchListByPage(string keyword, int page, Action<OutInterface.Search, string> callback)
        {
            return Task.Run(() =>
            {
                if (_models != null)
                {
                    foreach (SearchEngineViewModel model in _models)
                    {
                        new Task(() =>
                        {
                            model.SearchService.Search(keyword, page, s =>
                            {
                                callback(s, model.ToString());
                            });
                        }).Start();
                    }
                }
            });
        }
    }
}