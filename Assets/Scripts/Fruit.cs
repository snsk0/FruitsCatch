using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]

public class Fruit : MonoBehaviour
{
    //�I�u�W�F�N�g�^�C�v
    [SerializeField] private FruitsType _type;
    public FruitsType type
    { get { return _type; } }



    public Rigidbody rb { get; private set; }

    //�R�[���o�b�N�p
    public Action callback;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }



    //�ʏ�̕����I�u�W�F�N�g
    private void OnCollisionEnter(Collision collision)
    {
        //Catcher�ƏՓˁA���͂��̑��ŕ�����



        //�R�[���o�b�N�Ńv�[���ɖ߂�
        callback();
    }


    //���̂����
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
