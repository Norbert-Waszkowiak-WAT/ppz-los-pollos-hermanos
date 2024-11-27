using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;

public class EnemyGenerating : MonoBehaviour
{
    public GameObject theEnemy;
    public GameObject obstacle;
    public PlayerController player;
    private int xPos;
    private int yPos;
    private int enemyCount;
    private int obstacleCount;

   
    
    
  

    void Start()
    {

        StartCoroutine(ObstacleDrop());
        StartCoroutine(EnemyDrop());

    }
    void Update()
    {
        
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
        enemyCount =Random.Range(2,10);
       while(enemyCount<7){
        yPos = Random.Range((int)transform.position.y-5, (int)transform.position.y+5);
        xPos = Random.Range((int)transform.position.x-5, (int)transform.position.x+5);

        
        Collider2D collider2D = Physics2D.OverlapCircle(new Vector2(xPos,yPos), 0.2f);
        if(collider2D ==null)
        {
            Instantiate(theEnemy, new Vector2(xPos,yPos),Quaternion.identity);
            enemyCount+=1;
        }
       }
        yield return null;
    }

    void PlayerInside(PlayerController player){
       if(player.transform.position.x == transform.position.x+6 && player.transform.position.y == transform.position.y+6)
       {
            
       }

    }
    

   
    
}
