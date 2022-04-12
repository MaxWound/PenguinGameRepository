using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject restartWindowGO;
    private GameObject[] triesIMG;
    GameObject gridGO;
    GridLayout grid;
    public static GameManager gameManager;
    public int TriesCount;
    public bool GameOver;
    private void Start()
    {
        GameOver = false;
        restartWindowGO.SetActive(false);
        gameManager = this;
        ResetTries();
    }
    public void MinusTry()
    {
        Destroy(triesIMG[TriesCount - 1]);
        TriesCount--;
        if (TriesCount == 0)
        {
            GameOver = true;
        }
        
    }
    public void ResetTries()
    {
        triesIMG = GameObject.FindGameObjectsWithTag("Try");
        print(triesIMG.Length);
        TriesCount = 5;
    }
    public void ShowRestartWindow()
    {
        restartWindowGO.SetActive(true);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene("Level");
    }
}
