using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealth : MonoBehaviour {

    public GameObject player;
    public int MonsterHP = 100;
    public Rigidbody2D rb;


	// Use this for initialization
	void Start () {
       rb = GetComponent<Rigidbody2D>();
       
	}
	
	// Update is called once per frame
	void Update () {
		
        if(MonsterHP <= 0)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            Destroy(gameObject, 2);
        }

	}

    private void FixedUpdate()
    {
        if(tag == "Weapon")
        {
         
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Weapon")
        {
            MonsterHP -= 20;    
        }
    }

}
