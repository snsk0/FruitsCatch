using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FruitsCatchEvents
{
    //FCEvent
    public abstract class FCEvent
    {

    }

    //Input�C�x���g�I�u�W�F�N�g
    public abstract class FCInputEvent : FCEvent
    {

    }


    //�ړ��pInput�C�x���g
    public class FCInputMoveEvent : FCInputEvent
    {
        public Vector3 moveVector { get; }   //�ړ�����

        public FCInputMoveEvent(Vector3 moveVector)
        {
            this.moveVector = moveVector;
        }
    }


    //�J�n
    public class FCInputStartEvent : FCInputEvent
    {
    }

    //�X�g�b�v
    public class FCInputStopEvent : FCInputEvent
    {
    }





    //�L���b�`
    public class FCCatchObjectEvent : FCEvent
    {
        public Fruit ca { get; }

        public FCCatchObjectEvent(Fruit ca)
        {
            this.ca = ca;
        }
    }
}
