using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using AsyncDemo.Shared;
using static System.Net.Mime.MediaTypeNames;

namespace AsyncDemo.Client.Core
{
    public class Client
    {
        private Socket _communicationSocket;
        private SocketReader _reader;
        private SocketWriter _writer;

        public Client()
        {
            _communicationSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _communicationSocket.Connect(new IPEndPoint(IPAddress.Loopback, Consts.PORT));
            _reader = new SocketReader(_communicationSocket);
            _writer = new SocketWriter(_communicationSocket);
        }
		public void Send(string msg)
		{
            _writer.Write(msg);
        }

        public string Receive()
        {
            return _reader.Read();
		}
    }
}
