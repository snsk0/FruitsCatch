using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FruitsGenerator : MonoBehaviour
{
    [SerializeField] private Transform poolParent;
    [SerializeField] private Fruit prefab;          //フルーツプレハブ
    [SerializeField] private Vector3 offset;        //座標の範囲を決める。正の値を入れる。±。(乱数範囲)

    private FruitsPool pool;

    void Start()
    {
        pool = new FruitsPool(prefab, poolParent);
    }



    public void FruitsGenerate()
    {
        Fruit ca = pool.Rent();

        Vector3 pos = new Vector3(UnityEngine.Random.Range(-offset.x, offset.x),
                                    UnityEngine.Random.Range(-offset.y, offset.y),
                                    UnityEngine.Random.Range(-offset.z, offset.z));
        ca.transform.position = pos + transform.position;

        //回転させる
        ca.rb.AddTorque(new Vector3(0, 0, UnityEngine.Random.Range(-5, 5)), ForceMode.Impulse);
    }
}
