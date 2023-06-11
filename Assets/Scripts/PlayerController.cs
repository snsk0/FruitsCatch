using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FruitsCatchEvents;
using UniRx;


//�v���R���|�[�l���g
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(Animator))]


public class PlayerController : MonoBehaviour
{
    //�p�����[�^
    [SerializeField] private float moveForceMultiplier;
    [SerializeField] private float moveSpeed;

    //private
    private PlayerInput inputer;   //Inputter
    private Rigidbody rb;
    private Animator animator;


    private void Start()
    {
        //�R���|�[�l���g�擾
        inputer = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        //�C�x���g�o�^
        inputer.OnInput.Where(e => e is FCInputMoveEvent).Subscribe(e => OnFCInputMoveEvent((FCInputMoveEvent)e));
    }



    //�ړ�
    private void OnFCInputMoveEvent(FCInputMoveEvent e)
    {
        rb.AddForce(moveForceMultiplier * (-e.moveVector.normalized * moveSpeed - rb.velocity), ForceMode.Acceleration);
        animator.SetInteger("Direction", (int)e.moveVector.x);
    }
}
