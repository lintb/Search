using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZZB.Search.Factory;
using ZZB.Search.Interface;
using ZZB.Search.Model;
using ZZB.Search.OutInterface;

namespace ZZB.Search.UI
{
    public partial class Main : Form
    {
        private readonly ISearchEngine _searchEngine = InstanceFactory.GetInstance<ISearchEngine>();

        public Main()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            cbBoxsearchEngine.SelectedIndex = 0;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            List<ISearchService> list = _searchEngine.GetSearchEngine();
            if (list != null)
            {
                foreach (ISearchService searchService in list)
                {
                    cbBoxsearchEngine.Items.Add(new SearchEngineViewModel(searchService));
                }
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            if (cbBoxsearchEngine.SelectedItem.ToString() == "全部")
            {
                foreach (object item in cbBoxsearchEngine.Items)
                {
                    SearchEngineViewModel search = item as SearchEngineViewModel;
                    if (search != null)
                    {
                        //使用异步，防止UI线程阻塞
                        await GetSearch(search, search.ToString());
                    }
                }
            }
        }

        private Task GetSearch(SearchEngineViewModel search, string name)
        {
            return Task.Run(() =>
            {
                //执行搜索资源方法
                search.SearchService.Search(txtKeyWord.Text, ++search.Index, s =>
                {
                    this.Invoke(new Action(() =>
                    {
                        dataGrid.Rows.Add(s.CreateTime.ToString("yyyy-MM-dd"), s.Title, $"{s.Size}MB", s.DownloadUrl, name);
                    }));
                });
            });

        }

        private void dataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGrid.Columns[e.ColumnIndex].Name == "DowdloadUrl")
            {
                if (e.RowIndex >= 0)
                {
                    Clipboard.SetDataObject(dataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                }
            }
        }

        private void txtKeyWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(null, null);
            }
        }
    }
}
