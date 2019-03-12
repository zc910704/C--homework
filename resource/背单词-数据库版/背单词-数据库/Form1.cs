using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 背单词_数据库
{
    public partial class Form1 : Form
    {
        int totalNum;
        DataSet WordData;
        int currentNo = 1;

        public Form1()
        {
            
       
            using(SQLiteConnection conn = new SQLiteConnection(GetConnectionStr()))
            {
                SQLiteDataAdapter adapter =new SQLiteDataAdapter(@"select * from [words_list]", conn);
                WordData = new DataSet();
                adapter.Fill(WordData);
                totalNum = WordData.Tables[0].Rows.Count;
            }
            InitializeComponent();
            label2.Text = "共："+totalNum.ToString();
            getNewWord(currentNo);
        }
        public void getNewWord(int currentNo)
        {
            int A = 0, B = 0, C = 0, D = 0;
            Random Rn = new Random();
            int Error1 = Rn.Next(totalNum);
            int Error2 = Rn.Next(totalNum);
            int Error3 = Rn.Next(totalNum);
            int Correct = currentNo;
            int rightAnswerStus = Rn.Next(3);
            switch (rightAnswerStus)
            {
                case 0:
                    A = Correct;
                    B = Error1;
                    C = Error2;
                    D = Error3;
                    break;
                case 1:
                    B = Correct;
                    A = Error1;
                    C = Error2;
                    D = Error3;
                    break;
                case 2:
                    C = Correct;
                    B = Error1;
                    A = Error2;
                    D = Error3;
                    break;
                case 3:
                    D = Correct;
                    B = Error1;
                    C = Error2;
                    A = Error3;
                    break;
                default:
                    break;
            }
            radioButton1.Text = WordData.Tables[0].Rows[A - 1][2].ToString();
            radioButton1.Checked = false;
            radioButton2.Text = WordData.Tables[0].Rows[B - 1][2].ToString();
            radioButton2.Checked = false;
            radioButton3.Text = WordData.Tables[0].Rows[C - 1][2].ToString();
            radioButton3.Checked = false;
            radioButton4.Text = WordData.Tables[0].Rows[D - 1][2].ToString();
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            linkLabel1.Text = WordData.Tables[0].Rows[Correct - 1][1].ToString();
            label1.Text = "No." + currentNo;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(@"https://www.merriam-webster.com/dictionary/"+WordData.Tables[0].Rows[currentNo-1][1].ToString());
        }

        private void radioButton_MouseClick(object sender, MouseEventArgs e)
        {
            string answer =(sender as RadioButton).Text;
            if(answer == WordData.Tables[0].Rows[currentNo - 1][2].ToString())
            {
                listBox1.Items.Add(WordData.Tables[0].Rows[currentNo - 1][1].ToString()+" 正确");
                listBox1.TopIndex = listBox1.Items.Count - (int)(listBox1.Height / listBox1.ItemHeight);
            }
            else
            {
                listBox1.Items.Add(WordData.Tables[0].Rows[currentNo - 1][1].ToString() + " 错误");
                listBox1.TopIndex = listBox1.Items.Count - (int)(listBox1.Height / listBox1.ItemHeight);
                using (SQLiteConnection conn = new SQLiteConnection(GetConnectionStr()))
                {
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(@"select * from [words_list]", conn);
                    SQLiteCommandBuilder comm = new SQLiteCommandBuilder(adapter);
                    DataRow row = WordData.Tables[0].Rows[currentNo - 1];
                    //beginEdit防止同时读写；
                    row.BeginEdit();
                    row["NewWord"] = true;
                    row.EndEdit();
                    //为什么必须先update
                    adapter.Update(WordData);
                    row.AcceptChanges();
                    WordData.AcceptChanges();

                }
            }
            getNewWord(++currentNo);
            
        }
        public static string GetConnectionStr()
        {
            string strConnectionString = string.Empty;
            string strDataSource = Environment.CurrentDirectory + @"\word.db";
            SqlConnectionStringBuilder strbuild = new SqlConnectionStringBuilder();
            strbuild.DataSource = strDataSource;
            strbuild.Password = string.Empty;
            strConnectionString = strbuild.ToString();

            return strConnectionString;
        }

        internal void 生词本ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            NewWord nw = new NewWord();
            nw.ShowDialog();
        }
    }
}
