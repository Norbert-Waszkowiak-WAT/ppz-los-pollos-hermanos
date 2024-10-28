using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public int levelToChange;
    public GameObject Auto;
    

    void Awake()
    {
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Auto.transform.position.x>=710)
        {
           SceneManager.LoadScene(levelToChange);
        }

    }
}
