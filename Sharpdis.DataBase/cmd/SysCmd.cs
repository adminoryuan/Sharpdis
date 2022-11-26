using Sharpdis.Common.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sharpdis.DataStructure.cmd
{
     static class SysCmd
    {
        public static void RegistCmd()
        {
            CmdTable.RegistCmd("info", new Func<string[], RespResEntity>(cmd =>
            {
                var body = "# Server\r\nredis_version:5.0.14.1\r\nredis_git_sha1:ec77f72d\r\nredis_git_dirty:0\r\nredis_build_id:5627b8177c9289c\r\nredis_mode:standalone\r\nos:Windows\r\narch_bits:64\r\nmultiplexing_api:WinSock_IOCP\r\natomicvar_api:pthread-mutex\r\nprocess_id:15004\r\nrun_id:77046dca35743999a950450bd9ba212dab414259\r\ntcp_port:6379\r\nuptime_in_seconds:7\r\nuptime_in_days:0\r\nhz:10\r\nconfigured_hz:10\r\nlru_clock:8436199\r\nexecutable:C:\\Users\\Administrator\\redis-server\r\nconfig_file:\r\n\r\n# Clients\r\nconnected_clients:4\r\nclient_recent_max_input_buffer:2\r\nclient_recent_max_output_buffer:0\r\nblocked_clients:0\r\n\r\n# Memory\r\nused_memory:1299552\r\nused_memory_human:1.00M\r\nused_memory_rss:1236664\r\nused_memory_rss_human:1.00M\r\nused_memory_peak:1299560\r\nused_memory_peak_human:1.00M\r\nused_memory_peak_perc:100.00%\r\nused_memory_overhead:763076\r\nused_memory_startup:661216\r\nused_memory_dataset:536476\r\nused_memory_dataset_perc:84.04%\r\nallocator_allocated:39153232\r\nallocator_active:432013312\r\nallocator_resident:436207616\r\ntotal_system_memory:0\r\ntotal_system_memory_human:0B\r\nused_memory_lua:37888\r\nused_memory_lua_human:37.00K\r\nused_memory_scripts:0\r\nused_memory_scripts_human:0B\r\nnumber_of_cached_scripts:0\r\nmaxmemory:0\r\nmaxmemory_human:0B\r\nmaxmemory_policy:noeviction\r\nallocator_frag_ratio:11.03\r\nallocator_frag_bytes:392860080\r\nallocator_rss_ratio:1.01\r\nallocator_rss_bytes:4194304\r\nrss_overhead_ratio:0.00\r\nrss_overhead_bytes:-434970952\r\nmem_fragmentation_ratio:1.00\r\nmem_fragmentation_bytes:0\r\nmem_not_counted_for_evict:0\r\nmem_replication_backlog:0\r\nmem_clients_slaves:0\r\nmem_clients_normal:101484\r\nmem_aof_buffer:0\r\nmem_allocator:jemalloc-5.2.1-redis\r\nactive_defrag_running:0\r\nlazyfree_pending_objects:0\r\n\r\n# Persistence\r\nloading:0\r\nrdb_changes_since_last_save:0\r\nrdb_bgsave_in_progress:0\r\nrdb_last_save_time:1669380576\r\nrdb_last_bgsave_status:ok\r\nrdb_last_bgsave_time_sec:-1\r\nrdb_current_bgsave_time_sec:-1\r\nrdb_last_cow_size:0\r\naof_enabled:0\r\naof_rewrite_in_progress:0\r\naof_rewrite_scheduled:0\r\naof_last_rewrite_time_sec:-1\r\naof_current_rewrite_time_sec:-1\r\naof_last_bgrewrite_status:ok\r\naof_last_write_status:ok\r\naof_last_cow_size:0\r\n\r\n# Stats\r\ntotal_connections_received:4\r\ntotal_commands_processed:6\r\ninstantaneous_ops_per_sec:0\r\ntotal_net_input_bytes:248\r\ntotal_net_output_bytes:9768\r\ninstantaneous_input_kbps:0.00\r\ninstantaneous_output_kbps:0.00\r\nrejected_connections:0\r\nsync_full:0\r\nsync_partial_ok:0\r\nsync_partial_err:0\r\nexpired_keys:0\r\nexpired_stale_perc:0.00\r\nexpired_time_cap_reached_count:0\r\nevicted_keys:0\r\nkeyspace_hits:0\r\nkeyspace_misses:0\r\npubsub_channels:0\r\npubsub_patterns:0\r\nlatest_fork_usec:0\r\nmigrate_cached_sockets:0\r\nslave_expires_tracked_keys:0\r\nactive_defrag_hits:0\r\nactive_defrag_misses:0\r\nactive_defrag_key_hits:0\r\nactive_defrag_key_misses:0\r\n\r\n# Replication\r\nrole:master\r\nconnected_slaves:0\r\nmaster_replid:b1a24761326c13a31bba4e0449570a5fa6f2ae06\r\nmaster_replid2:0000000000000000000000000000000000000000\r\nmaster_repl_offset:0\r\nsecond_repl_offset:-1\r\nrepl_backlog_active:0\r\nrepl_backlog_size:1048576\r\nrepl_backlog_first_byte_offset:0\r\nrepl_backlog_histlen:0\r\n\r\n# CPU\r\nused_cpu_sys:0.062500\r\nused_cpu_user:0.046875\r\nused_cpu_sys_children:0.000000\r\nused_cpu_user_children:0.000000\r\n\r\n# Cluster\r\ncluster_enabled:0\r\n\r\n# Keyspace\r\ndb0:keys=7,expires=0,avg_ttl=0";
                return new RespResEntity(true, body);

            }));

            CmdTable.RegistCmd("client", new Func<string[], RespResEntity>(cmd =>
            {
                var body = "id=3 addr=127.0.0.1:57674 fd=11 name=redisinsight-common-fa998a52 age=189 idle=189 flags=N db=0 sub=0 psub=0 multi=-1 qbuf=0 qbuf-free=0 obl=0 oll=0 omem=0 events=r cmd=client\r\nid=4 addr=127.0.0.1:57675 fd=12 name=redisinsight-common-d093eb64 age=189 idle=189 flags=N db=0 sub=0 psub=0 multi=-1 qbuf=0 qbuf-free=0 obl=0 oll=0 omem=0 events=r cmd=client\r\nid=5 addr=127.0.0.1:57676 fd=13 name=redisinsight-common-4455449a age=189 idle=189 flags=N db=0 sub=0 psub=0 multi=-1 qbuf=0 qbuf-free=0 obl=0 oll=0 omem=0 events=r cmd=client\r\nid=6 addr=127.0.0.1:57683 fd=14 name= age=182 idle=0 flags=N db=0 sub=0 psub=0 multi=-1 qbuf=26 qbuf-free=32742 obl=0 oll=0 omem=0 events=r cmd=client";
                return new RespResEntity(true, body);

            }));
            CmdTable.RegistCmd("commad", new Func<string[], RespResEntity>(cmd =>
            {
                return new RespResEntity(true, "OK");
            }));
      

            CmdTable.RegistCmd("ping", new Func<string[], RespResEntity>(cmd =>
            {
                return new RespResEntity(true, "PONG");

            }));
            CmdTable.RegistCmd("auth", new Func<string[], RespResEntity>(cmd =>
            {

                var res = cmd[1].Equals("admin") && cmd[2].Equals("pwd");
                return new RespResEntity(res, res ? "！" : "！");
            }));
        
        }
    }
}
