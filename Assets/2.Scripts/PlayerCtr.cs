﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtr : MonoBehaviour {

    private Transform tr;
    Rigidbody2D rigid;
    RaycastHit2D Hit;
    Animator anim;

    public float Speed = 5.0f;
    public float MoveSpeed = 5.0f;
    public float AttackMoveSpeed = 2.5f;

    public float jump = 5.0f;
    public int JPCount = 2;
    public bool IsJumpForce = false;

    public LayerMask GroundLayer;
    private int horizontal;

    bool IsAttack = false;

    public object GetAnimator { get; private set; }

    private void Awake()
    {
        tr = GetComponent<Transform>();
        rigid = gameObject.GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    void Start()
    {
        
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && JPCount >0)
        {

            IsJumpForce = true; 
            
        }

        AttackOn();
    
    }
    private void FixedUpdate()
    {
        if (Physics2D.Raycast(transform.position, Vector2.down, 0.4f, GroundLayer))
        {
            JPCount = 2;
        }
        Debug.DrawRay(transform.position, Vector2.down * 0.4f, Color.red);

        Move();
        Jump();
        
    }

    void Move()
    {
        /*
        if (Input.GetKey(KeyCode.S))
        {
            tr.Translate(Vector2.right * MoveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            tr.Translate(Vector2.left * MoveSpeed * Time.deltaTime);
        }
        */
        
        float xMove = Input.GetAxisRaw("Horizontal") * Speed * Time.fixedDeltaTime;
        //float yMove = Input.GetAxis("Vertical") * MoveSpeed * Time.fixedDeltaTime;
        this.transform.Translate(new Vector2(xMove, 0));

        if (xMove > 0)
        {
            anim.SetInteger("Move", 1);
            transform.localScale = new Vector3(-0.3f, 0.3f, 0.3f);
            

        }
        else if (xMove < 0)
        {
            anim.SetInteger("Move", 1);
            transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        }

        else anim.SetInteger("Move", 0);

    }

    void Jump()
    {

        if (IsJumpForce == false)
        {
            return;
        }
        
        rigid.velocity = Vector2.zero;
        Vector2 JPVelocity = new Vector2(0, jump);
        rigid.AddForce(JPVelocity, ForceMode2D.Impulse);
        JPCount--;

        if (JPCount <= 0)
            JPCount = 0;
        IsJumpForce = false;

    }

    public void AttackOn()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            if (IsAttack)
                return;

            IsAttack = true;
            anim.SetTrigger("Attack");
            //anim.SetBool("IsAttack", true);
            
        }
    }
    
    public void AttackEnd()
    {
        IsAttack = false;

        anim.SetTrigger("Idle");
    }

}