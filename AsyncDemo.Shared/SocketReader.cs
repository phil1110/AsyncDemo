using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace AsyncDemo.Shared
{
	public class SocketReader
	{
		private Socket _communicationSocket;

		public SocketReader(Socket communicationSocket)
		{
			_communicationSocket = communicationSocket;
		}

		public string Read()
		{
			byte[] msg = new byte[1024];
			int bytes = _communicationSocket.Receive(msg);

			string text = Encoding.UTF8.GetString(msg, 0, bytes);

			return text;
		}
	}
}
