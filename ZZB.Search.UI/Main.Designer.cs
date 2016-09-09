namespace ZZB.Search.UI
{
    partial class Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtKeyWord = new System.Windows.Forms.TextBox();
            this.cbBoxsearchEngine = new System.Windows.Forms.ComboBox();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.CreatTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DowdloadUrl = new System.Windows.Forms.DataGridViewLinkColumn();
            this.From = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnPage1 = new System.Windows.Forms.Button();
            this.btnPage2 = new System.Windows.Forms.Button();
            this.btnPage3 = new System.Windows.Forms.Button();
            this.btnPage4 = new System.Windows.Forms.Button();
            this.btnPage5 = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // txtKeyWord
            // 
            this.txtKeyWord.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKeyWord.Location = new System.Drawing.Point(12, 12);
            this.txtKeyWord.Name = "txtKeyWord";
            this.txtKeyWord.Size = new System.Drawing.Size(398, 21);
            this.txtKeyWord.TabIndex = 0;
            this.txtKeyWord.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKeyWord_KeyDown);
            // 
            // cbBoxsearchEngine
            // 
            this.cbBoxsearchEngine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbBoxsearchEngine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBoxsearchEngine.FormattingEnabled = true;
            this.cbBoxsearchEngine.Items.AddRange(new object[] {
            "全部"});
            this.cbBoxsearchEngine.Location = new System.Drawing.Point(416, 12);
            this.cbBoxsearchEngine.Name = "cbBoxsearchEngine";
            this.cbBoxsearchEngine.Size = new System.Drawing.Size(139, 20);
            this.cbBoxsearchEngine.TabIndex = 1;
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.AllowUserToOrderColumns = true;
            this.dataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle26.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle26.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle26.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle26.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle26.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle26;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CreatTime,
            this.Title,
            this.Size,
            this.DowdloadUrl,
            this.From});
            this.dataGrid.Location = new System.Drawing.Point(12, 39);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ReadOnly = true;
            this.dataGrid.RowTemplate.Height = 23;
            this.dataGrid.Size = new System.Drawing.Size(624, 379);
            this.dataGrid.TabIndex = 2;
            this.dataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellClick);
            // 
            // CreatTime
            // 
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CreatTime.DefaultCellStyle = dataGridViewCellStyle27;
            this.CreatTime.HeaderText = "发布时间";
            this.CreatTime.Name = "CreatTime";
            this.CreatTime.ReadOnly = true;
            // 
            // Title
            // 
            this.Title.HeaderText = "标题";
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            // 
            // Size
            // 
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Size.DefaultCellStyle = dataGridViewCellStyle28;
            this.Size.HeaderText = "大小";
            this.Size.Name = "Size";
            this.Size.ReadOnly = true;
            // 
            // DowdloadUrl
            // 
            this.DowdloadUrl.ActiveLinkColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle29.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.DowdloadUrl.DefaultCellStyle = dataGridViewCellStyle29;
            this.DowdloadUrl.HeaderText = "下载地址";
            this.DowdloadUrl.LinkColor = System.Drawing.Color.DeepSkyBlue;
            this.DowdloadUrl.Name = "DowdloadUrl";
            this.DowdloadUrl.ReadOnly = true;
            this.DowdloadUrl.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DowdloadUrl.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // From
            // 
            dataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.From.DefaultCellStyle = dataGridViewCellStyle30;
            this.From.HeaderText = "来源";
            this.From.Name = "From";
            this.From.ReadOnly = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(561, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "搜索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(188, 424);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(25, 23);
            this.btnPrevious.TabIndex = 4;
            this.btnPrevious.Text = "<<";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Visible = false;
            // 
            // btnPage1
            // 
            this.btnPage1.Location = new System.Drawing.Point(219, 424);
            this.btnPage1.Name = "btnPage1";
            this.btnPage1.Size = new System.Drawing.Size(25, 23);
            this.btnPage1.TabIndex = 4;
            this.btnPage1.Text = "1";
            this.btnPage1.UseVisualStyleBackColor = true;
            this.btnPage1.Click += new System.EventHandler(this.btnPage1_Click);
            // 
            // btnPage2
            // 
            this.btnPage2.Location = new System.Drawing.Point(250, 424);
            this.btnPage2.Name = "btnPage2";
            this.btnPage2.Size = new System.Drawing.Size(25, 23);
            this.btnPage2.TabIndex = 4;
            this.btnPage2.Text = "2";
            this.btnPage2.UseVisualStyleBackColor = true;
            this.btnPage2.Click += new System.EventHandler(this.btnPage2_Click);
            // 
            // btnPage3
            // 
            this.btnPage3.Location = new System.Drawing.Point(281, 424);
            this.btnPage3.Name = "btnPage3";
            this.btnPage3.Size = new System.Drawing.Size(25, 23);
            this.btnPage3.TabIndex = 4;
            this.btnPage3.Text = "3";
            this.btnPage3.UseVisualStyleBackColor = true;
            this.btnPage3.Click += new System.EventHandler(this.btnPage3_Click);
            // 
            // btnPage4
            // 
            this.btnPage4.Location = new System.Drawing.Point(312, 424);
            this.btnPage4.Name = "btnPage4";
            this.btnPage4.Size = new System.Drawing.Size(25, 23);
            this.btnPage4.TabIndex = 4;
            this.btnPage4.Text = "4";
            this.btnPage4.UseVisualStyleBackColor = true;
            this.btnPage4.Click += new System.EventHandler(this.btnPage4_Click);
            // 
            // btnPage5
            // 
            this.btnPage5.Location = new System.Drawing.Point(343, 424);
            this.btnPage5.Name = "btnPage5";
            this.btnPage5.Size = new System.Drawing.Size(25, 23);
            this.btnPage5.TabIndex = 4;
            this.btnPage5.Text = "5";
            this.btnPage5.UseVisualStyleBackColor = true;
            this.btnPage5.Click += new System.EventHandler(this.btnPage5_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(374, 424);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(25, 23);
            this.btnNext.TabIndex = 4;
            this.btnNext.Text = ">>";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Visible = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 459);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPage5);
            this.Controls.Add(this.btnPage4);
            this.Controls.Add(this.btnPage3);
            this.Controls.Add(this.btnPage2);
            this.Controls.Add(this.btnPage1);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dataGrid);
            this.Controls.Add(this.cbBoxsearchEngine);
            this.Controls.Add(this.txtKeyWord);
            this.MinimumSize = new System.Drawing.Size(664, 498);
            this.Name = "Main";
            this.Text = "搜索工具";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtKeyWord;
        private System.Windows.Forms.ComboBox cbBoxsearchEngine;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Size;
        private System.Windows.Forms.DataGridViewLinkColumn DowdloadUrl;
        private System.Windows.Forms.DataGridViewTextBoxColumn From;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnPage1;
        private System.Windows.Forms.Button btnPage2;
        private System.Windows.Forms.Button btnPage3;
        private System.Windows.Forms.Button btnPage4;
        private System.Windows.Forms.Button btnPage5;
        private System.Windows.Forms.Button btnNext;
    }
}

