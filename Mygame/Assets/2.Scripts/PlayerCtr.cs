using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtr : MonoBehaviour {

    Rigidbody2D Rigid;
    RaycastHit2D Hit;
    Animator Anim;

    public float Speed = 5.0f;
    public float MoveSpeed = 5.0f;
    public float AttackMoveSpeed = 2.5f;

    public float jump = 5.0f;
    public int JumpCount = 1;

    public bool IsJumpForce = false;
    public bool IsAttack = false;

    public LayerMask GroundLayer;
    private int horizontal;

    public Collider2D MoveableArea;

    private void Awake()
    {
        Rigid = gameObject.GetComponent<Rigidbody2D>();
        Anim = GetComponentInChildren<Animator>();
    }

    void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && JumpCount > 0)
        {
            IsJumpForce = true; 
        }

        AttackOn();

    }
    private void FixedUpdate()
    {
        if (Physics2D.Raycast(transform.position, Vector2.down, 0.4f, GroundLayer))
        {
            JumpCount = 1;
        }
        Debug.DrawRay(transform.position, Vector2.down * 0.4f, Color.red);

        Move();
        Jump();
        
    }

    private void LateUpdate()
    {
        transform.position = MoveableArea.bounds.ClosestPoint(transform.position);
    }

    void Move()
    {
       
        float xMove = Input.GetAxisRaw("Horizontal") * Speed * Time.fixedDeltaTime;
        this.transform.Translate(new Vector2(xMove, 0));

        if (xMove > 0)
        {
            Anim.SetInteger("Move", 1);
            transform.localScale = new Vector3(-0.3f, 0.3f, 0.3f);
        }
        else if (xMove < 0)
        {
            Anim.SetInteger("Move", 1);
            transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        }

        else Anim.SetInteger("Move", 0);

    }

    void Jump()
    {

        if (IsJumpForce == false)
        {
            return;
        }
        
        Rigid.velocity = Vector2.zero;
        Vector2 JPVelocity = new Vector2(0, jump);
        Rigid.AddForce(JPVelocity, ForceMode2D.Impulse);
        JumpCount--;

        if (JumpCount <= 0)
            JumpCount = 0;
        IsJumpForce = false;

    }

    public void AttackOn()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            if (IsAttack)
                return;

            IsAttack = true;
            Anim.SetTrigger("Attack");
        }
    }
    
    public void AttackEnd()
    {
        IsAttack = false;

        Anim.SetTrigger("Idle");
    }

}
