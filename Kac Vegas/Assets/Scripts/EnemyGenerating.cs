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
    private int xPos;
    private int yPos;
    private int enemyCount;
    private int obstacleCount;
   
    [SerializeField] GameObject room;
    
  

    void Start()
    {
        StartCoroutine(ObstacleDrop());
        StartCoroutine(EnemyDrop());

    }


    

     IEnumerator ObstacleDrop()
    {
        while(obstacleCount<10)
        {
            yPos = Random.Range((int)room.transform.position.y-6, (int)room.transform.position.y+6);
            xPos = Random.Range((int)room.transform.position.x-6, (int)room.transform.position.x+6);
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
       while(enemyCount<7){
        yPos = Random.Range((int)room.transform.position.y-6, (int)room.transform.position.y+6);
        xPos = Random.Range((int)room.transform.position.x-6, (int)room.transform.position.x+6);

        
        Collider2D collider2D = Physics2D.OverlapCircle(new Vector2(xPos,yPos), 0.2f);
        if(collider2D ==null)
        {
            Instantiate(theEnemy, new Vector2(xPos,yPos),Quaternion.identity);
            enemyCount+=1;
        }
       }
        yield return null;
    }
   
    
}
