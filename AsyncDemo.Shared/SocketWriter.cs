using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace AsyncDemo.Shared
{
	public class SocketWriter
	{
		private Socket _communicationSocket;

		public SocketWriter(Socket communicationSocket)
		{
			_communicationSocket = communicationSocket;
		}

		public void Write(string msg)
		{
			_communicationSocket.Send(Encoding.UTF8.GetBytes(msg));
		}
	}
}
