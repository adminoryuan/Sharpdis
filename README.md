 - # Sharpdis 
-  Sharpdis 是基于c# 实现的 redis 服务端,网络模块采用dotNetty实现
-  ![效果图](https://github.com/adminoryuan/img/blob/master/a.jpeg)
 -  
 - # 数据结构
 - [x] String
 - [x] Set
 - [x] List
 - [x] hash
 - [ ] zset 
 - # 通信协议
 - [x] RESP 实现
 - # 网络模型
 - [x] 采用reactor模型
 - # 持久化
 - [ ] Aof
 - [ ] RDB
- # 集群
-  [ ] 使用raft 构建集群
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
 - 测试结果
 ```bash
   PING_INLINE: 18751.17 requests per second
PING_BULK: 18705.57 requests per second
SET: 20242.91 requests per second
GET: 18754.69 requests per second
INCR: 18839.49 requests per second
LPUSH: 16363.93 requests per second
RPUSH: 16249.59 requests per second
LPOP: 18807.60 requests per second
RPOP: 18268.18 requests per second
SADD: 17503.94 requests per second
SPOP: 18570.10 requests per second
LPUSH (needed to benchmark LRANGE): 16353.23 requests per second
LRANGE_100 (first 100 elements): 3068.90 requests per second
LRANGE_300 (first 300 elements): 440.29 requests per second
LRANGE_500 (first 450 elements): 291.50 requests per second
LRANGE_600 (first 600 elements): 197.02 requests per second
MSET (10 keys): 16798.25 requests per second
 ```
