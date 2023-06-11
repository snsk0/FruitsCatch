using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FruitsCatchEvents;
using UniRx;


//要求コンポーネント
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(Animator))]


public class PlayerController : MonoBehaviour
{
    //パラメータ
    [SerializeField] private float moveForceMultiplier;
    [SerializeField] private float moveSpeed;

    //private
    private PlayerInput inputer;   //Inputter
    private Rigidbody rb;
    private Animator animator;


    private void Start()
    {
        //コンポーネント取得
        inputer = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        //イベント登録
        inputer.OnInput.Where(e => e is FCInputMoveEvent).Subscribe(e => OnFCInputMoveEvent((FCInputMoveEvent)e));
    }



    //移動
    private void OnFCInputMoveEvent(FCInputMoveEvent e)
    {
        rb.AddForce(moveForceMultiplier * (-e.moveVector.normalized * moveSpeed - rb.velocity), ForceMode.Acceleration);
        animator.SetInteger("Direction", (int)e.moveVector.x);
    }
}
