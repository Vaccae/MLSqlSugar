namespace MLSqlSugar
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsMulti = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmnuInitGoodsData = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmnuyn = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmnubinaryinit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tbMsg = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCs = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.toolStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMulti,
            this.toolStripSeparator1,
            this.tsmnuyn,
            this.toolStripSeparator2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 31);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsMulti
            // 
            this.tsMulti.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsMulti.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmnuInitGoodsData});
            this.tsMulti.Image = ((System.Drawing.Image)(resources.GetObject("tsMulti.Image")));
            this.tsMulti.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsMulti.Name = "tsMulti";
            this.tsMulti.Size = new System.Drawing.Size(100, 28);
            this.tsMulti.Text = "多类分类";
            // 
            // tsmnuInitGoodsData
            // 
            this.tsmnuInitGoodsData.Name = "tsmnuInitGoodsData";
            this.tsmnuInitGoodsData.Size = new System.Drawing.Size(218, 30);
            this.tsmnuInitGoodsData.Text = "初始化训练数据";
            this.tsmnuInitGoodsData.Click += new System.EventHandler(this.tsmnuGetGoodsData_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // tsmnuyn
            // 
            this.tsmnuyn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsmnuyn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmnubinaryinit});
            this.tsmnuyn.Image = ((System.Drawing.Image)(resources.GetObject("tsmnuyn.Image")));
            this.tsmnuyn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmnuyn.Name = "tsmnuyn";
            this.tsmnuyn.Size = new System.Drawing.Size(100, 28);
            this.tsmnuyn.Text = "二元分类";
            // 
            // tsmnubinaryinit
            // 
            this.tsmnubinaryinit.Name = "tsmnubinaryinit";
            this.tsmnubinaryinit.Size = new System.Drawing.Size(252, 30);
            this.tsmnubinaryinit.Text = "初始化数据";
            this.tsmnubinaryinit.Click += new System.EventHandler(this.tsmnubinaryinit_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // tbMsg
            // 
            this.tbMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbMsg.Location = new System.Drawing.Point(3, 58);
            this.tbMsg.Multiline = true;
            this.tbMsg.Name = "tbMsg";
            this.tbMsg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbMsg.Size = new System.Drawing.Size(794, 358);
            this.tbMsg.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.tbMsg, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 31);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 419);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCs);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(794, 49);
            this.panel1.TabIndex = 2;
            // 
            // btnCs
            // 
            this.btnCs.Location = new System.Drawing.Point(568, 11);
            this.btnCs.Name = "btnCs";
            this.btnCs.Size = new System.Drawing.Size(111, 28);
            this.btnCs.TabIndex = 1;
            this.btnCs.Text = "测试数据";
            this.btnCs.UseVisualStyleBackColor = true;
            this.btnCs.Click += new System.EventHandler(this.btnCs_Click);
            // 
            // textBox1
            // 
            this.textBox1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.textBox1.Location = new System.Drawing.Point(20, 11);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(532, 28);
            this.textBox1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton tsMulti;
        private System.Windows.Forms.ToolStripMenuItem tsmnuInitGoodsData;
        private System.Windows.Forms.TextBox tbMsg;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCs;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripDropDownButton tsmnuyn;
        private System.Windows.Forms.ToolStripMenuItem tsmnubinaryinit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}

