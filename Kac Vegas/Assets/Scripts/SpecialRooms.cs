using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class SpecialRooms : MonoBehaviour
{
    // Start is called before the first frame update
  
    public GameObject[] objectsToSpawn;
  
    
    

    void Start()
    {
        
        if (objectsToSpawn.Length > 0)
        {
           
            int randomIndex = UnityEngine.Random.Range(0, objectsToSpawn.Length);

          
            GameObject selectedObject = objectsToSpawn[randomIndex];
            
         
            GameObject spawned = Instantiate(selectedObject, transform.position, quaternion.identity);
            Debug.LogError("spawn" + spawned);
        }
     
    }
}


