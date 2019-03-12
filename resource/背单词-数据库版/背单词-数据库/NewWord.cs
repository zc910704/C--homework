using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 背单词_数据库
{
    public partial class NewWord : Form
    {
        public NewWord()
        {
            InitializeComponent();
            using (SQLiteConnection conn = new SQLiteConnection(Form1.GetConnectionStr()))
            {
                //bool为什么必须用1？
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(@"select * from [words_list] where [NewWord] = 1", conn);
                DataSet nword = new DataSet();
                adapter.Fill(nword);
                DataTable dt = nword.Tables[0];
                dt.Columns[3].ColumnMapping = MappingType.Hidden;
                dt.AcceptChanges();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.DataSource = dt;
            }
        }
    }
}
