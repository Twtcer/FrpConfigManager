using FrpConfigManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrpConfigManager.Model
{
    public interface IFrpConfig
    { 
    }

    public class Comm : IFrpConfig
    {
        public string Name { get; set; } = "common";
        public FrpConfigType ConfigType { get; set; } = FrpConfigType.Common;
        /// <summary>
        /// # A literal address or host name for IPv6 must be enclosed 
        /// </summary>
        public string server_addr { get; set; }
        /// <summary>
        ///   # in square brackets, as in "[::1]:80", "[ipv6-host]:http" or "[ipv6-host%zone]:80"
        /// </summary>
        public string server_port { get; set; } = "7000";
        /// <summary>
        /// # console or real logFile path like ./frpc.log
        /// </summary>
        public string log_file { get; set; } = " ./ frpc.log";
        /// <summary>
        ///  # trace, debug, info, warn, error
        /// </summary>
        public string log_level { get; set; } = "info";
        public string log_max_days { get; set; } = "3";
        /// <summary>
        /// # for authentication
        /// </summary>
        public string token { get; set; } = "12345678";

        /// <summary>
        /// control panel 
        /// # set admin address for control frpc's action by http api such as reload
        /// </summary>
        public string admin_addr { get; set; } = "127.0.0.1";
        public string admin_port { get; set; } = "7400";
        public string admin_user { get; set; } = "admin";
        public string admin_passwd { get; set; } = "admin";

        /// <summary>
        /// # connections will be established in advance, default value is zero
        /// </summary>
        public string pool_count { get; set; } = "5";
        /// <summary>
        /// # if tcp stream multiplexing is used, default is true, it must be same with frps
        /// </summary>
        public string tcp_mux = "true";
        /// <summary>
        /// # your proxy name will be changed to {user}.{proxy}
        /// </summary>
        public string user { get; set; } = "your_name";

        /// <summary>
        /// # decide if exit program when first login failed, otherwise continuous relogin to frps # default is true 
        /// </summary>
        public string login_fail_exit { get; set; } = "true";
        /// <summary>
        /// # communication protocol used to connect to server
        ///# now it supports tcp and kcp, default is tcp
        /// </summary>
        public string protocol { get; set; } = "tcp";
        /// <summary>
        /// # specify a dns server, so frpc will use this instead of default one
        /// </summary>
        public string dns_server { get; set; } = "8.8.8.8";
        /// <summary>
        /// # proxy names you want to start divided by ','
        ///# default is empty, means all proxies
        /// </summary>
        public string start = "ssh,dns";
        /// <summary>
        /// # heartbeat configure, it's not recommended to modify the default value
        ///# the default value of heartbeat_interval is 10 and heartbeat_timeout is 90
        /// </summary>
        public string heartbeat_interval { get; set; } = "30";
        public string heartbeat_timeout { get; set; } = "90";
    }

    public class SSH : IFrpConfig
    {
        public string Name { get; set; } = "ssh";
        public FrpConfigType ConfigType { get; set; } = FrpConfigType.Appliction;
        /// <summary>
        /// # tcp | udp | http | https | stcp | xtcp, default is tcp
        /// </summary>
        public string type { get; set; } = "tcp";
        public string local_ip { get; set; } = "127.0.0.1";
        public string local_port { get; set; } = "22";
        public string use_encryption { get; set; } = "false";
        public string use_compression { get; set; } = "false";
        public string remote_port { get; set; } = "6001";
        public string group { get; set; } = "test_group";
        public string group_key { get; set; } = "123456";
    }

    public class Web : IFrpConfig
    {
        public string Name { get; set; } = "web";
        public FrpConfigType ConfigType { get; set; } = FrpConfigType.Appliction;

        public string type { get; set; } = "http";
        public string local_ip { get; set; } = "127.0.0.1";
        public string local_port { get; set; } = "80";
        public string use_encryption { get; set; } = "false";
        public string use_compression { get; set; } = "true";
        /// <summary>
        /// # http username and password are safety certification for http protocol
        ///#if not set, you can access this custom_domains without certification
        /// </summary>
        public string http_user { get; set; } = "admin";
        public string http_pwd { get; set; } = "admin";
        /// <summary>
        /// # if domain for frps is frps.com, then you can access [web01] proxy by URL http://test.frps.com
        /// </summary>
        public string subdomain { get; set; } = "web01";
        public string custom_domains { get; set; } = "web02.yourdomain.com";
        /// <summary>
        /// # locations is only available for http type
        /// </summary>
        public string locations { get; set; } = "/,/pic";
        /// <summary>
        /// 
        /// </summary>
        public string host_header_rewrite { get; set; } = "example.com";
        public string header_X_From_Where { get; set; } = "frp";

    }
}
