using System.Collections.Generic;
using System.Threading.Tasks;

namespace ZZB.Search.OutInterface
{
    public interface ISearchService
    {
        /// <summary>
        /// 搜索引擎地址
        /// </summary>
        string Url { get; }

        /// <summary>
        /// 搜索引擎名称
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 根据关键字搜索资源
        /// </summary>
        /// <param name="keyWord">关键字</param>
        /// <param name="index">页数</param>
        /// <returns>资源</returns>
        List<Search> Search(string keyWord, int index);

    }
}
