# Sharpdis
![](https://img.shields.io/badge/mit-Passing-green)
![](https://img.shields.io/badge/c%23-9.0-green)
- 本项目目的使用实现c#来实现redis 服务端 ,项目使用.net 3.1实现,使用dotnetty 作为网络开发框架
- 本项并非完全复刻redis

![效果图](https://github.com/adminoryuan/img/blob/master/server.png) 
![效果图](https://github.com/adminoryuan/img/blob/master/a.png)

 # 如何使用
- 下载本仓库
- 运行Sharpdis.app 屏幕输出Sharpdis 则表示服务端运行成功
- 打开redis-cli 即可链接服务端

# 实现功能
 - # 数据类型
 - [x] String
 - [x] Set
 - [x] List
 - [x] hash
 - [x] zset
 - # 通信协议
 - [x] RESP 实现
 - # 网络模型
 - [x] 采用reactor模型
 - # 持久化
 - [x] Aof
 - [ ] RDB
- # 集群
-  [ ] 使用raft 构建集群

