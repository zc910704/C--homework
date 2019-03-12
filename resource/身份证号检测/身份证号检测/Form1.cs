using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 身份证号检测
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void checkButton_Click(object sender, EventArgs e)
        {
            char checksum;
            string pattern = @"[1-9]{1}\d{16}(X|x|\d){1}";
            Regex rx = new Regex(pattern);
            MatchCollection ms = rx.Matches(checkTextBox.Text);
            resultTreeView.Nodes.Clear();
            resultTreeView.Nodes.Add(ms.Count+"个数据格式验证正确");
            foreach (Match m in ms)
            {
                if (m.Success)
                {
                    int sum = 0;
                    string map = "10X98765432";
                    for (int i = 17; i > 0; i--)
                    {
                        int s = (int)Math.Pow(2, i) % 11;
                        //注意char和int的转换
                        int currentnum = m.Value[17 - i] - '0';
                        // 法2 currentnum = int.TryParse(m.Value[17 - i].ToString());
                        // 法3 currentnum = Convert.ToInt32(m.Value[17 - i].ToString());
                        // 错误法4 (int)'1'
                        // 错误法5 Convert.ToInt32(m.Value[17 - i]);

                        sum += s * currentnum;
                    }
                    checksum = map[sum % 11];
                    if (checksum == m.Value[m.Value.Length - 1])
                    {
                        resultTreeView.Nodes.Add(m.Value + "校验位验证成功");
                    }
                    else
                    {
                        resultTreeView.Nodes.Add(m.Value + "校验位验证失败");
                    }
                }
            }
            
        }

        private void checkTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                checkButton_Click(sender, e);
            }
        }
    }
}
