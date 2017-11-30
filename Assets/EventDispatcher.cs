using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDispatcher : MonoBehaviour
{

    protected List<ListenerEvent> list = new List<ListenerEvent>();

    public void AddEventListener(string eventName, ListenerEvent.EventCallback eventCallback)
    {
        ListenerEvent listenerEvent = new ListenerEvent(eventName, eventCallback);
        list.Add(listenerEvent);
    }

    public void RemoveEventListener(string eventName, ListenerEvent.EventCallback eventCallback)
    {
        for (int i = list.Count - 1; i >= 0; i--)
        {
            ListenerEvent listenerEvent = list[i];
            if (listenerEvent.eventName == eventName && listenerEvent.eventCallback == eventCallback)
            {
                list.RemoveAt(i);
                listenerEvent.Destroy();
            }
        }
    }

    public void EventDispatch(string eventName)
    {
        //後ろから取らないとエラー
        for (int i = list.Count - 1; i >= 0; i--)
        {
            ListenerEvent listenerEvent = list[i];
            if (listenerEvent.eventName == eventName)
            {
                listenerEvent.eventCallback();
            }
        }
    }

    public void Destroy()
    {
        foreach (ListenerEvent listenerEvent in list)
        {
            listenerEvent.Destroy();
        }
        list = null;
    }
}
