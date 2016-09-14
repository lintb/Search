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

        private ISearchPage _allSearchPage;

        //private Dictionary<string, List<OutInterface.Search>> _dicSearch = new Dictionary<string, List<OutInterface.Search>>();

        public Main()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            cbBoxsearchEngine.SelectedIndex = 0;

            SetColumnsWidth();
        }

        private void SetColumnsWidth()
        {
            //发布时间
            dataGrid.Columns[0].Width = 100;

            //大小
            dataGrid.Columns[2].Width = 80;

            //来源
            dataGrid.Columns[4].Width = 100;

        }

        private void Main_Load(object sender, EventArgs e)
        {
            //加载搜索引擎
            List<ISearchService> list = _searchEngine.GetSearchEngine();
            if (list != null)
            {
                List<SearchEngineViewModel> models = new List<SearchEngineViewModel>();
                foreach (ISearchService searchService in list)
                {
                    SearchEngineViewModel search = new SearchEngineViewModel(searchService);
                    cbBoxsearchEngine.Items.Add(search);
                    models.Add(search);
                }
                _allSearchPage = InstanceFactory.GetInstance<ISearchPage>(models.ToArray());
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            await Search(1);
        }

        private async Task Search(int index)
        {
            dataGrid.Rows.Clear();
            if (cbBoxsearchEngine.SelectedItem.ToString() == "全部")
            {
                await _allSearchPage.GetSearchListByPage(txtKeyWord.Text, index, AcceptSearch);
            }
            else
            {
                SearchEngineViewModel search = cbBoxsearchEngine.SelectedItem as SearchEngineViewModel;
                await Task.Run(() =>
                 {
                     search?.SearchService.Search(txtKeyWord.Text, index, s =>
                     {
                         AcceptSearch(s, search.SearchService.Name);
                     });
                 });
            }
        }

        private void AcceptSearch(OutInterface.Search search, string name)
        {
            if (search != null)
            {
                this.Invoke(new Action(() =>
                {
                    dataGrid.Rows.Add(search.CreateTime.ToString("yyyy-MM-dd"), search.Title, $"{search.Size}MB",
                        search.DownloadUrl, name);
                }));
            }
        }

        private void dataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 0)
            {
                if (dataGrid.Columns[e.ColumnIndex].Name == "DowdloadUrl")
                {
                    if (e.RowIndex >= 0)
                    {
                        //复制DowdloadUrl字段
                        Clipboard.SetDataObject(dataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    }
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

        private async void btnPage1_Click(object sender, EventArgs e)
        {
            await Search(1);
        }

        private async void btnPage2_Click(object sender, EventArgs e)
        {
            await Search(2);
        }

        private async void btnPage3_Click(object sender, EventArgs e)
        {
            await Search(3);
        }

        private async void btnPage4_Click(object sender, EventArgs e)
        {
            await Search(4);
        }

        private async void btnPage5_Click(object sender, EventArgs e)
        {
            await Search(5);
        }

        private void Main_SizeChanged(object sender, EventArgs e)
        {
            SetColumnsWidth();
        }
    }
}
