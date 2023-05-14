using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using AsyncDemo.Shared;

namespace AsyncDemo.Server.Core
{
	public class Listener
	{
		private Socket _listener;

		public Listener()
		{
			_listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
		}

		public void Listen()
		{
			_listener.Bind(new IPEndPoint(IPAddress.Loopback, Consts.PORT));
			_listener.Listen(500);

			while (true)
			{
				Session client = new Session(_listener.Accept());

				SessionHandler.AddSession(client);
				Task.Run(() => client.Run());
			}
		}
	}
}
