# Holiday

#### 介绍
工作日、法定假日接口

#### 软件架构
.net 7 miniapi


#### 使用说明

配置在holiday.db文件中，使用的是sqlite  
只需要在holidayconfig维护数据即可。  
其中day字段为需要维护的日期,格式为 yyyy-MM-dd;
type自动为维护的日期类型, 0:假期,1:工作日。
另外,只需要配置法定的假期及调休即可(即普通周末、普通工作日不需要维护)。


请求接口为http://localhost:5000/getHoliday?start=2023-5-1&end=2023-5-30,
其中start、end两个参数为必填, release模式下不支持swagger。


启动ip及端口可以使用命令行参数传递
例：Holiday.exe --urls http://*:7000


#### 参与贡献

1.  Fork 本仓库
2.  新建 Feat_xxx 分支
3.  提交代码
4.  新建 Pull Request