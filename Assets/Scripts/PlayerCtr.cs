using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtr : MonoBehaviour {

    private Transform tr;
    Rigidbody2D rg;
    RaycastHit2D Hit;
    Animator anim;

    public float speed = 5.0f;
    public float jump = 5.0f;
    public int JPCount = 2;
    public bool IsJumpForce = false;
    public LayerMask GroundLayer;
    

    private void Awake()
    {
        tr = GetComponent<Transform>();
        rg = gameObject.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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

        Attack();

    }
    private void FixedUpdate()
    {
        if (Physics2D.Raycast(transform.position, Vector2.down, 0.71f, GroundLayer))
        {
            JPCount = 2;
        }
        Debug.DrawRay(transform.position, Vector2.down * 0.71f, Color.red);

        Move();
        Jump();
        
    }

    void Move()
    {
        /*
        if (Input.GetKey(KeyCode.S))
        {
            tr.Translate(Vector2.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            tr.Translate(Vector2.left * speed * Time.deltaTime);
        }
        */
        float xMove = Input.GetAxisRaw("Horizontal") * speed * Time.fixedDeltaTime;
        //float yMove = Input.GetAxis("Vertical") * speed * Time.fixedDeltaTime;
        this.transform.Translate(new Vector2(xMove, 0));
    }

    void Jump()
    {

        if (IsJumpForce == false)
        {
            return;
        }
        
        rg.velocity = Vector2.zero;
        Vector2 JPVelocity = new Vector2(0, jump);
        rg.AddForce(JPVelocity, ForceMode2D.Impulse);
        JPCount--;

        if (JPCount <= 0)
            JPCount = 0;
        IsJumpForce = false;

    }

    void Attack()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            //anim.SetTrigger("Attack");
            anim.SetBool("IsAttack", true);
        }
    }

    public void OffAttack()
    {
        anim.SetBool("IsAttack", false);
    }
    
}
