using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject Player;
   
    void Awake()
    {

        gameOverUI.SetActive(false);
    }
    void Update()
    {


    }

    public void GameOver()
    {

        gameOverUI.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);


    }


}
