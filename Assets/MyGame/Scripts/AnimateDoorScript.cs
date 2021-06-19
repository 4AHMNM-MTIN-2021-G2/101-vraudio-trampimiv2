using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateDoorScript : MonoBehaviour
{
    public GameData myGameData;
    private Animator myAnimator;
    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame

    public void DoorAnimationOpen()
    {
        myAnimator.SetBool("openDoor", true);
    }
 }
