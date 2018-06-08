using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {

    [SerializeField]
    PlayerHealth playerHealth;
    Animator animator;
    Rigidbody2D Rigid;
    public int MonsterHP = 100;
    public float MonsterMoveSpeed = 1f;
    private int moveChange = 0;
    public int MonsterAttack = 20;

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
            foreach(Collider2D col in this.gameObject.GetComponentsInChildren<Collider2D>())
            {
                col.enabled = false;
            }
            Rigid.constraints = RigidbodyConstraints2D.FreezeAll;
            //에니메이션
            
            MonsterMoveSpeed = 0f;
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
        Debug.Log("moveChange");
        
        if (moveChange == 0)
            animator.SetBool("IsMoving", false);
        else
            animator.SetBool("IsMoving", true);
            
        yield return new WaitForSeconds(2f);

        Debug.Log("WaitForSeconds");

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
        }
        if (other.gameObject.tag == "Player")
        {
            playerHealth.Damage(MonsterAttack);
        }
    }

}
