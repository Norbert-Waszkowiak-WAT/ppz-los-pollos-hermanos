using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Random = UnityEngine.Random;
using Vector2 = UnityEngine.Vector2;

public class EnemyGenerating : MonoBehaviour
{
   
    public GameObject obstacle;
    public PlayerController player;
    private int xPos;
    private int yPos;
    private int enemyCount;
    private int obstacleCount;
    public GameObject[] objectsToSpawn;
    public Doors doors;
    
    void Awake()
    {
       
    }

    void Start()
    {
        
       

    }

  

    void Update()
    {
        if(doors.isActive==1){
            StartCoroutine(ObstacleDrop());
            StartCoroutine(EnemyDrop());
            doors.isActive=2;
        }
    }


    

    IEnumerator ObstacleDrop()
    {
        obstacleCount =Random.Range(2,10);
        


        while(obstacleCount<10)
        {
            yPos = Random.Range((int)transform.position.y-5, (int)transform.position.y+5);
            xPos = Random.Range((int)transform.position.x-5, (int)transform.position.x+5);
            Collider2D collider2D = Physics2D.OverlapCircle(new Vector2(xPos,yPos), 0.2f);
            if(collider2D ==null)
            {
                Instantiate(obstacle, new Vector2(xPos,yPos),Quaternion.identity);
                obstacleCount+=1;
            }   


        }
        

        yield return null;
    }

    IEnumerator EnemyDrop()
    {
        enemyCount =Random.Range(2,5);
        
        while(enemyCount<7){
        int randomIndex = Random.Range(0, objectsToSpawn.Length);
        GameObject selectedObject = objectsToSpawn[randomIndex];
        yPos = Random.Range((int)transform.position.y-5, (int)transform.position.y+5);
        xPos = Random.Range((int)transform.position.x-5, (int)transform.position.x+5);

        
        Collider2D collider2D = Physics2D.OverlapCircle(new Vector2(xPos,yPos), 0.2f);
        if(collider2D ==null)
        {
            Instantiate(selectedObject, new Vector2(xPos,yPos),Quaternion.identity);
            enemyCount+=1;
        }
       }
        yield return null;
    }

     
    

   
    
}
