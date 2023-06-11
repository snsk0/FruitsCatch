using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]

public class Fruit : MonoBehaviour
{
    //オブジェクトタイプ
    [SerializeField] private FruitsType _type;
    public FruitsType type
    { get { return _type; } }



    public Rigidbody rb { get; private set; }

    //コールバック用
    public Action callback;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }



    //通常の物理オブジェクト
    private void OnCollisionEnter(Collision collision)
    {
        //Catcherと衝突、又はその他で分ける



        //コールバックでプールに戻す
        callback();
    }


    //箱のうわ面
    private void OnTriggerEnter(Collider other)
    {
        callback();
    }
}



public enum FruitsType
{
    APPLE,
    GOLDEN_APPLE,
    STONE,
    BOMB
}
