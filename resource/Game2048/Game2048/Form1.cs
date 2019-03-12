using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Game2048
{
    public delegate void ValueChangeHandler(Object sender, ChangeEventArgs e);

    public partial class Form1 : Form
    {
        public event ValueChangeHandler ScoreValueChange;  // 声明值改变事件
        public event ValueChangeHandler HighestScoreValueChange;  // 声明值改变事件
        public int Score {
            set {
                int oldvalue = _score;
                _score = value;
                if(oldvalue != _score) {
                    ScoreValueChange?.Invoke(this, new ChangeEventArgs(_score));
                }
            }
            get { return _score; }
            }
        private int _score;
        public int HighestScore
        {
            set
            {
                int oldvalue = _highestScore;
                _highestScore = oldvalue > value ? oldvalue : value;
                if(oldvalue != _highestScore)
                {
                    HighestScoreValueChange?.Invoke(this, new ChangeEventArgs(_highestScore));
                }
            }
            get
            {
                return _highestScore;
            }
        }


        private int _highestScore;
        public Form1()
        {

            InitializeComponent();
            //关闭窗口时写入最高分，并结算恭喜信息
            FormClosing += (object sender, FormClosingEventArgs e)=>{
                if(Score == HighestScore&IsGameOver() == false)
                {
                    MessageBox.Show("恭喜,最近一次新记录！");
                }
                try
                {
                    //读取历史
                    FileStream fs = new FileStream("./history.dat", FileMode.OpenOrCreate);
                    StreamWriter sr = new StreamWriter(fs, Encoding.Default);
                    sr.WriteLine(HighestScore.ToString());
                    sr.Close();
                    fs.Close();
                }
                catch (Exception inner)
                {
                    MessageBox.Show(inner.ToString());
                }

            };
            //存储records
            FormClosing += (object sender, FormClosingEventArgs e) =>
            {
                using(Stream stream = new FileStream(@".\records.bin", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
                {
                    IFormatter formatter = new BinaryFormatter();
                    formatter.Serialize( stream, records);

                }
            };

                //打开窗口时读取最高分记录
                try
            {
                FileStream fs = new FileStream("./history.dat",FileMode.OpenOrCreate);
                StreamReader sr = new StreamReader(fs, Encoding.Default);
                label3.Text = sr.ReadLine().ToString();
                HighestScore = Convert.ToInt32(label3.Text);
                fs.Close();
                sr.Close();
            }catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            //读取records
            using (Stream stream = new FileStream(@"./records.bin", FileMode.OpenOrCreate, FileAccess.Read, FileShare.None))
            {
                try
                {
                    IFormatter formatter = new BinaryFormatter();
                    List<Record> recordRead = (List<Record>)formatter.Deserialize(stream);
                    records = recordRead;
                    foreach (Record record in records)
                    {
                        ToolStripMenuItem item = new ToolStripMenuItem(record.time.ToString()+ " 得分:" + record.score);
                        ToolStripMenuItem delItem = new ToolStripMenuItem(record.time.ToString() + " 得分:" + record.score);
                        item.Click += (object sender, EventArgs e) =>
                        {
                            Score = record.score;
                            Board = record.board;
                            RefreshUI();
                        };
                        删除ToolStripMenuItem.DropDownItems.Add(delItem);
                        读取ToolStripMenuItem.DropDownItems.Add(item);

                        delItem.Click += (object sender, EventArgs e) =>
                        {
                            records.Remove(record);
                            删除ToolStripMenuItem.DropDownItems.Remove(delItem);
                            读取ToolStripMenuItem.DropDownItems.Remove(item);
                        };
                    }

                }catch(Exception e)
                {
                    Console.WriteLine(e.HelpLink);
                }           
               
            }
        //利用事件通知属性值改变
        ScoreValueChange += (object sender, ChangeEventArgs e) =>
                {
                    goallabel.Text = e.Value.ToString();
                    HighestScore = e.Value;
                };
            HighestScoreValueChange += (object sender, ChangeEventArgs e) =>
            {
                label3.Text = e.Value.ToString();
            };
        }


        const int N = 4;  //方块在纵向及横向上的个数
        Button[] btns;
        internal  int[,] Board; //记录每个方块上的数s
        public  List<Record> records = new List<Record>();//保存变量

        int gameMode;
        string[] str1 = { "夏", "商", "周", "秦", "汉", "隋", "唐", "宋", "元", "明", "清" };
        string[] str2 = { "一品", "二品", "三品", "四品", "五品", "六品", "七品", "八品", "九品", "良民", "贱民" };
        string[] str3 = { "士兵", "排长", "连长", "营长", "旅长", "师长", "军长", "司令", "大帅", "良民", "贱民" };

        private void Form1_Load(object sender, EventArgs e)
        {
            Board = new int[N, N];
            Score = 0;
            goallabel.Text = 0.ToString();
            gameMode = 0;

            this.Text = "Game2048";
            this.DoubleBuffered = true;

            StartGame();
        }
        
        private void StartGame()
        {
            //设置两个不同的块为随机的2或4
            Random rnd = new Random();
            int n1 = rnd.Next(N * N);
            int n2;
            do
            {
                n2 = rnd.Next(N * N);
            }
            while (n1 == n2);
            Board[n1 / N, n1 % N] = rnd.Next(2) * 2 + 2; //设为2或4
            Board[n2 / N, n2 % N] = rnd.Next(2) * 2 + 2;
            
            InitialUI();
        }

        //初始化界面
        private void InitialUI()
        {
            //生成按钮
            GenerateAllButtons();

        }


        //产生所有的按钮
        private void GenerateAllButtons()
        {
            btns = new Button[N * N];

            int x0 = 5, y0 = 5, w = 60, d = w+5;

            for (int i = 0; i < btns.Length; i++)
            {
                Button btn = new Button();

                int r = i / N;  //行
                int c = i % N;  //列

                btn.Left = x0 + c * d;
                btn.Top = y0 + r * d;
                btn.Width = w;
                btn.Height = w;
                btn.Font = new Font("楷体", 16);

                btn.Text = GetTextOfButton(Board[r, c]);
                btn.BackColor = GetColorOfButton(Board[r, c]);

                btn.Visible = true;
                btns[i] = btn;
                this.pnlBoard.Controls.Add(btn);
            }
        }

        //更新界面
        private void RefreshUI()
        {
            RefreshAllButtons();
        }
        private void RefreshAllButtons()
        {
            for (int i = 0; i < btns.Length; i++)
            {
                int r = i / N;  //行
                int c = i % N;  //列
                btns[i].Text = GetTextOfButton(Board[r, c]);
                btns[i].BackColor = GetColorOfButton(Board[r, c]);
            }
        }
        
        //得到方块上应有的文字
        string GetTextOfButton(int n)
        {
            if (n < 2) return "";

            int k = (int)Math.Log(n, 2) - 1;

            if (gameMode == 0)
            {
                return n.ToString();
            }
            else if (gameMode == 1)
            {
                return str1[k];
            }
            else if (gameMode == 2)
            {
                return str2[k];
            }
            else if (gameMode == 3)
            {
                return str3[k];
            }
            return "";
        }

        //得到方块上应有的颜色

        Color GetColorOfButton(int n)
        {
            if (n == 0) return Color.FromArgb(100, 200, 200, 200);

            int tmp = 230-(int)Math.Log(n, 2) * 20;
            return Color.FromArgb(250, tmp, tmp, 0);
        }


        //处理键盘消息
        //要注意的是:由于按钮等元素的存在,窗体得不到KeyDown事件,所以在覆盖ProcessCmdKey
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            bool bMoved = false;

            if (keyData == Keys.Right)
            {
                bMoved = rightMove();
            }
            else if (keyData == Keys.Left)
            {
                bMoved = leftMove();
            }
            else if (keyData == Keys.Down)
            {
                bMoved = downMove();
            }
            else if (keyData == Keys.Up)
            {
                bMoved = upMove();
            }

            if (bMoved)
            {
                generateNewData();
                RefreshUI();
                if (IsGameOver() == true)
                {
                    MessageBox.Show("Game Over!");
                    if(Score == HighestScore)
                    {
                        MessageBox.Show("恭喜,新记录！");
                    }
                }
                    

                
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        //产生新的随机数据
        private void generateNewData()
        {
            Random rnd = new Random();
            //随机找到一个空的块
            int nCount;
            do
            {
                nCount = rnd.Next(N * N);
            }
            while (Board[nCount / N, nCount % N] != 0);

            Board[nCount / N, nCount % N] = rnd.Next(2) * 2 + 2; //其值设为2或者4
        }

        #region 关于四个方向的业务逻辑
        private bool rightMove()
        {
            bool isMoved = false;
            for (int j = 0; j < Board.GetLength(0); j++) //针对所有的行
            {
                int x1 = -1, y1 = -1, value1 = -1;// x2=-1, y2=-1,value2=-1;
                for (int i = Board.GetLength(1) - 1; i > -1; i--) //从右边起，针对每个块进行处理
                {
                    if (Board[j, i] == 0) continue; //空的块不处理
                    if (Board[j, i] == value1)//如果与上一次找到的相等，则合并
                    {
                        Board[x1, y1] = Board[x1, y1] * 2;
                        Board[j, i] = 0;
                        value1 = -1;
                        Score += Board[x1, y1];
                        isMoved = true;
                    }
                    else
                    {
                        int k;
                        for (k = i + 1; k < Board.GetLength(1); k++) //向右找到一个非空的块
                        {
                            if (Board[j, k] > 0)
                                break;
                        }
                        if (k - 1 != i)//如果这个非空的块左边有空位置
                        {
                            isMoved = true;
                            Board[j, k - 1] = Board[j, i]; //“移动”到这里（将其上的数字显示到这里）
                            Board[j, i] = 0;
                        }
                        value1 = Board[j, k - 1]; //记下这个值（非空的块）
                        x1 = j;
                        y1 = k - 1;
                    }
                }
            }
            return isMoved;
        }
        private bool upMove()
        {
            bool isMoved = false;
            for (int i = 0; i < Board.GetLength(1); i++)
            {
                int x1 = -1, y1 = -1, value1 = -1;// x2=-1, y2=-1,value2=-1;
                for (int j = 0; j < Board.GetLength(0); j++)
                {
                    if (Board[j, i] != 0)
                    {
                        if (value1 < 0)
                        {
                            int k;
                            for (k = j - 1; k > -1; k--)
                            {
                                if (Board[k, i] > 0)
                                    break;
                            }
                            Board[k + 1, i] = Board[j, i];
                            if (k + 1 != j)
                            {
                                Board[j, i] = 0;
                                isMoved = true;
                            }
                            value1 = Board[k + 1, i];
                            x1 = k + 1;
                            y1 = i;
                        }
                        else
                        {
                            if (Board[j, i] == value1)//合并
                            {
                                Board[x1, y1] = Board[x1, y1] * 2;
                                Board[j, i] = 0;
                                value1 = -1;
                                Score += Board[x1, y1];
                                isMoved = true;
                            }
                            else
                            {
                                int k;
                                for (k = j - 1; k > -1; k--)
                                {
                                    if (Board[k, i] > 0)
                                        break;
                                }
                                Board[k + 1, i] = Board[j, i];
                                if (k + 1 != j)
                                {
                                    isMoved = true;
                                    Board[j, i] = 0;
                                }
                                value1 = Board[k + 1, i];
                                x1 = k + 1;
                                y1 = i;
                            }
                        }
                    }
                }

            }
            return isMoved;
        }

        private bool leftMove()
        {
            bool isMoved = false;
            for (int j = 0; j < Board.GetLength(0); j++)
            {
                int x1 = -1, y1 = -1, value1 = -1;// x2=-1, y2=-1,value2=-1;
                for (int i = 0; i < Board.GetLength(1); i++)
                {
                    if (Board[j, i] != 0)
                    {
                        if (value1 < 0)
                        {
                            int k;
                            for (k = i - 1; k > -1; k--)
                            {
                                if (Board[j, k] > 0)
                                    break;
                            }
                            Board[j, k + 1] = Board[j, i];
                            if (k + 1 != i)
                            {
                                isMoved = true;
                                Board[j, i] = 0;
                            }
                            value1 = Board[j, k + 1];
                            x1 = j;
                            y1 = k + 1;
                        }
                        else
                        {
                            if (Board[j, i] == value1)//合并
                            {
                                Board[x1, y1] = Board[x1, y1] * 2;
                                Board[j, i] = 0;
                                value1 = -1;
                                Score += Board[x1, y1];
                                isMoved = true;
                            }
                            else
                            {
                                int k;
                                for (k = i - 1; k > -1; k--)
                                {
                                    if (Board[j, k] > 0)
                                        break;
                                }
                                Board[j, k + 1] = Board[j, i];
                                if (k + 1 != i)
                                {
                                    isMoved = true;
                                    Board[j, i] = 0;
                                }
                                value1 = Board[j, k + 1];
                                x1 = j;
                                y1 = k + 1;
                            }
                        }
                    }
                }

            }
            return isMoved;
        }

 

        private bool downMove()
        {
            bool isMoved = false;
            for (int i = 0; i < Board.GetLength(1); i++)
            {
                int x1 = -1, y1 = -1, value1 = -1;// x2=-1, y2=-1,value2=-1;
                for (int j = Board.GetLength(0) - 1; j > -1; j--)
                {
                    if (Board[j, i] != 0)
                    {
                        if (value1 < 0)
                        {
                            int k;
                            for (k = j + 1; k < Board.GetLength(0); k++)
                            {
                                if (Board[k, i] > 0)
                                    break;
                            }
                            Board[k - 1, i] = Board[j, i];
                            if (k - 1 != j)
                            {
                                Board[j, i] = 0;
                                isMoved = true;
                            }
                            value1 = Board[k - 1, i];
                            x1 = k - 1;
                            y1 = i;
                        }
                        else
                        {
                            if (Board[j, i] == value1)//合并
                            {
                                Board[x1, y1] = Board[x1, y1] * 2;
                                Board[j, i] = 0;
                                value1 = -1;
                                Score += Board[x1, y1];
                                isMoved = true;
                            }
                            else
                            {
                                int k;
                                for (k = j + 1; k < Board.GetLength(0); k++)
                                {
                                    if (Board[k, i] > 0)
                                        break;
                                }
                                Board[k - 1, i] = Board[j, i];
                                if (k - 1 != j)
                                {
                                    Board[j, i] = 0;
                                    isMoved = true;
                                }
                                value1 = Board[k - 1, i];
                                x1 = k - 1;
                                y1 = i;
                            }
                        }
                    }
                }

            }
            return isMoved;
        }

        #endregion

        private bool IsGameOver()
        {
            int nCount = 0; //计算非空的格子的个数
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    if (Board[i, j] > 0) nCount++;                        
                }
            }
            if (nCount != N * N) return false;

            //如果满了，并且没有可以相邻相同（可合并），则GameOver
            for (int i = 0; i < Board.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < Board.GetLength(1) - 1; j++)
                {
                    if (Board[i, j] == 0) continue;
                    if (Board[i, j] == Board[i + 1, j] || Board[i, j] == Board[i, j + 1])
                        return false;
                }
            }
            return true;
        }

        private void 模式1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gameMode = 0;
            RefreshUI();
        }

        private void 模式2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gameMode = 1;
            RefreshUI();
        }

        private void 模式3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gameMode = 2;
            RefreshUI();
        }
        private void 模式4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gameMode = 3;
            RefreshUI();
        }

        private void 模式说明ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("自己猜");
        }

        private void 清除最高分ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _highestScore = 0;
            label3.Text = 0.ToString();
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("猜");
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //数组是引用类型
            int[,] BoardCopy =new int[N,N];
            //浅拷贝
            BoardCopy = (int[,])Board.Clone();
            Record record = new Record(Score, BoardCopy);
            records.Add(record);
            ToolStripMenuItem item = new ToolStripMenuItem(record.time.ToString() + " 得分:" + record.score);
            item.Click += (object ClickSender, EventArgs ClickE) =>
            {
                Score = record.score;
                this.Board = record.board;
                RefreshUI();
            };
            读取ToolStripMenuItem.DropDownItems.Add(item);
            //添加删除
            ToolStripMenuItem delItem = new ToolStripMenuItem(record.time.ToString() + " 得分:" + record.score);
            删除ToolStripMenuItem.DropDownItems.Add(delItem);
            delItem.Click += (object delsender, EventArgs delE) =>
            {
                records.Remove(record);
                删除ToolStripMenuItem.DropDownItems.Remove(delItem);
                读取ToolStripMenuItem.DropDownItems.Remove(item);
            };
            
        }
    }
    public class ChangeEventArgs
    {
        public int Value { get { return _value; } set { _value = value; } }
        private int _value;
        public ChangeEventArgs(int value)
        {
            this._value = value;
        }
    }
    [Serializable]
    public struct Record
    {
        public DateTime time;
        public int score;
        public int[,] board;
        public Record(int score,int[,] board)
        {
            this.score = score;
            this.board = board;
            time = DateTime.Now;
        }
    }
}