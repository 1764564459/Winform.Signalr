using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForm
{
    public partial class MainForm : Form
    {
        private string _uri = "http://localhost:8000";

        IDisposable SignalR { get; set; }

        public MainForm()
        {
            InitializeComponent();
        }

        private void SendBtn_Click(object sender, EventArgs e)
        {
            try
            {
                SignalR = WebApp.Start(_uri);
                
            }
            catch (Exception ex)
            {
                SignalR.Dispose();
                MessageBox.Show(ex.Message);
            }

        }
    }
}
