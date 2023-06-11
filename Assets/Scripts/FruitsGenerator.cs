using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FruitsGenerator : MonoBehaviour
{
    [SerializeField] private Transform poolParent;
    [SerializeField] private Fruit prefab;          //�t���[�c�v���n�u
    [SerializeField] private Vector3 offset;        //���W�͈̔͂����߂�B���̒l������B�}�B(�����͈�)

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

        //��]������
        ca.rb.AddTorque(new Vector3(0, 0, UnityEngine.Random.Range(-5, 5)), ForceMode.Impulse);
    }
}
