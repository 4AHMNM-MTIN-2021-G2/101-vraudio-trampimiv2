using UnityEngine;

public class Collectible : MonoBehaviour
{
    public string collectibleColor;
    public bool isClollected;
    public GameData gameData;

    private void OnCollisionEnter(Collision collision)
    {
        gameData.AddCollectible(collectibleColor);
        Destroy(gameObject);
    }
}
