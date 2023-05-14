using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AsyncDemo.Client.Core;

namespace AsyncDemo.Client.GUI
{
	public partial class Form1 : Form
	{
		Core.Client _client;
		Action<string> aReceive;

		public Form1()
		{
			InitializeComponent();
			_client = new Core.Client();
			aReceive = Receive;
			Task loop = Task.Run(() => ReceiveLoop());
		}

		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void textBox1_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				_client.Send(textBox1.Text);
				textBox1.Text = "";
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			_client.Send(textBox1.Text);
			textBox1.Text = "";
		}

		private void ReceiveLoop()
		{
			while (true)
			{
				Receive(_client.Receive());
			}
		}

		private void Receive(string text)
		{
			if (listBox1.InvokeRequired)
			{
				listBox1.Invoke(aReceive, text);
			}
			else
			{
				listBox1.Items.Add(text);
			}
		}
	}
}
