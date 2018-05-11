﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {

    Animator animator;
    Rigidbody2D Rigid;
    public int MonsterHP = 100;
    public float MonsterMoveSpeed = 1f;
    private int moveChange = 0;


    // Use this for initialization
    void Start () {
    
        Rigid = GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        StartCoroutine("MovementCount");
	}
	
	// Update is called once per frame
	void Update () {
		
        if(MonsterHP <= 0)
        {
            Rigid.constraints = RigidbodyConstraints2D.FreezePositionX;
            Destroy(gameObject, 2);
        }
	}

    private void FixedUpdate()
    {
        MonsterMove();
    }

    IEnumerator MovementCount()
    {
        moveChange = Random.Range(0, 3);
        Debug.Log("addaf");
        
        if (moveChange == 0)
            animator.SetBool("IsMoving", false);
        else
            animator.SetBool("IsMoving", true);
            
        yield return new WaitForSeconds(1f);

        Debug.Log("addaf");

        StartCoroutine("MovementCount");
    }

    void MonsterMove()
    {

        if (moveChange == 1)
        {
            transform.Translate(Vector2.left * MonsterMoveSpeed * Time.fixedDeltaTime);
            transform.localScale = new Vector3(3f, 3f, 1f);
        }
        else if (moveChange == 2)
        {
            transform.Translate(Vector2.right * MonsterMoveSpeed * Time.fixedDeltaTime);
            transform.localScale = new Vector3(-3f, 3f, 1f);
        }
        

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Weapon")
        {
            MonsterHP -= 20;
            MonsterMoveSpeed = 0f;
        }
    }

}