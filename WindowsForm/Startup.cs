using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using System;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(WindowsForm.Startup))]

namespace WindowsForm
{
    /// <summary>
    /// NuGet ：
    /// Microsoft.AspNet.SignalR.Core
    /// Microsoft.AspNet.SignalR.SelfHost
    /// 
    /// 参考地址：https://www.cnblogs.com/dongteng/p/8393432.html
    /// </summary>
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // 有关如何配置应用程序的详细信息，请访问 https://go.microsoft.com/fwlink/?LinkID=316888

            //启用跨域
            app.UseCors(CorsOptions.AllowAll);


            //启用SignalR
            app.MapSignalR();
        }
    }
}
