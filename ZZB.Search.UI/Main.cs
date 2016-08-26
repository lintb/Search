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
            List<OutInterface.Search> list = new List<OutInterface.Search>();
            if (cbBoxsearchEngine.SelectedItem.ToString() == "全部")
            {
                foreach (object item in cbBoxsearchEngine.Items)
                {
                    SearchEngineViewModel search = item as SearchEngineViewModel;
                    if (search != null)
                    {
                        var temp = await AsyncGetSearchList(search);
                        list.AddRange(temp);
                    }
                }
            }
            foreach (OutInterface.Search search in list)
            {
                dataGrid.Rows.Add(search.CreateTime.ToString("yyyy-MM-dd"), search.Title, $"{search.Size}MB", search.DownloadUrl, "测试");
            }
        }

        private Task<List<OutInterface.Search>> AsyncGetSearchList(SearchEngineViewModel search)
        {
            return Task.Run(() => search.SearchService.Search(txtKeyWord.Text, ++search.Index));
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
