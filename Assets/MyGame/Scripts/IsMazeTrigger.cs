using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inMazeTrigger : MonoBehaviour
{

    public GameData myGameData;

    public void OnTriggerEnter(Collider other)
    {
        if (other.name == "BodyCollider")
        {
            myGameData.isPlayerInMaze = true;
        }
    }
}
