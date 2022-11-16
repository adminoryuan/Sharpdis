# Sharpdis
- # Sharpdis 是基于c# 实现的 redis
 - # 目的实现功能
 - # 数据结构
 - [x] String
 - [x] Set
 - [x] List
 - [x] hash
 - [ ] zset
 - # 基准测试
  
  ```bash redis-benchmark.exe -h 127.0.0.1 -p 6379 -c 100 -n 100000 -q ```
 - 硬件信息
  ```bash
系统类型:         x64-based PC(Windows)
处理器:           安装了 1 个处理器。
                  [01]: AMD64 Family 23 Model 24 Stepping 1 AuthenticAMD ~2100 Mhz
BIOS 版本:        LENOVO AGCN25WW(V1.08), 2019/11/13
物理内存总量:     10,179 MB
可用的物理内存:   2,911 MB
虚拟内存: 最大值: 13,251 MB
虚拟内存: 可用:   2,237 MB
虚拟内存: 使用中: 11,014 MB
 ```
 - 测试数据
 ```bash
   
 ```
 - # 实现命令
 
 - # 通信协议
 - [x] RESP 实现
 - # 网络模型
 - [x] 采用reactor模型
 - # 持久化
 - [ ] Aof
 - [ ] RDB
- # 集群
-  [ ] 使用raft 构建集群
