using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {

    public Rigidbody2D Rigid;
    public int MonsterHP = 100;
    public float MosterMoveSpeed = 1f;
    

    // Use this for initialization
    void Start () {

       Rigid = GetComponent<Rigidbody2D>();
       
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
        
    }

    void MosterMove()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Weapon")
        {
            MonsterHP -= 20;    
        }
    }

}
