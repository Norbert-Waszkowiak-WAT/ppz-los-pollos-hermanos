using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleDoor : MonoBehaviour
{
   
   private SpriteRenderer mySprite;
   private BoxCollider2D doorcollider;
   public Doors doors;


    private void Awake()
    {
        if (doors == null)
        {
            Debug.LogError("Nie przypisano komponentu Doors w skrypcie SingleDoor!");
        }
        
       
        mySprite = GetComponent<SpriteRenderer>();
        doorcollider = GetComponent<BoxCollider2D>();
    }
   


   void OnTriggerExit2D(Collider2D other)
    {
       

        Debug.Log("Trigger1");
        
        if (other.CompareTag("Player") && doors != null && doors.isActive == 0)
        {
            Debug.Log("Trigger");
            doors.ClosingDoors();
            
        }
    }



}
