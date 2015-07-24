Pseudo Code and Data Structures 7 / 9

Data Structures:
MonitoredObjects: List of MonitoredObject
- List<MonitoredObject> _MonitoredObjects

MonitoredObject:
- Instance Var:
- int _currentValue
- int _validTime:
- int _lastUpdateTime
- int _nextUpdateTime
- int _shortestResponseTime
- int _monitoredObjectID: unique ID of each MO
- List<MonitoredConidition> _monitoredConditions: list of MonitoredCondition
- Methods:
- Contructor()
- AccessPath(): retrieve data from data source and update instance variables
- UpdateMonitoredCondition(): updates the _monitoredConditions list with current value

MonitoredCondition:
- Instance Var:
- bool _monitoredConditionResult: the result of MC, T / F
- Expression _monitoredConditionLogic: the expression of the MC
- List<MonitoredExpression> _monitoredExpressions: list of ME
- Methods:
- Constructor()
- UpdateMonitoredExpression(): update the list of ME with current value
- EvalMonitoredConditionResult(): evaluate the MC as a whole and update _monitoredConditionResult

MonitoredEpression:
- Instance Var:
- int _monitoredObjectID: the ID of the MO that the ME corresponds with
- int _currExpressionValue: the current value of the corresponding MO
- bool _monitoredExpressionResult: the result of the ME
- Expression _expression: the expression of the ME
- Methods:
- Constructor()
- CheckMonitoredExpression(): checks the ME and update _monitoredExpressionResult


Pseudo Code:
Work done by request listener thread (leader thread):

// Initialization itself

Try
//create runtime structs.
//allocate memory for global structs and queues: monitored object dictionary, monitored condition list, monitored conditions, notification informations, next update time table, and request process queue.
Catch exception type: memory error {
//Error Handling: TODO.
}

// (refers to C#  List, Dictionary Class)
for each structure {
if it is the first time to set up IASS (no previous information) {

//create structs.
		}
	else{
//create structs.
		Try
//Load previous information and states from files to set the structs.
		Initialization(...);
		Catch execution type: records loading error{
//Error Handling: TODO.
		}
	}
}

//Create the array of event wait handles to allow threads to communicate with each other by signaling and by waiting for signals. (refers to C# EventWaitHandle Class)

//In IASS’s current version, we have Reqeust Helper thread and Scheduler thread which needs to be initialized, so the size of event wait handles array is 2.
create EventWaitHandle initialFinished [ totalThreadNumber ];

for each initialFinished (in our program, two thread needs to be initialized) {
// set the event wait handles to AutoReset event that allows the main thread to block until an exiting thread has finished initialization.
	InitialFinished[ threadNumber].AutoReset (false)
}

//create another event wait handle to pause the RequestHelper Thread, and to resume it when RequestListener receive any of request.
create EventWaitHandle waitToProcessRequest;

//(refers to C# Thread, ThreadPool Class)
// check the number of available threads
availableThread = ThreadPool. GetAvailableThreads( );
if the number of available threads is not enough {
//Error Handling: TODO.
}

Try
// create thread for help request and scheduling the next update time.
// input a event wait handle to communication with other threads.
RequestHelperThread = ParameterizedThreadStart(..., InitialFinished[0],  waitToProcessRequest);
Catch exception type: thread error {
//Error Handling: TODO.
}

Try
// create threads for scheduler, it sleeps, and be awaken when time expired,new update time is added.
SchedulerThread = ParameterizedThreadStart(..., InitialFinished[1] );
Catch exception type: thread error {
//Error Handling: TODO.
}
//create worker thread pool
Try {
	create ThreadPool workerThreadPool;
}
Catch exception type: threadpool error {
//Error Handling: TODO.
}


//block the leader thread (RequestListener thread) until all of other threads finish initialization.
//waits for all the threads to call the .Set() method
initialFinished.WaitAll( );
if any of initialization fails {
//Error Handling: TODO.
}

//After initialization, start to wait for listening requests

while the program is not terminated {
//wait until receive a request
newRequest = WaitForRequest( ... ).

//Add the new request to request process queue.

//Since request process queue might be accessed concurrently (by RequestListener thread and RequestHelper thread), lock these code to ensure thread safety. (refers to C# Lock Class)

	lock {
	//add newRequest to requestProcessQueue;
	requestProcessQueue.Add(newRequest);
	}
//send a signal to RequestHelper thread to wake up it to process the new request.
	waitToProcessRequest.Set( );
}
Work done by Scheduler thread :

//Initialization…..

Try {
//check whether the next update time table is accessible.
}
Catch exception require data inaccessible {
//Error Handling: TODO.
}

// send a signal to RequestListener thread to notify the timer initialization is finished.
initialFinished.Set( );


//After initialization, compute the next wake up time. Then Scheduler sleeps until time expired or interrupted because of new update time added.
while the program is not terminated {
// Load the first next update time from next update time table.

//Since next update time table might be accessed concurrently (by Scheduler thread and RequestHelper thread), lock these code to ensure thread safety. (refers to C# Lock Class)

lock {
	If the next update time table is empty{
		//Sleep until new update time is added.
	}

//Read  the next update time in table;
	currentUpdateWorkItem = nextUpdateTimeTable.getNextMonitoredObject();

		nextUpdateTime = currentUpdateWorkItem.nextUpdateTime;


// scheduling the next update time of the monitored objects, according to update frequency.
		newNextUpdateTime = schedule (monitored object).

// update next update time table with new next update time.
		nextUpdateTimeTable.Update(newNextUpdateTime );
// sort the dispatch table with new next update time.
		nextUpdateTimeTable.Sort( );

	}// end of lock

//Compute the difference between next update time and current time to decide when the Scheduler should wake up.
	timeDiff = currentTime - nextUpdateTime;

//In the update time,or the update time is expired,.
	if the timeDiff larger than 0 {
	//let the thread to sleep, until the next update time
	Thread.Sleep (timeDiff);
	}

	if the thread is interrupted{
	//enter next loop to get new first next update time.
	continue;
}
else{
//Get the  update workItem of the monitored object from monitored object dictionary

//Add the workItem to the work queue of workerThreadPool.
	workerThreadPool.QueueUserWorkItem(
	    new waitCallback(currentUpdateWorkItem) );
	}

}



