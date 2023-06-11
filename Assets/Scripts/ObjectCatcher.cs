using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FruitsCatchEvents;
using UniRx;
using System;


//�v���R���|�[�l���g
[RequireComponent(typeof(Collider))]


public class ObjectCatcher : MonoBehaviour
{
    //�C�x���g���s�I�u�W�F�N�g
    private Subject<FCCatchObjectEvent> subject = new Subject<FCCatchObjectEvent>();

    //�w�Ǒ��݂̂����J(���s�͕s�\)
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
