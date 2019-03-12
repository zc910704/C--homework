using System;
using System.Collections;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace 爬虫
{
    public partial class Form1 : Form
    {
        Hashtable hashtable = new Hashtable();
        private string _url;
        public string Url
        {
            get
            {
                return _url;
            }
            set
            {
                if (value.StartsWith(@"http://")|value.StartsWith(@"https://"))
                {
                    _url = value;
                }
                else
                {
                    _url = @"http://" + value;
                }
            }
        }
     
        public Form1()
        {
            InitializeComponent();
        }
        public delegate Hashtable GetMatchDelegate(string s);
        public delegate void DownloadMatchDelegate(string s,string fileName);
        //点击按钮时入口
        private void button1_Click(object sender, EventArgs e)
        {
            GetMatchDelegate GetUrlMatchesDelegate = GetMatches;
            treeView1.Nodes.Add("正在下载首页...");
            GetUrlMatchesDelegate.BeginInvoke(Url, getMatchCompleteCallback, GetUrlMatchesDelegate);
        }
        //被委托的获得hasttable的函数
        private Hashtable GetMatches(string s)
        {
            Url = textBox1.Text;
            WebClient client = new WebClient();
            byte[] pageData = client.DownloadData(Url);
            string Htmlpage = Encoding.Default.GetString(pageData);
            client.Dispose();
            Regex rx = new Regex(@"(?:(?:http|ftp|https)://)(?:(?:[a-zA-Z0-9\._-]+\.[a-zA-Z]{2,6})|(?:[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}))(:[0-9]{1,4})*(?<fileName>/[a-zA-Z0-9\&%_\./-~-]*)?");
            MatchCollection ms = rx.Matches(Htmlpage);
            foreach (Match m in ms)
            {
                try
                {
                    hashtable.Add(m.Value, false);
                }
                catch (Exception e)
                {

                }
            }
            return hashtable;
        }

        private void DownloadMatchcompleteCallback(IAsyncResult ar)
        {
            (ar.AsyncState as DownloadMatchDelegate).EndInvoke(ar);
           
        }

        private void downloadMatchAction(string s,string fileName)
        {
            if (imagecontrol.Checked)
            {
                if (fileName.EndsWith("jpg"))
                {
                    string msg = "下载完成：" + s;
                    WebClient client = new WebClient();
                    try
                    {
                        if (fileName != "")
                        {
                            client.DownloadFile(s, fileName);

                            client.Dispose();
                        }

                    }
                    catch (Exception e)
                    {

                    }
                    if (InvokeRequired)
                    {
                        this.BeginInvoke(new AddMsgsDelegate(AddMsgs), new object[] { msg });
                    }
                    else
                    {
                        this.AddMsgs(msg);
                    }
                }
            }
            else
            {
                string msg = "下载完成：" + s;
                WebClient client = new WebClient();
                try
                {
                    if (fileName != "")
                    {
                        client.DownloadFile(s, fileName);

                        client.Dispose();
                    }

                }
                catch (Exception e)
                {

                }


                if (InvokeRequired)
                {
                    this.BeginInvoke(new AddMsgsDelegate(AddMsgs), new object[] { msg });
                }
                else
                {
                    this.AddMsgs(msg);
                }
            }
            
        }

        private string getFileName(string s)
        {
            if (s != null)
            {
                string fileName;
                Match m = Regex.Match(s, @"[0-9a-zA-Z&=-]{1,}?\.(png|php|html|xml|js|jpg)");
                fileName = m.Value;
                return fileName;
            }
            else return null;

        }

        private void getMatchCompleteCallback(IAsyncResult iar)
        {
            Hashtable hashtable = (iar.AsyncState as GetMatchDelegate).EndInvoke(iar);
            string msg = hashtable.Count.ToString() + "个所有类型链接";
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new AddMsgsDelegate(AddMsgs),new object[] { msg });
            }
            else
            {
                this.AddMsgs(msg);
            }
            string fileName;
            foreach(DictionaryEntry de in hashtable)
            {
                 fileName = this.getFileName(de.Key as string);
                if (fileName == null) break;
                 DownloadMatchDelegate downloadMatchdelegate = downloadMatchAction;
                 downloadMatchdelegate.BeginInvoke(de.Key as string, fileName, DownloadMatchcompleteCallback, downloadMatchdelegate);
            
            }
        }
        private delegate void AddMsgsDelegate(String msg);
        private void AddMsgs(string msg)
        {
            treeView1.Nodes.Add(msg);
        }
    }
}
