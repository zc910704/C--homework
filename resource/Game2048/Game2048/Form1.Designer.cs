namespace Game2048
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlBoard = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.goallabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.游戏模式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.模式1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.模式2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.模式3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.模式4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.游戏进度ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.读取ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清除最高分ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.模式说明ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBoard
            // 
            this.pnlBoard.Location = new System.Drawing.Point(12, 93);
            this.pnlBoard.Name = "pnlBoard";
            this.pnlBoard.Size = new System.Drawing.Size(276, 273);
            this.pnlBoard.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(156, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "当前得分：";
            // 
            // goallabel
            // 
            this.goallabel.AutoSize = true;
            this.goallabel.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.goallabel.Location = new System.Drawing.Point(255, 37);
            this.goallabel.Name = "goallabel";
            this.goallabel.Size = new System.Drawing.Size(19, 19);
            this.goallabel.TabIndex = 2;
            this.goallabel.Text = "0";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.游戏模式ToolStripMenuItem,
            this.游戏进度ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(311, 25);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 游戏模式ToolStripMenuItem
            // 
            this.游戏模式ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.模式1ToolStripMenuItem,
            this.模式2ToolStripMenuItem,
            this.模式3ToolStripMenuItem,
            this.模式4ToolStripMenuItem});
            this.游戏模式ToolStripMenuItem.Name = "游戏模式ToolStripMenuItem";
            this.游戏模式ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.游戏模式ToolStripMenuItem.Text = "游戏模式";
            // 
            // 模式1ToolStripMenuItem
            // 
            this.模式1ToolStripMenuItem.Name = "模式1ToolStripMenuItem";
            this.模式1ToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.模式1ToolStripMenuItem.Text = "模式1";
            this.模式1ToolStripMenuItem.Click += new System.EventHandler(this.模式1ToolStripMenuItem_Click);
            // 
            // 模式2ToolStripMenuItem
            // 
            this.模式2ToolStripMenuItem.Name = "模式2ToolStripMenuItem";
            this.模式2ToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.模式2ToolStripMenuItem.Text = "模式2";
            this.模式2ToolStripMenuItem.Click += new System.EventHandler(this.模式2ToolStripMenuItem_Click);
            // 
            // 模式3ToolStripMenuItem
            // 
            this.模式3ToolStripMenuItem.Name = "模式3ToolStripMenuItem";
            this.模式3ToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.模式3ToolStripMenuItem.Text = "模式3";
            this.模式3ToolStripMenuItem.Click += new System.EventHandler(this.模式3ToolStripMenuItem_Click);
            // 
            // 模式4ToolStripMenuItem
            // 
            this.模式4ToolStripMenuItem.Name = "模式4ToolStripMenuItem";
            this.模式4ToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.模式4ToolStripMenuItem.Text = "模式4";
            this.模式4ToolStripMenuItem.Click += new System.EventHandler(this.模式4ToolStripMenuItem_Click);
            // 
            // 游戏进度ToolStripMenuItem
            // 
            this.游戏进度ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.保存ToolStripMenuItem,
            this.删除ToolStripMenuItem,
            this.读取ToolStripMenuItem});
            this.游戏进度ToolStripMenuItem.Name = "游戏进度ToolStripMenuItem";
            this.游戏进度ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.游戏进度ToolStripMenuItem.Text = "游戏进度";
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.保存ToolStripMenuItem.Text = "保存";
            this.保存ToolStripMenuItem.Click += new System.EventHandler(this.保存ToolStripMenuItem_Click);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            // 
            // 读取ToolStripMenuItem
            // 
            this.读取ToolStripMenuItem.Name = "读取ToolStripMenuItem";
            this.读取ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.读取ToolStripMenuItem.Text = "读取";
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.清除最高分ToolStripMenuItem,
            this.模式说明ToolStripMenuItem,
            this.关于ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 清除最高分ToolStripMenuItem
            // 
            this.清除最高分ToolStripMenuItem.Name = "清除最高分ToolStripMenuItem";
            this.清除最高分ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.清除最高分ToolStripMenuItem.Text = "清除最高分";
            this.清除最高分ToolStripMenuItem.Click += new System.EventHandler(this.清除最高分ToolStripMenuItem_Click);
            // 
            // 模式说明ToolStripMenuItem
            // 
            this.模式说明ToolStripMenuItem.Name = "模式说明ToolStripMenuItem";
            this.模式说明ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.模式说明ToolStripMenuItem.Text = "模式说明";
            this.模式说明ToolStripMenuItem.Click += new System.EventHandler(this.模式说明ToolStripMenuItem_Click);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.关于ToolStripMenuItem.Text = "关于";
            this.关于ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(7, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "最高分：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(83, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 397);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.goallabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlBoard);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlBoard;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label goallabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 游戏模式ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 模式1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 模式2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 模式3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 游戏进度ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 读取ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 模式说明ToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清除最高分ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 模式4ToolStripMenuItem;
    }
}

