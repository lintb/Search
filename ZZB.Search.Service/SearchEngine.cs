using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Reflection;
using ZZB.Search.Interface;
using ZZB.Search.OutInterface;

namespace ZZB.Search.Service
{
    public class SearchEngine : ISearchEngine
    {
        private readonly string _searchDir = ConfigurationManager.AppSettings["SearchDir"];//"SearchDll";

        public List<ISearchService> GetSearchEngine()
        {
            List<ISearchService> list = new List<ISearchService>();

            string path = Path.Combine(Directory.GetCurrentDirectory(), _searchDir);
            string[] files = Directory.GetFiles(path);

            foreach (string file in files)
            {
                var extension = Path.GetExtension(file);
                if (extension != null && extension.ToLower() == ".dll")
                {
                    Assembly assembly = Assembly.LoadFile(file);
                    Type[] types = assembly.GetTypes();
                    foreach (Type type in types)
                    {
                        if (type.GetInterface("ISearchService") != null)
                        {
                            ISearchService searchService = Activator.CreateInstance(type) as ISearchService;
                            if (searchService != null)
                            {
                                list.Add(searchService);
                            }
                        }
                    }
                }
            }


            return list;
        }
    }
}