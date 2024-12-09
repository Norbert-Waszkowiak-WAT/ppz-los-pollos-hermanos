using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    
    public int isActive = 0; // 0 - przed walką, 1 - walka, 2 - po walce
    
    
    public GameObject[] door;

    private void Awake()
    {
      for(int i=0;i<door.Length;i++)
            {
                Renderer doorSprite = door[i].GetComponent<Renderer>();
                doorSprite.material.color = Color.clear;
            }
        for (int i = 0; i < door.Length; i++)
            {

            BoxCollider2D doorCollider = door[i].GetComponent<BoxCollider2D>();

            if (doorCollider != null)
                {
                 //doorCollider.enabled = false;
                }
            }
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
                Renderer doorSprite = door[i].GetComponent<Renderer>();
                doorSprite.material.color = Color.white;
            }


            isActive = 1; 
        
    }
}