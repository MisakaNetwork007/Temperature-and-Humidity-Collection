## 项目介绍
    基于Modbus协议简单实现温湿度采集系统的Winforms项目。数据库使用SQL Server。


## 项目工具
    Visual Studio 2022
    SQL Server 2022
    SQL Server Management Studio 21  （可选）
    Modbus Slave    （可选）
    Virtual Serial Port Driver 6.9

## NuGet包
    Microsoft.EntityFrameworkCore
    Microsoft.EntityFrameworkCore.Design
    Microsoft.EntityFrameworkCore.SqlServer
    Microsoft.EntityFrameworkCore.Tools
    ScottPlot
    ScottPlot.WinForms
    System.IO.Ports

## 数据库文件
    测试用的数据库文件已备份在此项目中 "/数据库备份/Test.bak"
    使用前请还原到自己的数据库中

## 说明
###  项目如何连接到自己的数据库中
    在 "/Data/MyDbContext.cs" 中 OnConfiguring 方法中修改 optionsBuilder.UseSqlServer 参数里的连接字符串。

### 关于如何使用EntityFrameworkCore操作数据库
    请参考项目中 DBContextTest.cs

### 各数据表中数据的含义
    请参考项目中 DBDataTable.cs