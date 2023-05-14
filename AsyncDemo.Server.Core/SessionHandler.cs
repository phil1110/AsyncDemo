using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncDemo.Server.Core
{
	public static class SessionHandler
	{
		private static List<Session> _sessions = new List<Session>();
		private readonly static object SessionLock = new object();

		public static void AddSession(Session session)
		{
			lock (SessionLock)
			{
				_sessions.Add(session);
			}
		}

		public static void RemoveSession(Session session)
		{
			lock (SessionLock)
			{
				_sessions.Remove(session);
			}
		}

		public static List<Session> GetSessions()
		{
			return _sessions;
		}

		public static void DistributeMessage(string msg, Session sender)
		{
			foreach (Session session in _sessions)
			{
				if(sender != session)
				{
					session.Send(msg);
				}
			}
		}
	}
}
