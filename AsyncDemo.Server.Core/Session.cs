using AsyncDemo.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AsyncDemo.Server.Core
{
    public class Session
    {
		private Socket _communicationSocket;
		private SocketReader _reader;
		private SocketWriter _writer;

		public Session(Socket communicationSocket)
		{
			_communicationSocket = communicationSocket;
			_reader = new SocketReader(_communicationSocket);
			_writer = new SocketWriter(_communicationSocket);
		}

		public void Run()
		{
			while (true)
			{
				Receive();
			}
		}

		public void Send(string msg)
		{
			Console.WriteLine($"Is being sent to Client ({_communicationSocket.RemoteEndPoint}): {msg}");
			_writer.Write(msg);
		}

		public void Receive()
		{
			string msg = _reader.Read();
			Console.WriteLine($"Received by Client ({_communicationSocket.RemoteEndPoint}): {msg}");
			SessionHandler.DistributeMessage(msg, this);
		}
	}
}
