using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTest : EventDispatcher
{

	// Use this for initialization
	void Start ()
    {
        Invoke("EventAction", 5f);
	}

    private void EventAction()
    {
        EventDispatch("event_complete");
    }

}
