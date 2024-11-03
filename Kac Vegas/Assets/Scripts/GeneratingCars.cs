using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratingCars : MonoBehaviour
{
    public GameObject theEnemy;
    private int xPos=10;
    private int yPos;
    private int enemyCount;
    private int a;
    private int b;
    private int c;  

    void Start()
    {
        StartCoroutine(EnemyDrop());
    }


    IEnumerator EnemyDrop()
    {
        

        while(enemyCount<40)
        {
            b = Random.Range(0, 2);
           
            yPos = Random.Range(-2,7);
            while(c==yPos)
            {
                c = Random.Range(-2, 7);
            }
            Instantiate(theEnemy, new Vector2(xPos,yPos),Quaternion.identity);
            if(b==1)
            {
                Instantiate(theEnemy, new Vector2(xPos+3, c), Quaternion.identity);
            }
            a = Random.Range(5, 15);
            xPos += a;
            yield return null;
            enemyCount++;
        }
    }
  
}
