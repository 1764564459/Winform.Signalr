using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SignalR.Client
{
    public partial class ClientForm : Form
    {
        /// <summary>
        /// 代理
        /// </summary>
        public IHubProxy HubProxy { get; set; }

        /// <summary>
        /// 服务端地址
        /// </summary>
        const string ServerUri = "http://localhost:8000/signalr";
        public HubConnection Connection { get; set; }
        public ClientForm()
        {

            InitializeComponent();
            ConnectAsync();
        }

        private async void ConnectAsync()
        {
            try
            {
                Connection = new HubConnection(ServerUri);
                Connection.Closed += Connection_Closed;

                // 创建一个集线器代理对象
                HubProxy = Connection.CreateHubProxy("FastHub");

                // 供服务端调用，将消息输出到消息列表框中
                HubProxy.On<string, string>("AddMessage",Receive );


                await Connection.Start();
            }
            catch (Exception ex)
            {
                // 连接失败
                richTextBox1.AppendText("Exception：" + ex.Message + "\r");
                return;
            }

            // 显示聊天控件
            richTextBox1.AppendText("连上服务：" + ServerUri + "\r");
        }


        private void Receive(string name,string message)
        {
            richTextBox1.AppendText(String.Format("Receive：{0}: {1}\r", name, message));
        }
        private void Connection_Closed()
        {
            richTextBox1.AppendText("关闭连接：");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 通过代理来调用服务端的Send方法
            // 服务端Send方法再调用客户端的AddMessage方法将消息输出到消息框中
            HubProxy.Invoke("Send", "Fast", $"Send Local Time ：{DateTime.Now:mm:ss}");
        }
    }
}
