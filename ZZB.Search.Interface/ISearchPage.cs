using System;
using System.Collections.Generic;

namespace ZZB.Search.Interface
{
    public interface ISearchPage
    {
        void GetSearchListByPage(string keyword, int page, Action<OutInterface.Search> callback);
    }
}