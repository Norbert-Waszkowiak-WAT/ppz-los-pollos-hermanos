using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    
    public int isActive = 0; // 0 - przed walką, 1 - walka, 2 - po walce
    
    
    public GameObject[] door;

    private void Awake()
    {
      
    }

   void Start()
{

    for (int i = 0; i < door.Length; i++)
    {
        BoxCollider2D doorCollider = door[i].GetComponent<BoxCollider2D>();
        if (doorCollider != null)
        {
            //doorCollider.enabled = false;
        }
    }
}

    

    public void ClosingDoors()
    {
        Debug.Log("Drzwi się zamknęły!");
      
        
            for (int i = 0; i < door.Length; i++)
            {
                BoxCollider2D doorCollider = door[i].GetComponent<BoxCollider2D>();
                if (doorCollider != null)
                {
                    doorCollider.enabled = true;
                    doorCollider.isTrigger = false;
                }
            }
            
            
            
            
            
            for(int i=0;i<door.Length;i++)
            {
                SpriteRenderer doorSprite = door[i].GetComponent<SpriteRenderer>();
                doorSprite.color = Color.red;
            }


            isActive = 1; 
        
    }
}