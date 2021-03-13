using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForm.SignalR
{
    [HubName("FastHub")]
    public class FastHub:Hub
    {
        /// <summary>
        /// 服务方法
        /// </summary>
        /// <param name="name"></param>
        /// <param name="message"></param>
        public void Send(string name,string message)
        {
            //广播
            Clients.All.AddMessage(name,message);
        }

        /// <summary>
        /// 连接
        /// </summary>
        /// <returns></returns>
        public override Task OnConnected()
        {
            //
            MessageBox.Show("客户端连接，连接ID是: " + Context.ConnectionId);

            return base.OnConnected();
        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="stopCalled"></param>
        /// <returns></returns>
        public override Task OnDisconnected(bool stopCalled)
        {
            MessageBox.Show( "客户端断开连接，连接ID是: " + Context.ConnectionId);

            return base.OnDisconnected(true);
        }
    }
}
