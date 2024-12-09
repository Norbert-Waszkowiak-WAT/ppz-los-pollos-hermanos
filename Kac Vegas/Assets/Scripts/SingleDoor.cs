using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleDoor : MonoBehaviour
{
   
   private SpriteRenderer mySprite;
  
   public Doors doors;


    private void Awake()
    {
        if (doors == null)
        {
            Debug.LogError("Nie przypisano komponentu Doors w skrypcie SingleDoor!");
        }
        
       
        mySprite = GetComponent<SpriteRenderer>();
        
    }
   


   void OnTriggerExit2D(Collider2D other)
    {
       

        Debug.Log("gTriger1");
        
        if (other.CompareTag("Player") && doors != null && doors.isActive == 0)
        {
            Debug.Log("Trigger");
            doors.ClosingDoors();
            
        }
    }



}
