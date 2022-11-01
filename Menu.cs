using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class Menu : MonoBehaviour
{

    public TextMeshProUGUI BallSelect;
    public bool isBallRandom = false;
    public GameObject beginPanel;
    public GameObject menuPanel;
    private bool isMenuActive = false;

    void Start()
    {
        Time.timeScale = 1f;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            AMenu();
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void AMenu()
    {
        if(isMenuActive == false)
        {
            menuPanel.SetActive(true);
            isMenuActive = true;
            Time.timeScale = 0f;
        }else
        {
            menuPanel.SetActive(false);
            isMenuActive = false;
            Time.timeScale = 1f;
        }
    }
    public void BeginGame()
    {
        beginPanel.SetActive(false);
    }
    public void SelectBall()
    {
        if(isBallRandom == false)
        {
            isBallRandom = true;
            BallSelect.text = "Random";
        }  
        else
        {
            isBallRandom = false;
            BallSelect.text = "Simple";
        }  
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("menu");
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Play()
    {
        SceneManager.LoadScene("Play");
    }
    public void SimpleLevel()
    {
        SceneManager.LoadScene("Simple");
    }
    public void RandomLevel()
    { 
        SceneManager.LoadScene("Random");
    }
}
