using System;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR.InteractionSystem;
using Valve.VR.InteractionSystem.Sample;

public class MazeController : MonoBehaviour
{
    public GameObject entrance, exit;
    public GameData gameData;
    public GameObject headCollider;
    public GameObject parentCollectibles;
    public Collectible prefabCollectible;
    public GameObject textFbQuiz;

    public Collectible[] collectibles;
    public GameObject[] collectiblesPositions;

    public Material[] btnMaterials;
    public GameObject[] btnObjects;

    public bool resetQuizBtns = false;

    private DoorAnimation entranceAnim, exitAnim;

    void Start()
    {
        entranceAnim = entrance.GetComponent<DoorAnimation>();
        exitAnim = exit.GetComponent<DoorAnimation>();
    }

    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
 
            exitAnim.StartOpenDoorAnimation();
        }
        if (!gameData.isPlayerInMaze && isPlayerInMaze(headCollider))
        {
            gameData.isPlayerInMaze = true;
        }

        if (!gameData.isPlayerInMaze)
        {
            return;
        }

        if (gameData.isDoorOpened)
        {
            entranceAnim.StartCloseDoorAnimation();
            gameData.isDoorOpened = false;
            return;
        }

      
        if (gameData.AllCollectiblesCollected())
        {
            if (!isQuizDone())
            {
                return;
            }

            if (isQuizSolved())
            {
                exitAnim.StartOpenDoorAnimation();
                textFbQuiz.GetComponent<Text>().text = gameData.fbQuizSolved;
            }
            else
            {
                textFbQuiz.GetComponent<Text>().text = gameData.fbQuizWrongOrder;
                resetQuizBtns = true;
            }
        }

        if (resetQuizBtns)
        {
            bool tmp = true;
            for (int i = 0; i < btnObjects.Length; i++)
            {
                tmp = tmp && !btnObjects[i].GetComponent<HoverButton>().engaged;
            }

            if (tmp)
            {
                ResetQuizBtns();
                resetQuizBtns = false;
            }
        }

    }

    private void ResetQuizBtns()
    {
        for (int i = 0; i < btnObjects.Length; i++)
        {
            Renderer[] renderers = btnObjects[i].GetComponentsInChildren<Renderer>();
            for (int rendererIndex = 0; rendererIndex < renderers.Length; rendererIndex++)
            {
                renderers[rendererIndex].material = btnMaterials[i];
            }
        }

        gameData.ResetOrderQuiz();
    }

    public void OpenEntrance()
    {
        if (!gameData.isDoorOpened)
        {
            entranceAnim.StartOpenDoorAnimation();
        }

    }
    public void OpenExit()
    {
        if (!gameData.isExitOpened)
        {
            exitAnim.StartOpenDoorAnimation();
        }
    }

    public bool isPlayerInMaze(GameObject head)
    {
        float minX = -4.23f, minZ = -4.82f;
        float maxX = -2.41f, maxZ = -4.23f;

        if ((head.transform.position.x > minX && head.transform.position.x < maxX) &&
            (head.transform.position.z > minZ && head.transform.position.z < maxZ))
        {
            return true;
        }

        return false;
    }

    public bool isQuizDone()
    {
        return gameData.quizNbrBtnPressed == gameData.maxCollectibles;
    }

    public bool isQuizSolved()
    {
        bool tmp = true;

        for (int i = 0; i < gameData.quizOrderCollectibles.Length; i++)
        {
            Debug.Log("inQuizSolved: " + gameData.quizOrderCollectibles[i] + " " + gameData.collectibles[i]);
            if (gameData.quizOrderCollectibles[i] == gameData.collectibles[i])
            {
                tmp = tmp && true;
            }
            else
            {
                tmp = tmp && false;
            }
        }

        return tmp;
    }


    public void AddBtnOrderCollectibles(string color)
    {

        int i = System.Array.IndexOf(gameData.quizOrderCollectibles, "");
        Debug.Log("in Add Btn" + i);
        if ((System.Array.IndexOf(gameData.quizOrderCollectibles, color) == -1) &&
            (i < gameData.quizOrderCollectibles.Length && i != -1))
        {
            gameData.quizOrderCollectibles[i] = color;
            gameData.quizNbrBtnPressed++;
        }
    }

    public void DisplayButtonOrder()
    {
        string tmp = "";
        for (int i = 0; i < gameData.collectibles.Length; i++)
        {
            tmp += gameData.collectibles[i] + " ";
        }

        textFbQuiz.GetComponent<Text>().text = tmp;
    }
}
