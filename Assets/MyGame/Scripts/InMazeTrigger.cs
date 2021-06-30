using UnityEngine;

public class InMazeTigger : MonoBehaviour
{
    private const string HeadCollider = "HeadCollider";
    public GameData gameData;

    private void OnTriggerEnter(Collider other)
    {
        if (!gameData.isPlayerInMaze && other.name == HeadCollider)
        {
            gameData.isPlayerInMaze = true;
        }
    }
}
