using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FruitsCatchEvents
{
    //FCEvent
    public abstract class FCEvent
    {

    }

    //Inputイベントオブジェクト
    public abstract class FCInputEvent : FCEvent
    {

    }


    //移動用Inputイベント
    public class FCInputMoveEvent : FCInputEvent
    {
        public Vector3 moveVector { get; }   //移動方向

        public FCInputMoveEvent(Vector3 moveVector)
        {
            this.moveVector = moveVector;
        }
    }


    //開始
    public class FCInputStartEvent : FCInputEvent
    {
    }

    //ストップ
    public class FCInputStopEvent : FCInputEvent
    {
    }





    //キャッチ
    public class FCCatchObjectEvent : FCEvent
    {
        public Fruit ca { get; }

        public FCCatchObjectEvent(Fruit ca)
        {
            this.ca = ca;
        }
    }
}
