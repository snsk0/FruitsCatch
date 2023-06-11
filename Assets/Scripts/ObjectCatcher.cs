using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FruitsCatchEvents;
using UniRx;
using System;


//要求コンポーネント
[RequireComponent(typeof(Collider))]


public class ObjectCatcher : MonoBehaviour
{
    //イベント発行オブジェクト
    private Subject<FCCatchObjectEvent> subject = new Subject<FCCatchObjectEvent>();

    //購読側のみを公開(発行は不可能)
    public IObservable<FCCatchObjectEvent> OnCatch
    {
        get { return subject; }
    }


    private void OnTriggerEnter(Collider other)
    {
        Fruit ca = other.GetComponent<Fruit>();
        if(ca != null)
        {
            subject.OnNext(new FCCatchObjectEvent(ca));
        }
    }
}
