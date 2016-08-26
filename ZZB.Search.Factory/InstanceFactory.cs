using ZZB.Search.Interface;
using ZZB.Search.Service;

namespace ZZB.Search.Factory
{
    public static class InstanceFactory
    {
        public static T GetInstance<T>() where T : class
        {
            if (typeof(T) == typeof(ISearchEngine))
            {
                return new SearchEngine() as T;
            }
            else
            {
                return null;
            }
        }
    }
}