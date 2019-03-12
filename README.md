# C sharp homework
collection of C Sharp  learning homework 

- 爬虫

```
一个简单的异步爬虫。
1. 主线程首先异步调用GetMatches函数获得首页的内容，并用正则表达式提取要下载网址，return一个网址的hashtable
2. GetMatches函数完成后在getMatchCompleteCallback的回调函数中,获得hashtable，并异步调用downloadMatchAction下载文件，通过回调函数结束调用
3. 除了主线程，其他线程需要通过调用主线程更新界面
4. 4.网址Url通过类的属性来检查输入

```

