namespace 身份证号检测
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
            this.checkTextBox = new System.Windows.Forms.TextBox();
            this.checkButton = new System.Windows.Forms.Button();
            this.resultTreeView = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.清除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SuspendLayout();
            // 
            // checkTextBox
            // 
            this.checkTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkTextBox.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkTextBox.Location = new System.Drawing.Point(12, 59);
            this.checkTextBox.Multiline = true;
            this.checkTextBox.Name = "checkTextBox";
            this.checkTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.checkTextBox.Size = new System.Drawing.Size(202, 68);
            this.checkTextBox.TabIndex = 0;
            this.checkTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkTextBox_KeyPress);
            // 
            // checkButton
            // 
            this.checkButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkButton.BackColor = System.Drawing.Color.White;
            this.checkButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.checkButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.checkButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkButton.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkButton.Location = new System.Drawing.Point(220, 75);
            this.checkButton.Name = "checkButton";
            this.checkButton.Size = new System.Drawing.Size(75, 31);
            this.checkButton.TabIndex = 1;
            this.checkButton.Text = "检查";
            this.checkButton.UseVisualStyleBackColor = false;
            this.checkButton.Click += new System.EventHandler(this.checkButton_Click);
            // 
            // resultTreeView
            // 
            this.resultTreeView.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.resultTreeView.Location = new System.Drawing.Point(12, 133);
            this.resultTreeView.Name = "resultTreeView";
            this.resultTreeView.Size = new System.Drawing.Size(283, 112);
            this.resultTreeView.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(76, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "身份证校验";
            // 
            // 清除ToolStripMenuItem
            // 
            this.清除ToolStripMenuItem.Name = "清除ToolStripMenuItem";
            this.清除ToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(307, 257);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.resultTreeView);
            this.Controls.Add(this.checkButton);
            this.Controls.Add(this.checkTextBox);
            this.MinimumSize = new System.Drawing.Size(323, 295);
            this.Name = "Form1";
            this.Text = "身份证校验";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox checkTextBox;
        private System.Windows.Forms.Button checkButton;
        private System.Windows.Forms.TreeView resultTreeView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem 清除ToolStripMenuItem;
    }
}

