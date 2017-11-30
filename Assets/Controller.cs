using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    // Use this for initialization
    EventTest eventTest;
    void Start ()
    {
        //まずEventTestゲームオブジェクトを見つける
        GameObject eventTestGameObject = GameObject.Find("EventTest") as GameObject;

        //次にEventTestゲームオブジェクトに張り付いてるEventTestインスタンス（EventTest.cs）を抽出
        eventTest = eventTestGameObject.GetComponent(typeof(EventTest)) as EventTest;
        Debug.Log(eventTest);

        //
        eventTest.AddEventListener("event_complete", EventAction);
    }

    private void EventAction()
    {
        Debug.Log("イベント受け取ったよ！！");

        //一応　Destroyしておく
        eventTest.RemoveEventListener("event_complete", EventAction);
        eventTest.Destroy();
        eventTest = null;
    }

}