Work done by RequestHelper thread:
// Initialization….

Try {
//check all the structures are  accessible. Including request process queue, next update time table, monitored object dictionary, monitored condition list,  etc..
}
Catch exception require data inaccessible {
//Error Handling: TODO.
}
// send a signal to RequestListener thread to notify initialization of the thread is finished.
initialFinished.Set( );


//After initialization…

while the program is not terminated {
if the requestProcessQueue is empty {
//blocked and wait to process new request.
	waitToProcessRequest. WaitOne( );
	}

// Once the waitToProcessRequest receive a signal, the following code will be executed.
	while the requestProcessQueue is not empty{

//Since request process queue might be accessed concurrently (by RequestListener thread and RequestHelper thread), lock these code to ensure thread safety. (refers to C# Lock Class)
	lock {
		// get the next request in requestProcessQueue.

		//Processing Browsing
		TODO:


// Processing request

// create temporary structs to contain input information of the request, including API key, Monitored Condition, notification information, and response time.

//Parse the monitored condition of the request.
		if parsing success{
			// get monitored object list used in this request.
			for each monitored objects in the list{
				Try{
//get type, valid time, value range from monitored object dictionary.
				}
				MonitorObjectDictionay.GetObjectInformation(...);
					Catch exception of monitored object{
//Error Handling: TODO.
					}

// verify monitored conditions in the request (which in terms of value of monitored objects) with the type, valid time and value ranges of the monitored objects.

					if all verification succeed {
// update Monitored condition list, Monitored condition dictionary.

// scheduling the next update time of related monitored objects, according to update frequency .
					newNextUpdateTime = schedule (monitored object).

// update next update time table with new next update time.
						newNextUpdateTimeTable.Update(newNextUpdateTime);

						else{
// return error code to show the reasons of verification failure.
						}

					} //end “for each monitored object”

// sort dispatch table with new next update time.
					newNextUpdateTimeTable.Sort( );

//interrupt scheduler thread to check if the first next update time is changed
					schedulerThread.interrupt( );
				}
				else{
					//return error code to show the reasons of parsing failure.
				}
			} // end “while the requestProcessQueue is not empty”

		}
	}


	Work done by a thread in threadPool (content of UpdateWorkItem):
	--------------In thread which executes currentUpdateWorkItem---------- -
//if a monitored object is added to queue


	Try{
// execute access path
	}
	currentValue = mointoredObjectDictionary [ monitored object ID ].ExecuteAccessPath(...).
	Catch exception: executing error{
//Error Handling: TODO.
	}

	if new value returns, and different with previous value{
//construct a condition checking queue for this thread to contain compound monitored conditions.
	create private conditionCheckingQueue;
	// update monitored object with new value.
	mointoredObjectDictionary [ monitored object ID ].UpdateCurrentValue(...).

		for each monitored condition (in terms of value of monitored objects) {
//get monitored condition from monitored condition dictionary
			primeCondtion =
			MonitoredConditionDictionary [monitored object ID].getConditionFromList(...);

//check monitored conditions
			Evaluate (primeCondition, currentValue)
			if monitored condition matches {
			//add related (compound) monitored condition to condition checking queue.
			conditionCheckingQueue.Add (
			    primeCondition.monitoredConditionIDList);
			}
			P
		}
		for each monitored condition in conditionCheckingQueue{
		//evaluate monitored condition
//Since monitored condition might be accessed concurrently (by two or more threads in workerThreadPool), lock these code to ensure thread safety. (refers to C# Lock Class)
		lock {
			//get next item from condition checking queue.
			currentMonitoredCondition = conditionCheckingQueue.GetNextItem(...);
// get the condition expression from monitored condition dictionary, and evaluate it.
				Evaluate (monitoredConditionDictionary[ currentMonitoredCondition ]);

				if evaluation of currentMonitoredCondition returns TRUE{
//check whether this condition has sent notification in a short time to avoid sending notification of a same condition again and again.
				Difference(
				    monitoredConditionDictionary[ currentMonitoredCondition]
				    .lastNotifyTime);
					if the difference is smaller than a period{
//append list of pointer of notification lists, according to notification action type
					for each notificationActionType{
						notificationActions.AppendListToWorkItem(
						    currentMonitoredCondition.GetNotifcationList(....)
						);
						}
// update the last notify time of the monitored condition
						monitoredConditionDictionary[ currentMonitoredCondition]
						.lastNotifyTime = currentTime;
					}

				}// end “if evaluation of currentMonitoredCondition returns TRUE”
			}// end “lock”
		}// end “for each monitored condition in conditionCheckingQueue”


		for each notificationActionType{
//Put notificationWorkItems to the work queue of workerThreadPool.
		workerThreadPool.QueueUserWorkItem(
		    new waitCallback(NotificationWorkItem)
		);
		}
	}

