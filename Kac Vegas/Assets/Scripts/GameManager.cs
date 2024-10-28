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

    public void gameOver()
    {

        gameOverUI.SetActive(true);
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);


    }


}
