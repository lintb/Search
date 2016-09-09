using System;
using System.Threading.Tasks;
using ZZB.Search.Model;

namespace ZZB.Search.Interface
{
    public interface ISearchPage
    {
        Task GetSearchListByPage(string keyword, int page, Action<OutInterface.Search, string> callback);
    }
}