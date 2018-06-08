using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public float PlayerMaxHP = 100f;
    public float PlayerMaxEP = 100f;
    public float PlayerHP;
    public float PlayerEP = 0f;
    public float isDamage;

    public Slider slider;


    private void Awake()
    {
        PlayerHP = PlayerMaxHP;
        slider.minValue = 0;
        slider.maxValue = PlayerMaxHP;
        slider.value = PlayerHP;
    }

    // Use this for initialization
    void Start () {
      	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Damage(int amount)
    {
        PlayerHP -= amount;
        slider.value = PlayerHP;

        if(PlayerHP <= 0)
        {
            Death();
        }
    }
    void Death()
    {

    }
}
