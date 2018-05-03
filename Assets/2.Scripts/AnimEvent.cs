using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimEvent : MonoBehaviour {

    public PlayerCtr player;
    
    public void CallEvent(string method)
    {
        //player.SendMessage(method);

        switch (method)
        {
            case "AttackOn":
                player.Speed = player.AttackMoveSpeed;

                break;

            case "AttackEnd":
                player.AttackEnd();
                player.Speed = player.MoveSpeed;
                break;

        }
    }
}
