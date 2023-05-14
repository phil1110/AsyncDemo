using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsyncDemo.Server.Core;
using AsyncDemo.Shared;

namespace AsyncDemo.Server.UI
{
	internal class Program
	{ 
		static void Main(string[] args)
		{
			Core.Listener listener = new Core.Listener();
			Task.Run(() => listener.Listen());

			Console.ReadKey();
		}
	}
}
