using UnityEngine;

[CreateAssetMenu(menuName = "GameData")]
public class GameData : ScriptableObject, ISerializationCallbackReceiver
{
    public int maxCollectibles = 3;

    public int gatheredCollectibles = 0;
    public int quizNbrBtnPressed = 0;
    public bool isDoorOpened = false;
    public bool isExitOpened = false;
    public bool isPlayerInMaze = false;
    public string[] collectibles;
    public string[] quizOrderCollectibles;

    public string fbQuizSolved = "Very good!";
    public string fbQuizWrongOrder = "Sorry, not the right order!";

    public void OnAfterDeserialize()
    {
        ResetGameData();
    }

    public void OnBeforeSerialize() { }

    public void AddCollectible(string collectibleColor)
    {
        int i = System.Array.IndexOf(collectibles, "");
        if ((System.Array.IndexOf(collectibles, collectibleColor) == -1) &&
            (i < collectibles.Length && i != -1))
        {
            collectibles[i] = collectibleColor;
            gatheredCollectibles++;
        }
    }

    public bool AllCollectiblesCollected()
    {
        return gatheredCollectibles == maxCollectibles;
    }

    public void ResetGameData()
    {
        isDoorOpened = false;
        isExitOpened = false;
        isPlayerInMaze = false;
        gatheredCollectibles = 0;
        quizNbrBtnPressed = 0;
        collectibles = new string[maxCollectibles];
        quizOrderCollectibles = new string[maxCollectibles];

        for (int i = 0; i < maxCollectibles; i++)
        {
            collectibles[i] = "";
            quizOrderCollectibles[i] = "";
        }
    }

    public void ResetOrderQuiz()
    {
        for (int i = 0; i < maxCollectibles; i++)
        {
            quizOrderCollectibles[i] = "";
        }
        quizNbrBtnPressed = 0;
    }

}
