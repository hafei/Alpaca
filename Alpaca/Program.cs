using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Alpaca
{
    public class Program
    {
        /// <summary>
        /// 1. 本质是一个独立的控制台应用,不依赖IIS,正是跨平台的基础
        /// 2. 内置Self-Host的Web Server
        /// 3. 创建并启动一个Host完成应用程序的启动和生命周期的管理
        /// 4. Host的主要职责就是Web Server配置和Pipeline的构建 
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            //创建Web服务器
            CreateWebHostBuilder(args)
                .Build()   //2. 创建IWebHost
                .Run();    //3. 启动IWebHost
            //new WebHostBuilder();

        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)   //1. 创建IWebHostBuilder
                .UseKestrel()
                .UseStartup<Startup>();
    }
}
