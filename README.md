# C sharp homework

- collection of C Sharp  learning homework 

- 完成北大[C#课程](https://www.icourse163.org/learn/PKU-1001663016?tid=1002052006#/)时所完成的课后作业。代表性的记录如下。

- 本库代码研二学习阶段代码，有很多不遵守规范之处，现代码质量请参考前端代码。

- 爬虫

```
一个简单的异步爬虫。
1. 主线程首先异步调用GetMatches函数获得首页的内容，并用正则表达式提取要下载网址，return一个网址的hashtable
2. GetMatches函数完成后在getMatchCompleteCallback的回调函数中,获得hashtable，并异步调用downloadMatchAction下载文件，通过回调函数结束调用
3. 除了主线程，其他线程需要通过调用主线程更新界面
4. 4.网址Url通过类的属性来检查输入

```

- Game2048

```
能够实现存取进度的简单2048游戏。
阅读说明：
1.源程序利用board数组实现了MVC的数据层与视图层的分离，使得数据逻辑的改变与表现相分离。
2.显示分数
3.添加选择模式
4.记录最高分（利用属性，自定义一个事件）
5.保存游戏记录（在正常打开和关闭时利用对象序列化存储数据，自定义需要存储的数据类型，注意数组是引用类型需要浅拷贝）
```

- 背单词-数据库版

```
使用了sqlite数据库 datareader dataadapter
当选择的单词意思错误时自动加入生词库
干扰项为随机抽取
单词的数据库事先由程序导入，导入部分程序不在本程序内
debug目录内为生成好程序，为了正确引入库请解压使用
```

- 身份证号检测

```
对输入框中输入的身份证是否合法进行验证.
//注意char和int的转换
                        //法1 int currentnum = '1'- '0';
                        // 法2 currentnum = int.TryParse('1'.ToString());
                        // 法3 currentnum = Convert.ToInt32('1'.ToString());
                        // 错误法4 (int)'1'
                        // 错误法5 Convert.ToInt32('1');
按回车提交 其中回车键的keychar 为 13
编译好文件在debug目录下
```

- 银行系统作业改进

```
利用委托、事件与异常等改进的“银行系统”。
1） BankDemo，atm 类中实现BigMoneyFetched的定义与注册
2）account 类中自定义了存取金额错误异常
3）BankDemo 类中利用Lambda表达式实现注册
4）部分方法 修饰符修改，改用异常处理错误

测试账号 1密码1 
编译好文件在debug目录里
vs2017环境
```
