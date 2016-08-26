using ZZB.Search.Interface;
using ZZB.Search.Model;
using ZZB.Search.Service;

namespace ZZB.Search.Factory
{
    public static class InstanceFactory
    {
        public static T GetInstance<T>(params object[] objs) where T : class
        {
            if (typeof(T) == typeof(ISearchEngine))
            {
                return new SearchEngine() as T;
            }
            if (typeof(T) == typeof(ISearchPage))
            {
                return new SearchPage(objs as SearchEngineViewModel[]) as T;
            }
            return null;

        }
    }
}