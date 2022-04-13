using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    float distance;
    [SerializeField]
    private TMP_Text distanceText;
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
    private void Update()
    {
        distance = (PenguinScript.penguinScript.transform.position.x * -1) - (PenguinScript.penguinScript.startXpos * -1);
        distanceText.text = $"distance : {Mathf.Round(distance)}";
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
