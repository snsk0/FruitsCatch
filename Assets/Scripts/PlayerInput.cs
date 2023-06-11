using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using FruitsCatchEvents;
using System;

public class PlayerInput : MonoBehaviour
{
    //イベント発行オブジェクト
    private Subject<FCInputEvent> subject = new Subject<FCInputEvent>();

    //購読側のみを公開(発行は不可能)
    public IObservable<FCInputEvent> OnInput
    {
        get { return subject; }
    }




    void Update()
    {
        //移動入力
        float x = Input.GetAxisRaw("Horizontal");
        subject.OnNext(new FCInputMoveEvent(new Vector3(x, 0, 0)));
    }
}
