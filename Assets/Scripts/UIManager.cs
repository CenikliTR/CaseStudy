using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    GameManager manager;
    [SerializeField] GameObject startPanel,finishPanel, scoreText,stick;
    //public bool isPlay = false;
    public int score = 0, scoreVariable = 10;
    void Start()
    {
        manager = FindObjectOfType<GameManager>();
        finishPanel.SetActive(false);
        scoreText.SetActive(false);
    }
    public void StartScreen()
    {
        
        scoreText.SetActive(true);
        startPanel.SetActive(false);
        scoreText.SetActive(true);
        stick.SetActive(true);
        manager.isPlay = true;

    }
    public void FinishScreen()
    {
        finishPanel.SetActive(true);
        stick.SetActive(false);
        scoreText.GetComponentInChildren<RectTransform>().SetPositionAndRotation(new Vector3(Screen.width/2f,Screen.height/2f,1f),
            Quaternion.identity);
        
    }
    public void ScoreBoard()
    {
        score = score + scoreVariable;
        scoreText.GetComponent<Text>().text = "Score: " + score.ToString();
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void RePlay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        scoreText.SetActive(true);
        startPanel.SetActive(false);
        scoreText.SetActive(true);
        stick.SetActive(true);
        manager.isPlay = true;
    }

}
