﻿using System;
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
            if (dataGrid.Columns[e.ColumnIndex].Name == "DowdloadUrl")
            {
                if (e.RowIndex >= 0)
                {
                    //复制DowdloadUrl字段
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
    }
}
