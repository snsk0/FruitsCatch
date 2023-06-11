using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using FruitsCatchEvents;
using System;

public class PlayerInput : MonoBehaviour
{
    //�C�x���g���s�I�u�W�F�N�g
    private Subject<FCInputEvent> subject = new Subject<FCInputEvent>();

    //�w�Ǒ��݂̂����J(���s�͕s�\)
    public IObservable<FCInputEvent> OnInput
    {
        get { return subject; }
    }




    void Update()
    {
        //�ړ�����
        float x = Input.GetAxisRaw("Horizontal");
        subject.OnNext(new FCInputMoveEvent(new Vector3(x, 0, 0)));
    }
}
