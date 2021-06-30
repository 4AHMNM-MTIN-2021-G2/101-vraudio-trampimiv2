using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    private const string OPENDOOR = "openDoor";
    public GameData myGameData;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void StartOpenDoorAnimation()
    {
        animator.SetBool(OPENDOOR, true);
        myGameData.isDoorOpened = true;
    }

    public void StartCloseDoorAnimation()
    {
        animator.SetBool(OPENDOOR, false);
        myGameData.isDoorOpened = false;
    }

}
