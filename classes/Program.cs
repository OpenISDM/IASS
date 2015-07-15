//
//
//using System;
//using System.Threading;
//using System.Collections.Generic;
//
//namespace x3
//{
//	public class Program
//	{
//		public static void Main()
//		{
//			Dictionary <String, MonitoredObject> MODictrionary = new Dictionary<String, MonitoredObject> ();
//			List <MonitoredCondition> MCList = new List <MonitoredCondition> ();
//			List <Notification> notificationList = new List<Notification> ();
//			Dictionary <String, int> timerTable = new Dictionary <String, int> ();
//
//			EventWaitHandle[] doneEvent = new EventWaitHandle[2];
//
//			RequestListner requestListner = new RequestListner (doneEvent [0]);
////			 TODO Thread requestListnerThread = new Thread (new ThreadStart(requestListner.    ));
//
//			ThreadPool threadPool = new ThreadPool ();
//
//			RequestHandler requesthandler = new RequestHandler (doneEvent [1]);
//			// TODO Thread requestHandlerThread = new Thread (new ThreadStart(requesthandler.   ));
//
//			Scheduler scheduler = new Scheduler (doneEvent[2]);
//			//TODO Thread schedulerThread = new Thread (new ThreadStart(scheduler.    ));
//
//			//requestListnerThread.join();
//			//requestHandlerThread.join();
//			//schedulerThread.join(();
//
//
//
//		}
//			
//	}
//}
//
//
//
//
//
//
//
