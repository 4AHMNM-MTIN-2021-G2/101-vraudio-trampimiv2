using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeController : MonoBehaviour
{
    public GameObject entrance;
    public GameData myGameData;

    private AnimateDoorScript entranceAnim;

    // Start is called before the first frame update
    void Start()
    {
        entranceAnim = entrance.GetComponent<AnimateDoorScript>();  
    }

    // Update is called once per frame
    void Update()
    {
        if (myGameData.isDoorOpened && myGameData.isPlayerInMaze)
        {
            entranceAnim.DoorAnimationClosed();
        }
    }
    
}
